using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.IO.Compression.GZipStream;
using System.Resources;
using Ionic.Zip;

namespace brootforce
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string startPath = @".\start";
            string zipPath = @".\result.zip";
            string extractPath = @".\extract";

            ZipFile.CreateFromDirectory(startPath, zipPath);

            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}
