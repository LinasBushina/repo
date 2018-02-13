using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;

namespace PasswordDoc
{
    public partial class Form1 : Form
    {
        private string fileName = null;
        private string password = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "doc files (*.doc,*.docx)|*.doc;*.docx";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            { fileName = openFileDialog1.FileName; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Protect()
        {
            var app = new Microsoft.Office.Interop.Word.Application();
            Document doc = null;

            object missing = System.Reflection.Missing.Value;
            object readOnly = false;
            object visible = false;
            object _Password = password;
            object fileToOpen = fileName;
            object enforceStyleLock = false;
            try
            {
                app.Visible = false;
                doc = app.Documents.Open(
                                         ref fileToOpen,
                                         ref missing,
                                         ref readOnly,
                                         ref missing,
                                         ref _Password,
                                         ref missing,
                                         ref missing,
                                         ref missing,
                                         ref missing,
                                         ref missing,
                                         ref missing,
                                         ref visible,
                                         ref visible,
                                         ref missing,
                                         ref missing,
                                         ref missing);

                doc.Activate();
                doc.Password = password;
                doc.Protect(WdProtectionType.wdAllowOnlyReading,
                                ref missing,
                                ref _Password,
                                ref missing,
                                ref enforceStyleLock);
                doc.ReadOnlyRecommended = false;
                doc.SaveAs(ref fileToOpen,
                            ref missing,
                            ref missing,
                            ref _Password,
                            ref missing,
                            ref _Password,
                            ref enforceStyleLock,
                            ref missing,
                            ref missing,
                            ref missing,
                            ref missing,
                            ref missing,
                            ref missing,
                            ref missing,
                            ref missing,
                            ref missing);
                ((_Document)doc).Close(ref missing, ref missing, ref missing);
                ((_Application)app).Quit(ref missing, ref missing, ref missing);
            }
            catch (System.Exception ex)
            {
                if (ex.GetType().FullName != "System.Exception")
                {
                    if (((ExternalException)(ex)).ErrorCode == -2146822880)
                    { throw new Exception("Document is password protected"); }
                    else throw ex; 
                }
                else throw ex; 
            }
            finally
            {
                if (doc != null) Marshal.ReleaseComObject(doc);
                if (app != null) Marshal.ReleaseComObject(app);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (fileName == null) MessageBox.Show("Chooce a file");
            else if (textBox1.Text == "") MessageBox.Show("Enter a password");
            else
            {
                password = textBox1.Text;
                Protect();
                MessageBox.Show("File " + fileName + " protected");
            }
        }

        public void UnProtect()
        {
            var app = new Microsoft.Office.Interop.Word.Application();
            Document doc = null;

            object missing = System.Reflection.Missing.Value;
            object readOnly = false;
            object visible = true;
            object _Password = password;
            object fileToOpen = fileName;

            try
            {
                doc = app.Documents.Open(
                                               ref fileToOpen,
                                               ref missing,
                                               ref readOnly,
                                               ref missing,
                                               ref _Password,
                                               ref missing,
                                               ref missing,
                                               ref _Password,
                                               ref missing,
                                               ref missing,
                                               ref missing,
                                               ref visible,
                                               ref visible,
                                               ref missing,
                                               ref missing,
                                               ref missing);
                doc.Activate();
                //doc.Password = passWord;
                object enforceStyleLock = false;
                doc.Protect(WdProtectionType.wdAllowOnlyReading,
                                ref missing,
                                ref _Password,
                                ref missing,
                                ref enforceStyleLock);
                doc.Unprotect(ref _Password);
                doc.SaveAs(ref fileToOpen,
                            ref missing,
                            ref missing,
                            ref missing,
                            ref missing,
                            ref _Password,
                            ref missing,
                            ref missing,
                            ref missing,
                            ref missing,
                            ref missing,
                            ref missing,
                            ref missing,
                            ref missing,
                            ref missing,
                            ref missing);
                ((_Document)doc).Close(ref missing, ref missing, ref missing);
                //((_Document)doc).Close(Word.WdSaveOptions.wdDoNotSaveChanges);
                Marshal.ReleaseComObject(doc);
                Marshal.ReleaseComObject(app);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (doc != null)
                    Marshal.ReleaseComObject(doc);
                Marshal.ReleaseComObject(app);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fileName == null) MessageBox.Show("Chooce a file");
            else if (textBox1.Text == "") MessageBox.Show("Enter a password");
            else
            {
                password = textBox1.Text;
                UnProtect();
                MessageBox.Show("File " + fileName + " unprotected");
            }
        }
    }
}
