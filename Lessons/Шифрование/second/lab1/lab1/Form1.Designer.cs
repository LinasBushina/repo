namespace lab1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.outFileBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.inpFileBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.outKeysBox = new System.Windows.Forms.TextBox();
            this.encInpKeyBox = new System.Windows.Forms.TextBox();
            this.encInpFileBox = new System.Windows.Forms.TextBox();
            this.outDecFileBox = new System.Windows.Forms.TextBox();
            this.selectKeyEncButton = new System.Windows.Forms.Button();
            this.selectFileDecButton = new System.Windows.Forms.Button();
            this.decryptButton = new System.Windows.Forms.Button();
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
            this.tabControl1.Size = new System.Drawing.Size(553, 437);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.outKeysBox);
            this.tabPage1.Controls.Add(this.outFileBox);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.inpFileBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(545, 411);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Зашифровать";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // outFileBox
            // 
            this.outFileBox.Location = new System.Drawing.Point(6, 59);
            this.outFileBox.Name = "outFileBox";
            this.outFileBox.ReadOnly = true;
            this.outFileBox.Size = new System.Drawing.Size(439, 20);
            this.outFileBox.TabIndex = 4;
            this.outFileBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(451, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "Зашифровать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.encrypt);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(451, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Выбрать файл";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ChooseFileToEncrypt);
            // 
            // inpFileBox
            // 
            this.inpFileBox.Location = new System.Drawing.Point(6, 7);
            this.inpFileBox.Name = "inpFileBox";
            this.inpFileBox.Size = new System.Drawing.Size(439, 20);
            this.inpFileBox.TabIndex = 0;
            this.inpFileBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.decryptButton);
            this.tabPage2.Controls.Add(this.selectFileDecButton);
            this.tabPage2.Controls.Add(this.selectKeyEncButton);
            this.tabPage2.Controls.Add(this.outDecFileBox);
            this.tabPage2.Controls.Add(this.encInpFileBox);
            this.tabPage2.Controls.Add(this.encInpKeyBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(545, 411);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Расшифровать";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // outKeysBox
            // 
            this.outKeysBox.Location = new System.Drawing.Point(6, 33);
            this.outKeysBox.Name = "outKeysBox";
            this.outKeysBox.ReadOnly = true;
            this.outKeysBox.Size = new System.Drawing.Size(439, 20);
            this.outKeysBox.TabIndex = 5;
            // 
            // encInpKeyBox
            // 
            this.encInpKeyBox.Location = new System.Drawing.Point(3, 6);
            this.encInpKeyBox.Name = "encInpKeyBox";
            this.encInpKeyBox.Size = new System.Drawing.Size(439, 20);
            this.encInpKeyBox.TabIndex = 1;
            // 
            // encInpFileBox
            // 
            this.encInpFileBox.Location = new System.Drawing.Point(3, 32);
            this.encInpFileBox.Name = "encInpFileBox";
            this.encInpFileBox.Size = new System.Drawing.Size(439, 20);
            this.encInpFileBox.TabIndex = 2;
            // 
            // outDecFileBox
            // 
            this.outDecFileBox.Location = new System.Drawing.Point(3, 58);
            this.outDecFileBox.Name = "outDecFileBox";
            this.outDecFileBox.ReadOnly = true;
            this.outDecFileBox.Size = new System.Drawing.Size(439, 20);
            this.outDecFileBox.TabIndex = 6;
            // 
            // selectKeyEncButton
            // 
            this.selectKeyEncButton.Location = new System.Drawing.Point(448, 6);
            this.selectKeyEncButton.Name = "selectKeyEncButton";
            this.selectKeyEncButton.Size = new System.Drawing.Size(88, 20);
            this.selectKeyEncButton.TabIndex = 7;
            this.selectKeyEncButton.Text = "Выбрать ключ";
            this.selectKeyEncButton.UseVisualStyleBackColor = true;
            this.selectKeyEncButton.Click += new System.EventHandler(this.selectKeyEncButton_Click);
            // 
            // selectFileDecButton
            // 
            this.selectFileDecButton.Location = new System.Drawing.Point(448, 32);
            this.selectFileDecButton.Name = "selectFileDecButton";
            this.selectFileDecButton.Size = new System.Drawing.Size(88, 20);
            this.selectFileDecButton.TabIndex = 8;
            this.selectFileDecButton.Text = "Выбрать файл";
            this.selectFileDecButton.UseVisualStyleBackColor = true;
            this.selectFileDecButton.Click += new System.EventHandler(this.selectFileDecButton_Click);
            // 
            // decryptButton
            // 
            this.decryptButton.Location = new System.Drawing.Point(448, 57);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(88, 20);
            this.decryptButton.TabIndex = 9;
            this.decryptButton.Text = "Расшифоровать";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 461);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "КМЗИ лаб1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox inpFileBox;
        private System.Windows.Forms.TextBox outFileBox;
        private System.Windows.Forms.TextBox outKeysBox;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.Button selectFileDecButton;
        private System.Windows.Forms.Button selectKeyEncButton;
        private System.Windows.Forms.TextBox outDecFileBox;
        private System.Windows.Forms.TextBox encInpFileBox;
        private System.Windows.Forms.TextBox encInpKeyBox;
    }
}

