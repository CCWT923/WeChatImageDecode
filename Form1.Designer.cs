namespace WeChatImageDecode
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_Start = new System.Windows.Forms.Button();
            this.TextBox_SourceFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox_TargetFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_SelectSourceFolder = new System.Windows.Forms.Button();
            this.Btn_SelectTargetFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_Start
            // 
            this.Btn_Start.Location = new System.Drawing.Point(503, 145);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(157, 45);
            this.Btn_Start.TabIndex = 0;
            this.Btn_Start.Text = "开始";
            this.Btn_Start.UseVisualStyleBackColor = true;
            this.Btn_Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // TextBox_SourceFolder
            // 
            this.TextBox_SourceFolder.Location = new System.Drawing.Point(12, 43);
            this.TextBox_SourceFolder.Name = "TextBox_SourceFolder";
            this.TextBox_SourceFolder.Size = new System.Drawing.Size(556, 23);
            this.TextBox_SourceFolder.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "原始图片文件夹：";
            // 
            // TextBox_TargetFolder
            // 
            this.TextBox_TargetFolder.Location = new System.Drawing.Point(12, 101);
            this.TextBox_TargetFolder.Name = "TextBox_TargetFolder";
            this.TextBox_TargetFolder.Size = new System.Drawing.Size(556, 23);
            this.TextBox_TargetFolder.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "解密后的图片文件夹：";
            // 
            // Btn_SelectSourceFolder
            // 
            this.Btn_SelectSourceFolder.Location = new System.Drawing.Point(574, 39);
            this.Btn_SelectSourceFolder.Name = "Btn_SelectSourceFolder";
            this.Btn_SelectSourceFolder.Size = new System.Drawing.Size(86, 30);
            this.Btn_SelectSourceFolder.TabIndex = 3;
            this.Btn_SelectSourceFolder.Tag = "source";
            this.Btn_SelectSourceFolder.Text = "浏览";
            this.Btn_SelectSourceFolder.UseVisualStyleBackColor = true;
            this.Btn_SelectSourceFolder.Click += new System.EventHandler(this.FolderBrowser);
            // 
            // Btn_SelectTargetFolder
            // 
            this.Btn_SelectTargetFolder.Location = new System.Drawing.Point(574, 96);
            this.Btn_SelectTargetFolder.Name = "Btn_SelectTargetFolder";
            this.Btn_SelectTargetFolder.Size = new System.Drawing.Size(86, 32);
            this.Btn_SelectTargetFolder.TabIndex = 3;
            this.Btn_SelectTargetFolder.Tag = "target";
            this.Btn_SelectTargetFolder.Text = "浏览";
            this.Btn_SelectTargetFolder.UseVisualStyleBackColor = true;
            this.Btn_SelectTargetFolder.Click += new System.EventHandler(this.FolderBrowser);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 221);
            this.Controls.Add(this.Btn_SelectTargetFolder);
            this.Controls.Add(this.Btn_SelectSourceFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBox_TargetFolder);
            this.Controls.Add(this.TextBox_SourceFolder);
            this.Controls.Add(this.Btn_Start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Btn_Start;
        private TextBox TextBox_SourceFolder;
        private Label label1;
        private TextBox TextBox_TargetFolder;
        private Label label2;
        private Button Btn_SelectSourceFolder;
        private Button Btn_SelectTargetFolder;
    }
}