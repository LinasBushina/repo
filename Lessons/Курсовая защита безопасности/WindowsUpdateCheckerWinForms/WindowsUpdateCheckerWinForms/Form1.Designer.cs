namespace WindowsUpdateCheckerWinForms
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
            this.toolStripStatusLabel1 = new System.Windows.Forms.Label();
            this.toolStripStatusLabel2 = new System.Windows.Forms.Label();
            this.EnableServicesWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = true;
            this.toolStripStatusLabel1.Location = new System.Drawing.Point(13, 13);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(67, 13);
            this.toolStripStatusLabel1.TabIndex = 0;
            this.toolStripStatusLabel1.Text = "Update label";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = true;
            this.toolStripStatusLabel2.Location = new System.Drawing.Point(12, 47);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(100, 13);
            this.toolStripStatusLabel2.TabIndex = 1;
            this.toolStripStatusLabel2.Text = "Label below update";
            // 
            // EnableServicesWorker
            // 
            this.EnableServicesWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.EnableServicesWorker_DoWork);
            this.EnableServicesWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.EnableServicesWorker_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStripStatusLabel2);
            this.Controls.Add(this.toolStripStatusLabel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label toolStripStatusLabel1;
        private System.Windows.Forms.Label toolStripStatusLabel2;
        private System.ComponentModel.BackgroundWorker EnableServicesWorker;
    }
}

