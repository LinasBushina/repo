﻿using System;
using WUApiLib;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.ServiceProcess;
using System.Collections.Generic;

namespace Windows_Update_Automation
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

        private int count = 0;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

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
        {
            toolStripStatusLabel1.Text = Count + " Updates found...";
        }

        public void setTextBox1Notification(string txt)
        {
            toolStripStatusLabel1.Text = txt;
        }

        public void setTextBox2Notification(string txt)
        {
            toolStripStatusLabel2.Text = txt;
        }

        #endregion <------- Notification Methods ------->

        #region <------- iUpdateSearcher.BeginDownload Object Abstract Class's ------->
        // onCompleted [in] 
        // An ISearchCompletedCallback interface that is called when an asynchronous search operation is complete.
        public class iUpdateSearcher_onCompleted : ISearchCompletedCallback
        {
            private Form1 form1;

            public iUpdateSearcher_onCompleted(Form1 mainForm)
            {
                this.form1 = mainForm;
            }

            // Implementation of IDownloadCompletedCallback interface...
            public void Invoke(ISearchJob searchJob, ISearchCompletedCallbackArgs e)
            {
                form1.iUpdateSearchComplete(this.form1);
            }
        }

        // state [in] 
        // The caller-specific state that is returned by the AsyncState property of the ISearchJob interface.
        public class iUpdateSearcher_state
        {
            private Form1 form1;

            // Implementation of state interface...
            public iUpdateSearcher_state(Form1 mainForm)
            {
                this.form1 = mainForm;

                form1.setTextBox2Notification("State: Search Started...");
            }
        }

        #endregion <------- iUpdateSearcher.BeginDownload Object Abstract Class's ------->

        #region <------- iUpdateDownloader.BeginDownload Object Abstract Class's ------->
        // onProgressChanged [in] 
        // An IDownloadProgressChangedCallback interface that is called periodically for download progress changes before download is complete.
        public class iUpdateDownloader_onProgressChanged : IDownloadProgressChangedCallback
        {
            private Form1 form1;

            public iUpdateDownloader_onProgressChanged(Form1 mainForm)
            {
                this.form1 = mainForm;
            }

            // Implementation of IDownloadProgressChangedCallback interface...
            public void Invoke(IDownloadJob downloadJob, IDownloadProgressChangedCallbackArgs e)
            {

                decimal bDownloaded = ((e.Progress.TotalBytesDownloaded / 1024) / 1024);
                decimal bToDownloaded = ((e.Progress.TotalBytesToDownload / 1024) / 1024);
                bDownloaded = decimal.Round(bDownloaded, 2);
                bToDownloaded = decimal.Round(bToDownloaded, 2);

                form1.setTextBox1Notification("Downloading Update: "
                 + e.Progress.CurrentUpdateIndex
                 + "/"
                 + downloadJob.Updates.Count
                 + " - "
                 + bDownloaded + "Mb"
                 + " / "
                 + bToDownloaded + "Mb");
            }
        }

        // onCompleted [in] 
        // An IDownloadCompletedCallback interface (C++/COM) that is called when an asynchronous download operation is complete.
        public class iUpdateDownloader_onCompleted : IDownloadCompletedCallback
        {
            private Form1 form1;

            public iUpdateDownloader_onCompleted(Form1 mainForm)
            {
                this.form1 = mainForm;
            }

            // Implementation of IDownloadCompletedCallback interface...
            public void Invoke(IDownloadJob downloadJob, IDownloadCompletedCallbackArgs e)
            {
                form1.iDownloadComplete();
            }
        }

        // state [in] 
        // The caller-specific state that the AsyncState property of the IDownloadJob interface returns. 
        // A caller may use this parameter to attach a value to the download job object. 
        // This allows the caller to retrieve custom information about that download job object at a later time.
        public class iUpdateDownloader_state
        {
            private Form1 form1;

            // Implementation of state interface...
            public iUpdateDownloader_state(Form1 mainForm)
            {
                this.form1 = mainForm;

                form1.setTextBox2Notification("State: Download Started...");
            }
        }

        #endregion <------- iUpdateDownloader.BeginDownload Objects ------->

        #region <------- iUpdateInstaller.BeginInstall Object Abstract Class's ------->
        // onProgressChanged [in] 
        // An IDownloadProgressChangedCallback interface that is called periodically for download progress changes before download is complete.
        public class iUpdateInstaller_onProgressChanged : IInstallationProgressChangedCallback
        {
            private Form1 form1;

            public iUpdateInstaller_onProgressChanged(Form1 mainForm)
            {
                this.form1 = mainForm;
            }

            // Implementation of IDownloadProgressChangedCallback interface...
            public void Invoke(IInstallationJob iInstallationJob, IInstallationProgressChangedCallbackArgs e)
            {
                form1.setTextBox1Notification("Installing Update: "
                 + e.Progress.CurrentUpdateIndex
                 + " / "
                 + iInstallationJob.Updates.Count
                 + " - "
                 + e.Progress.CurrentUpdatePercentComplete + "% Complete");
            }
        }

        // onCompleted [in] 
        // An IDownloadCompletedCallback interface (C++/COM) that is called when an asynchronous download operation is complete.
        public class iUpdateInstaller_onCompleted : IInstallationCompletedCallback
        {
            private Form1 form1;

            public iUpdateInstaller_onCompleted(Form1 mainForm)
            {
                this.form1 = mainForm;
            }

            // Implementation of IDownloadCompletedCallback interface...
            public void Invoke(IInstallationJob iInstallationJob, IInstallationCompletedCallbackArgs e)
            {
                form1.iInstallationComplete();
            }
        }

        // state [in] 
        // The caller-specific state that the AsyncState property of the IDownloadJob interface returns. 
        // A caller may use this parameter to attach a value to the download job object. 
        // This allows the caller to retrieve custom information about that download job object at a later time.
        public class iUpdateInstaller_state
        {
            private Form1 form1;

            // Implementation of state interface...
            public iUpdateInstaller_state(Form1 mainForm)
            {
                this.form1 = mainForm;

                form1.setTextBox2Notification("State: Installation Started...");
            }
        }

        #endregion <------- iUpdateInstaller.BeginInstall Objects ------->

    }
}