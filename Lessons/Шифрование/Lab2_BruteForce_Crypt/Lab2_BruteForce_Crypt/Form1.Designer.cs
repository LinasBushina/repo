namespace Lab2_BruteForce_Crypt
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
            this.encInpFileBox = new System.Windows.Forms.TextBox();
            this.selectFileDecButton = new System.Windows.Forms.Button();
            this.decryptButton = new System.Windows.Forms.Button();
            this.dictBox = new System.Windows.Forms.TextBox();
            this.dictBtn = new System.Windows.Forms.Button();
            this.limitUpDown = new System.Windows.Forms.NumericUpDown();
            this.limitLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.limitUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // encInpFileBox
            // 
            this.encInpFileBox.Location = new System.Drawing.Point(12, 38);
            this.encInpFileBox.Name = "encInpFileBox";
            this.encInpFileBox.Size = new System.Drawing.Size(421, 20);
            this.encInpFileBox.TabIndex = 9;
            // 
            // selectFileDecButton
            // 
            this.selectFileDecButton.Location = new System.Drawing.Point(439, 38);
            this.selectFileDecButton.Name = "selectFileDecButton";
            this.selectFileDecButton.Size = new System.Drawing.Size(106, 20);
            this.selectFileDecButton.TabIndex = 10;
            this.selectFileDecButton.Text = "Выбрать файл";
            this.selectFileDecButton.UseVisualStyleBackColor = true;
            this.selectFileDecButton.Click += new System.EventHandler(this.selectFileDecButton_Click);
            // 
            // decryptButton
            // 
            this.decryptButton.Location = new System.Drawing.Point(551, 37);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(88, 20);
            this.decryptButton.TabIndex = 11;
            this.decryptButton.Text = "Взломать";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // dictBox
            // 
            this.dictBox.Location = new System.Drawing.Point(12, 12);
            this.dictBox.Name = "dictBox";
            this.dictBox.Size = new System.Drawing.Size(421, 20);
            this.dictBox.TabIndex = 12;
            // 
            // dictBtn
            // 
            this.dictBtn.Location = new System.Drawing.Point(439, 12);
            this.dictBtn.Name = "dictBtn";
            this.dictBtn.Size = new System.Drawing.Size(106, 20);
            this.dictBtn.TabIndex = 13;
            this.dictBtn.Text = "Выбрать словарь";
            this.dictBtn.UseVisualStyleBackColor = true;
            this.dictBtn.Click += new System.EventHandler(this.dictBtn_Click);
            // 
            // limitUpDown
            // 
            this.limitUpDown.DecimalPlaces = 1;
            this.limitUpDown.Location = new System.Drawing.Point(598, 14);
            this.limitUpDown.Name = "limitUpDown";
            this.limitUpDown.Size = new System.Drawing.Size(41, 20);
            this.limitUpDown.TabIndex = 14;
            this.limitUpDown.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // limitLabel
            // 
            this.limitLabel.AutoSize = true;
            this.limitLabel.Location = new System.Drawing.Point(551, 16);
            this.limitLabel.Name = "limitLabel";
            this.limitLabel.Size = new System.Drawing.Size(41, 13);
            this.limitLabel.TabIndex = 15;
            this.limitLabel.Text = "Порог:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 67);
            this.Controls.Add(this.limitLabel);
            this.Controls.Add(this.limitUpDown);
            this.Controls.Add(this.dictBtn);
            this.Controls.Add(this.dictBox);
            this.Controls.Add(this.decryptButton);
            this.Controls.Add(this.selectFileDecButton);
            this.Controls.Add(this.encInpFileBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.limitUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox encInpFileBox;
        private System.Windows.Forms.Button selectFileDecButton;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.TextBox dictBox;
        private System.Windows.Forms.Button dictBtn;
        private System.Windows.Forms.NumericUpDown limitUpDown;
        private System.Windows.Forms.Label limitLabel;
    }
}

