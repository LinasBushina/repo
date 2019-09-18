using System;
using WUApiLib;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Windows.Forms;

namespace WindowsUpdateCheckerWinForms
{
    public partial class Form1 : Form
    {
        public UpdateSession UpdateSession;

        #region <------- Search Section ------->
        public IUpdateSearcher iUpdateSearcher;
        public ISearchJob iSearchJob;
        public UpdateCollection NewUpdatesCollection;
        public ISearchResult NewUpdatesSearchResult;
        #endregion <------- Search Section ------->

        #region <------- Downloader Section ------->
        public IUpdateDownloader iUpdateDownloader;
        public IDownloadJob iDownloadJob;
        public IDownloadResult iDownloadResult;
        #endregion <------- Downloader Section ------->

        #region <------- Installer Section ------->
        public IUpdateInstaller iUpdateInstaller;
        public IInstallationJob iInstallationJob;
        public IInstallationResult iInstallationResult;
        #endregion <------- Installer Section ------->

        // Declare a Delegate Type for Message Notification...
        public delegate void SendNotification();
        // Create an Instance of Delegate Type...
        public SendNotification sendNotification;

        private int Count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Show - or Hide...
            this.Show();
            // Encapsulate the setTextBox1 Method in Delegate SendNotification...
            sendNotification = new SendNotification(setTextBox1);
            // Set Text Box Value...
            this.toolStripStatusLabel1.Text = "Enabling Update Services...";
            // Set Text Box Value...
            this.toolStripStatusLabel2.Text = "";
            // Lets check Windows is up to that task...
            EnableServicesWorker.RunWorkerAsync();
        }

        private void EnableServicesWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get Services Collection...
            ServiceController[] serviceController;
            serviceController = ServiceController.GetServices();

            // Loop through and check for a particular Service...
            foreach (ServiceController scTemp in serviceController)
            {
                switch (scTemp.DisplayName)
                {
                    case "Windows Update":
                        RestartService(scTemp.DisplayName, 5000);
                        break;
                    case "Automatic Updates":
                        RestartService(scTemp.DisplayName, 5000);
                        break;
                    default:
                        break;
                }
            }

            // Check for iAutomaticUpdates.ServiceEnabled...
            IAutomaticUpdates iAutomaticUpdates = new AutomaticUpdates();
            if (!iAutomaticUpdates.ServiceEnabled)
            {
                iAutomaticUpdates.EnableService();
            }
        }

        private void EnableServicesWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.toolStripStatusLabel1.Text = "Searching for updates...";

            iUpdateSearch();
        }

        public static void RestartService(string serviceName, int timeoutMilliseconds)
        {
            ServiceController serviceController = new ServiceController(serviceName);
            try
            {
                int millisec1 = Environment.TickCount;
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                serviceController.Stop();
                serviceController.WaitForStatus(ServiceControllerStatus.Stopped, timeout);

                // count the rest of the timeout
                int millisec2 = Environment.TickCount;
                timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds - (millisec2 - millisec1));

                serviceController.Start();
                serviceController.WaitForStatus(ServiceControllerStatus.Running, timeout);
            }
            catch
            {
                // ...
            }
        }

        #region <------- Search Methods ------->

        private void iUpdateSearch()
        {
            UpdateSession = new UpdateSession();
            iUpdateSearcher = UpdateSession.CreateUpdateSearcher();

            // Only Check Online..
            iUpdateSearcher.Online = true;

            // Begin Asynchronous IUpdateSearcher...
            iSearchJob = iUpdateSearcher.BeginSearch("IsInstalled=0 AND IsPresent=0", new iUpdateSearcher_onCompleted(this), new iUpdateSearcher_state(this));
        }

        private void iUpdateSearchComplete(Form1 mainform)
        {
            Form1 formRef = mainform;

            // Declare a new UpdateCollection and populate the result...
            NewUpdatesCollection = new UpdateCollection();
            NewUpdatesSearchResult = iUpdateSearcher.EndSearch(iSearchJob);

            Count = NewUpdatesSearchResult.Updates.Count;
            formRef.Invoke(formRef.sendNotification);

            // Accept Eula code for each update
            for (int i = 0; i < NewUpdatesSearchResult.Updates.Count; i++)
            {
                IUpdate iUpdate = NewUpdatesSearchResult.Updates[i];

                if (iUpdate.EulaAccepted == false)
                {
                    iUpdate.AcceptEula();
                }

                NewUpdatesCollection.Add(iUpdate);
            }

            foreach (IUpdate update in NewUpdatesSearchResult.Updates)
            {
                textBox1.AppendText(update.Title + Environment.NewLine);
            }

            if (NewUpdatesSearchResult.Updates.Count > 0)
            {
                iUpdateDownload();
            }
        }

        #endregion <------- Search Methods ------->

        #region <------- Downloader Methods ------->

        private void iUpdateDownload()
        {
            UpdateSession = new UpdateSession();
            iUpdateDownloader = UpdateSession.CreateUpdateDownloader();

            iUpdateDownloader.Updates = NewUpdatesCollection;
            iUpdateDownloader.Priority = DownloadPriority.dpHigh;
            iDownloadJob = iUpdateDownloader.BeginDownload(new iUpdateDownloader_onProgressChanged(this), new iUpdateDownloader_onCompleted(this), new iUpdateDownloader_state(this));
        }

        public void iDownloadComplete()
        {
            iDownloadResult = iUpdateDownloader.EndDownload(iDownloadJob);
            if (iDownloadResult.ResultCode == OperationResultCode.orcSucceeded)
            {
                this.toolStripStatusLabel1.Text = "Installing Updates...";

                iInstallation();
            }
            else
            {
                string message = "The Download has failed: " + iDownloadResult.ResultCode + ". Please check your     internet connection then Re-Start the application.";
                string caption = "Download Failed!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(message, caption, buttons, icon);

                Application.Exit();
            }
        }

        #endregion <------- Downloader Methods ------->

        #region <------- Installation Methods ------->

        public void iInstallation()
        {
            iUpdateInstaller = UpdateSession.CreateUpdateInstaller() as IUpdateInstaller;
            iUpdateInstaller.Updates = this.NewUpdatesCollection;

            iInstallationJob = iUpdateInstaller.BeginInstall(new iUpdateInstaller_onProgressChanged(this), new iUpdateInstaller_onCompleted(this), new iUpdateInstaller_state(this));
        }

        public void iInstallationComplete()
        {
            iInstallationResult = iUpdateInstaller.EndInstall(iInstallationJob);
            if (iInstallationResult.ResultCode == OperationResultCode.orcSucceeded)
            {
                this.toolStripStatusLabel1.Text = "Installation Complete...";
            }
            else
            {
                string message = "The Installation has failed: " + iInstallationResult.ResultCode + ".";
                string caption = "DownInstallationload Failed!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBox.Show(message, caption, buttons, icon);

                Application.Exit();
            }
        }
        #endregion <------- Installation Methods ------->

        #region <------- Notification Methods ------->
        public void setTextBox1()
        { toolStripStatusLabel1.Text = Count + " Updates found..."; }

        public void setTextBox1Notification(string txt)
        { toolStripStatusLabel1.Text = txt; }

        public void setTextBox2Notification(string txt)
        { toolStripStatusLabel2.Text = txt; }
        #endregion <------- Notification Methods ------->
    }
}
