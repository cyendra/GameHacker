namespace GameHacker
{
    partial class form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.processList = new System.Windows.Forms.ListBox();
            this.findBtn = new System.Windows.Forms.Button();
            this.changeBtn = new System.Windows.Forms.Button();
            this.talkLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numberBox = new System.Windows.Forms.TextBox();
            this.changeBox = new System.Windows.Forms.TextBox();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.resultBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // processList
            // 
            this.processList.FormattingEnabled = true;
            this.processList.ItemHeight = 12;
            this.processList.Location = new System.Drawing.Point(12, 12);
            this.processList.Name = "processList";
            this.processList.Size = new System.Drawing.Size(255, 196);
            this.processList.TabIndex = 0;
            this.processList.SelectedIndexChanged += new System.EventHandler(this.processList_SelectedIndexChanged);
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(499, 54);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(83, 23);
            this.findBtn.TabIndex = 1;
            this.findBtn.Text = "寻找";
            this.findBtn.UseVisualStyleBackColor = true;
            this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
            // 
            // changeBtn
            // 
            this.changeBtn.Location = new System.Drawing.Point(499, 214);
            this.changeBtn.Name = "changeBtn";
            this.changeBtn.Size = new System.Drawing.Size(83, 23);
            this.changeBtn.TabIndex = 2;
            this.changeBtn.Text = "修改";
            this.changeBtn.UseVisualStyleBackColor = true;
            this.changeBtn.Click += new System.EventHandler(this.changeBtn_Click);
            // 
            // talkLabel
            // 
            this.talkLabel.AutoSize = true;
            this.talkLabel.Location = new System.Drawing.Point(273, 12);
            this.talkLabel.Name = "talkLabel";
            this.talkLabel.Size = new System.Drawing.Size(125, 12);
            this.talkLabel.TabIndex = 3;
            this.talkLabel.Text = "请先选择要修改的游戏";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "搜索结果";
            // 
            // numberBox
            // 
            this.numberBox.Location = new System.Drawing.Point(275, 27);
            this.numberBox.Name = "numberBox";
            this.numberBox.Size = new System.Drawing.Size(307, 21);
            this.numberBox.TabIndex = 5;
            // 
            // changeBox
            // 
            this.changeBox.Location = new System.Drawing.Point(275, 187);
            this.changeBox.Name = "changeBox";
            this.changeBox.Size = new System.Drawing.Size(307, 21);
            this.changeBox.TabIndex = 6;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(192, 214);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshBtn.TabIndex = 7;
            this.refreshBtn.Text = "刷新";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // resultBox
            // 
            this.resultBox.FormattingEnabled = true;
            this.resultBox.ItemHeight = 12;
            this.resultBox.Location = new System.Drawing.Point(273, 81);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(309, 88);
            this.resultBox.TabIndex = 8;
            // 
            // form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 243);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.refreshBtn);
            this.Controls.Add(this.changeBox);
            this.Controls.Add(this.numberBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.talkLabel);
            this.Controls.Add(this.changeBtn);
            this.Controls.Add(this.findBtn);
            this.Controls.Add(this.processList);
            this.Name = "form";
            this.Text = "Game Hacker";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox processList;
        private System.Windows.Forms.Button findBtn;
        private System.Windows.Forms.Button changeBtn;
        private System.Windows.Forms.Label talkLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox numberBox;
        private System.Windows.Forms.TextBox changeBox;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.ListBox resultBox;
    }
}

