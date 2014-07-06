using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace GameHacker
{

    public partial class form : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

        private List<Process> WindowedProcesses = new List<Process>();
        private List<IntPtr> AddrList = new List<IntPtr>();
        private bool isFirstSearch = true;
        private Process SelectedProcess;

        private void RefreshProcessList()
        {
            SelectedProcess = null;
            processList.Items.Clear();
            WindowedProcesses.Clear();
            changeBox.Enabled = false;
            talkLabel.Text = "请先选择要修改的游戏";
            foreach (var p in Process.GetProcesses())
            {
                if (p.MainWindowHandle != IntPtr.Zero)
                {
                    if (!string.IsNullOrEmpty(p.MainWindowTitle))
                    {
                        processList.Items.Add(p.MainWindowTitle);
                        WindowedProcesses.Add(p);
                    }
                }
            }
        }

        public form()
        {
            InitializeComponent();
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            RefreshProcessList();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            RefreshProcessList();
        }

        private List<IntPtr> CreateAddrList(IntPtr baseAddr, int value)
        {
            int bytesRead;
            byte[] buffer = new byte[4096];
            bool ok;
            List<IntPtr> result = new List<IntPtr>();
            ok = ReadProcessMemory(SelectedProcess.Handle, baseAddr, buffer, 4096, out bytesRead);
            if (!ok) return null;
            int currentVal;
            for (int i = 0; i < 4096 - 3;i++)
            {
                currentVal = BitConverter.ToInt32(buffer, i);
                if (currentVal == value)
                {
                    IntPtr addr = new IntPtr(baseAddr.ToInt32() + i);
                    result.Add(addr);
                    i += 3;
                }
            }
            return result;
        }

        private void RefreshAddrList(int value)
        {
            var la = AddrList.ToList();
            AddrList.Clear();

            byte[] buffer = new byte[4];
            int bytesRead;
            foreach (var i in la)
            {
                ReadProcessMemory(SelectedProcess.Handle, i, buffer, 4, out bytesRead);
                if (BitConverter.ToInt32(buffer, 0) == value) AddrList.Add(i);
            }
        }

        private void findBtn_Click(object sender, EventArgs e)
        {
            resultBox.Items.Clear();
            if (SelectedProcess == null) return;
            if (isFirstSearch)
            {
                uint baseAddr = 0x00010000;
                uint endAddr = 0x7ffeffff;
                for (uint i = baseAddr; i < endAddr; i += (4 * 1024))
                {
                    var addrs = CreateAddrList(new IntPtr(i), int.Parse(numberBox.Text));
                    if (addrs != null) AddrList.AddRange(addrs);
                }
                isFirstSearch = false;
            }
            else
            {
                RefreshAddrList(int.Parse(numberBox.Text));
            }
            label2.Text = "找到 " + AddrList.Count.ToString() + " 个结果";
            MessageBox.Show(label2.Text);
            if (AddrList.Count == 1) changeBox.Enabled = true;
            if (AddrList.Count < 1000)
            {
                foreach (var i in AddrList)
                {
                    resultBox.Items.Add(i.ToString());
                }
            }
        }

        private void changeBtn_Click(object sender, EventArgs e)
        {
            int value;
            if (!int.TryParse(changeBox.Text, out value))
            {
                MessageBox.Show("溢出!");
                return;
            }
            var buffer = BitConverter.GetBytes(value);
            int bytesWritten;
            WriteProcessMemory(SelectedProcess.Handle, AddrList[0], buffer, 4, out bytesWritten);
        }

        private void processList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = processList.SelectedIndex;
            if (idx<0 || idx >= WindowedProcesses.Count)
            {
                RefreshProcessList();
                return;
            }
            SelectedProcess = WindowedProcesses[idx];
            talkLabel.Text = (string)processList.SelectedItem;
        }
    }
}
