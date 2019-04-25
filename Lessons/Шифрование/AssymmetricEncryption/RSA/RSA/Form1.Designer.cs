namespace RSA
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.outEncFileBox = new System.Windows.Forms.TextBox();
            this.ecnryptBtn = new System.Windows.Forms.Button();
            this.selectRawFileBtn = new System.Windows.Forms.Button();
            this.inpRawFileBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.decryptBtn = new System.Windows.Forms.Button();
            this.selectDecFileBtn = new System.Windows.Forms.Button();
            this.outDecFileBox = new System.Windows.Forms.TextBox();
            this.inpEncFileBox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(560, 85);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.outEncFileBox);
            this.tabPage1.Controls.Add(this.ecnryptBtn);
            this.tabPage1.Controls.Add(this.selectRawFileBtn);
            this.tabPage1.Controls.Add(this.inpRawFileBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(552, 59);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Зашифровать";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // outEncFileBox
            // 
            this.outEncFileBox.Location = new System.Drawing.Point(6, 34);
            this.outEncFileBox.Name = "outEncFileBox";
            this.outEncFileBox.ReadOnly = true;
            this.outEncFileBox.Size = new System.Drawing.Size(439, 20);
            this.outEncFileBox.TabIndex = 5;
            // 
            // ecnryptBtn
            // 
            this.ecnryptBtn.Location = new System.Drawing.Point(451, 33);
            this.ecnryptBtn.Name = "ecnryptBtn";
            this.ecnryptBtn.Size = new System.Drawing.Size(95, 20);
            this.ecnryptBtn.TabIndex = 2;
            this.ecnryptBtn.Text = "Зашифровать";
            this.ecnryptBtn.UseVisualStyleBackColor = true;
            this.ecnryptBtn.Click += new System.EventHandler(this.ecnryptBtn_Click);
            // 
            // selectRawFileBtn
            // 
            this.selectRawFileBtn.Location = new System.Drawing.Point(451, 7);
            this.selectRawFileBtn.Name = "selectRawFileBtn";
            this.selectRawFileBtn.Size = new System.Drawing.Size(95, 20);
            this.selectRawFileBtn.TabIndex = 1;
            this.selectRawFileBtn.Text = "Выбрать файл";
            this.selectRawFileBtn.UseVisualStyleBackColor = true;
            this.selectRawFileBtn.Click += new System.EventHandler(this.selectRawFileBtn_Click);
            // 
            // inpRawFileBox
            // 
            this.inpRawFileBox.Location = new System.Drawing.Point(6, 7);
            this.inpRawFileBox.Name = "inpRawFileBox";
            this.inpRawFileBox.Size = new System.Drawing.Size(439, 20);
            this.inpRawFileBox.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.decryptBtn);
            this.tabPage2.Controls.Add(this.selectDecFileBtn);
            this.tabPage2.Controls.Add(this.outDecFileBox);
            this.tabPage2.Controls.Add(this.inpEncFileBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(552, 59);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Расшифровать";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // decryptBtn
            // 
            this.decryptBtn.Location = new System.Drawing.Point(448, 32);
            this.decryptBtn.Name = "decryptBtn";
            this.decryptBtn.Size = new System.Drawing.Size(98, 20);
            this.decryptBtn.TabIndex = 9;
            this.decryptBtn.Text = "Расшифоровать";
            this.decryptBtn.UseVisualStyleBackColor = true;
            // 
            // selectDecFileBtn
            // 
            this.selectDecFileBtn.Location = new System.Drawing.Point(448, 6);
            this.selectDecFileBtn.Name = "selectDecFileBtn";
            this.selectDecFileBtn.Size = new System.Drawing.Size(98, 20);
            this.selectDecFileBtn.TabIndex = 8;
            this.selectDecFileBtn.Text = "Выбрать файл";
            this.selectDecFileBtn.UseVisualStyleBackColor = true;
            // 
            // outDecFileBox
            // 
            this.outDecFileBox.Location = new System.Drawing.Point(3, 32);
            this.outDecFileBox.Name = "outDecFileBox";
            this.outDecFileBox.ReadOnly = true;
            this.outDecFileBox.Size = new System.Drawing.Size(439, 20);
            this.outDecFileBox.TabIndex = 6;
            // 
            // inpEncFileBox
            // 
            this.inpEncFileBox.Location = new System.Drawing.Point(3, 6);
            this.inpEncFileBox.Name = "inpEncFileBox";
            this.inpEncFileBox.Size = new System.Drawing.Size(439, 20);
            this.inpEncFileBox.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 102);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox outEncFileBox;
        private System.Windows.Forms.Button ecnryptBtn;
        private System.Windows.Forms.Button selectRawFileBtn;
        private System.Windows.Forms.TextBox inpRawFileBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button decryptBtn;
        private System.Windows.Forms.Button selectDecFileBtn;
        private System.Windows.Forms.TextBox outDecFileBox;
        private System.Windows.Forms.TextBox inpEncFileBox;
    }
}

