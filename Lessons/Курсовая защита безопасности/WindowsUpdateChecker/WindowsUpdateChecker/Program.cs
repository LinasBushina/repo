using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WUApiLib;

namespace WindowsUpdateChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            //Type USType = Type.GetTypeFromProgID("Microsoft.Update.Session");
            //dynamic updateSession = Activator.CreateInstance(USType);
            //Type USMType = Type.GetTypeFromProgID("Microsoft.Update.ServiceManager");
            //dynamic updateServiceManager = Activator.CreateInstance(USMType);
            //dynamic updateService = updateServiceManager.AddScanPackageService("Offline Sync Service", "c:\\wsusscn2.cab", 1);

            //Console.WriteLine("123");

            UpdateSession uSession = new UpdateSession();
            IUpdateSearcher uSearcher = uSession.CreateUpdateSearcher();
            uSearcher.Online = false;
            try
            {
                ISearchResult sResult = uSearcher.Search("IsInstalled=1 And IsHidden=0");
                string text = "Found " + sResult.Updates.Count + " updates" + Environment.NewLine;
                foreach (IUpdate update in sResult.Updates)
                {
                    text += update.Title + Environment.NewLine;
                }
                Console.WriteLine(text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
        }
    }
}
