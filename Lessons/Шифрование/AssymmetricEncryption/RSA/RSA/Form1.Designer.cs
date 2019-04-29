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
            this.recieverTab = new System.Windows.Forms.TabPage();
            this.decryptBtn = new System.Windows.Forms.Button();
            this.outOpenKeyBox = new System.Windows.Forms.TextBox();
            this.outDecFileBox = new System.Windows.Forms.TextBox();
            this.makeOpenKeyBtn = new System.Windows.Forms.Button();
            this.selectEncFileBtn = new System.Windows.Forms.Button();
            this.inpEncFileBox = new System.Windows.Forms.TextBox();
            this.senderTab = new System.Windows.Forms.TabPage();
            this.inpOpenKeyBox = new System.Windows.Forms.TextBox();
            this.selectOpenKeyBtn = new System.Windows.Forms.Button();
            this.encryptBtn = new System.Windows.Forms.Button();
            this.selectRawFileBtn = new System.Windows.Forms.Button();
            this.outEncFileBox = new System.Windows.Forms.TextBox();
            this.inpRawFileBox = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.recieverTab.SuspendLayout();
            this.senderTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.recieverTab);
            this.tabControl1.Controls.Add(this.senderTab);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(563, 110);
            this.tabControl1.TabIndex = 8;
            // 
            // recieverTab
            // 
            this.recieverTab.Controls.Add(this.decryptBtn);
            this.recieverTab.Controls.Add(this.outOpenKeyBox);
            this.recieverTab.Controls.Add(this.outDecFileBox);
            this.recieverTab.Controls.Add(this.makeOpenKeyBtn);
            this.recieverTab.Controls.Add(this.selectEncFileBtn);
            this.recieverTab.Controls.Add(this.inpEncFileBox);
            this.recieverTab.Location = new System.Drawing.Point(4, 22);
            this.recieverTab.Name = "recieverTab";
            this.recieverTab.Padding = new System.Windows.Forms.Padding(3);
            this.recieverTab.Size = new System.Drawing.Size(555, 84);
            this.recieverTab.TabIndex = 0;
            this.recieverTab.Text = "Получатель";
            this.recieverTab.UseVisualStyleBackColor = true;
            // 
            // decryptBtn
            // 
            this.decryptBtn.Location = new System.Drawing.Point(451, 59);
            this.decryptBtn.Name = "decryptBtn";
            this.decryptBtn.Size = new System.Drawing.Size(95, 20);
            this.decryptBtn.TabIndex = 7;
            this.decryptBtn.Text = "Расшифровать";
            this.decryptBtn.UseVisualStyleBackColor = true;
            this.decryptBtn.Click += new System.EventHandler(this.decryptBtn_Click);
            // 
            // outOpenKeyBox
            // 
            this.outOpenKeyBox.Location = new System.Drawing.Point(6, 7);
            this.outOpenKeyBox.Name = "outOpenKeyBox";
            this.outOpenKeyBox.Size = new System.Drawing.Size(439, 20);
            this.outOpenKeyBox.TabIndex = 6;
            this.outOpenKeyBox.Text = "openkey.txt";
            // 
            // outDecFileBox
            // 
            this.outDecFileBox.Location = new System.Drawing.Point(6, 59);
            this.outDecFileBox.Name = "outDecFileBox";
            this.outDecFileBox.ReadOnly = true;
            this.outDecFileBox.Size = new System.Drawing.Size(439, 20);
            this.outDecFileBox.TabIndex = 5;
            // 
            // makeOpenKeyBtn
            // 
            this.makeOpenKeyBtn.Location = new System.Drawing.Point(451, 7);
            this.makeOpenKeyBtn.Name = "makeOpenKeyBtn";
            this.makeOpenKeyBtn.Size = new System.Drawing.Size(95, 20);
            this.makeOpenKeyBtn.TabIndex = 2;
            this.makeOpenKeyBtn.Text = "Открытый ключ";
            this.makeOpenKeyBtn.UseVisualStyleBackColor = true;
            this.makeOpenKeyBtn.Click += new System.EventHandler(this.ecnryptBtn_Click);
            // 
            // selectEncFileBtn
            // 
            this.selectEncFileBtn.Location = new System.Drawing.Point(451, 33);
            this.selectEncFileBtn.Name = "selectEncFileBtn";
            this.selectEncFileBtn.Size = new System.Drawing.Size(95, 20);
            this.selectEncFileBtn.TabIndex = 1;
            this.selectEncFileBtn.Text = "Выбрать файл";
            this.selectEncFileBtn.UseVisualStyleBackColor = true;
            this.selectEncFileBtn.Click += new System.EventHandler(this.selectУтсFileBtn_Click);
            // 
            // inpEncFileBox
            // 
            this.inpEncFileBox.Location = new System.Drawing.Point(6, 33);
            this.inpEncFileBox.Name = "inpEncFileBox";
            this.inpEncFileBox.Size = new System.Drawing.Size(439, 20);
            this.inpEncFileBox.TabIndex = 0;
            // 
            // senderTab
            // 
            this.senderTab.Controls.Add(this.inpOpenKeyBox);
            this.senderTab.Controls.Add(this.selectOpenKeyBtn);
            this.senderTab.Controls.Add(this.encryptBtn);
            this.senderTab.Controls.Add(this.selectRawFileBtn);
            this.senderTab.Controls.Add(this.outEncFileBox);
            this.senderTab.Controls.Add(this.inpRawFileBox);
            this.senderTab.Location = new System.Drawing.Point(4, 22);
            this.senderTab.Name = "senderTab";
            this.senderTab.Padding = new System.Windows.Forms.Padding(3);
            this.senderTab.Size = new System.Drawing.Size(555, 84);
            this.senderTab.TabIndex = 1;
            this.senderTab.Text = "Отправитель";
            this.senderTab.UseVisualStyleBackColor = true;
            // 
            // inpOpenKeyBox
            // 
            this.inpOpenKeyBox.Location = new System.Drawing.Point(6, 7);
            this.inpOpenKeyBox.Name = "inpOpenKeyBox";
            this.inpOpenKeyBox.Size = new System.Drawing.Size(439, 20);
            this.inpOpenKeyBox.TabIndex = 11;
            // 
            // selectOpenKeyBtn
            // 
            this.selectOpenKeyBtn.Location = new System.Drawing.Point(451, 7);
            this.selectOpenKeyBtn.Name = "selectOpenKeyBtn";
            this.selectOpenKeyBtn.Size = new System.Drawing.Size(98, 20);
            this.selectOpenKeyBtn.TabIndex = 10;
            this.selectOpenKeyBtn.Text = "Выбрать ключ";
            this.selectOpenKeyBtn.UseVisualStyleBackColor = true;
            this.selectOpenKeyBtn.Click += new System.EventHandler(this.selectOpenKeyBtn_Click);
            // 
            // encryptBtn
            // 
            this.encryptBtn.Location = new System.Drawing.Point(451, 59);
            this.encryptBtn.Name = "encryptBtn";
            this.encryptBtn.Size = new System.Drawing.Size(98, 20);
            this.encryptBtn.TabIndex = 9;
            this.encryptBtn.Text = "Зашифровать";
            this.encryptBtn.UseVisualStyleBackColor = true;
            this.encryptBtn.Click += new System.EventHandler(this.encryptBtn_Click);
            // 
            // selectRawFileBtn
            // 
            this.selectRawFileBtn.Location = new System.Drawing.Point(451, 33);
            this.selectRawFileBtn.Name = "selectRawFileBtn";
            this.selectRawFileBtn.Size = new System.Drawing.Size(98, 20);
            this.selectRawFileBtn.TabIndex = 8;
            this.selectRawFileBtn.Text = "Выбрать файл";
            this.selectRawFileBtn.UseVisualStyleBackColor = true;
            this.selectRawFileBtn.Click += new System.EventHandler(this.selectRawFileBtn_Click);
            // 
            // outEncFileBox
            // 
            this.outEncFileBox.Location = new System.Drawing.Point(6, 59);
            this.outEncFileBox.Name = "outEncFileBox";
            this.outEncFileBox.ReadOnly = true;
            this.outEncFileBox.Size = new System.Drawing.Size(439, 20);
            this.outEncFileBox.TabIndex = 6;
            // 
            // inpRawFileBox
            // 
            this.inpRawFileBox.Location = new System.Drawing.Point(6, 33);
            this.inpRawFileBox.Name = "inpRawFileBox";
            this.inpRawFileBox.Size = new System.Drawing.Size(439, 20);
            this.inpRawFileBox.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 196);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.recieverTab.ResumeLayout(false);
            this.recieverTab.PerformLayout();
            this.senderTab.ResumeLayout(false);
            this.senderTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage recieverTab;
        private System.Windows.Forms.TextBox outDecFileBox;
        private System.Windows.Forms.Button makeOpenKeyBtn;
        private System.Windows.Forms.Button selectEncFileBtn;
        private System.Windows.Forms.TextBox inpEncFileBox;
        private System.Windows.Forms.TabPage senderTab;
        private System.Windows.Forms.Button encryptBtn;
        private System.Windows.Forms.Button selectRawFileBtn;
        private System.Windows.Forms.TextBox outEncFileBox;
        private System.Windows.Forms.TextBox inpRawFileBox;
        private System.Windows.Forms.Button decryptBtn;
        private System.Windows.Forms.TextBox outOpenKeyBox;
        private System.Windows.Forms.TextBox inpOpenKeyBox;
        private System.Windows.Forms.Button selectOpenKeyBtn;
    }
}

