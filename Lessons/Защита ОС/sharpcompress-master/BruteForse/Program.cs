using System.IO;
using SharpCompress.Common;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using SharpCompress.Readers;

namespace BruteForse
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Stream stream = File.OpenRead("ar.rar"))
            using (var archive = RarArchive.Open(stream, new ReaderOptions()
            {
                Password = "hello",
                LeaveStreamOpen = true
            }))
            {
                foreach (var entry in archive.Entries)
                {
                    
                    if (!entry.IsDirectory)
                    {
                        if (CompressionType.Rar == entry.CompressionType)
                        {
                            System.Console.WriteLine("Extention correct");
                        }
                        else
                        {
                            System.Console.WriteLine("Extention NOT correct!");
                        }
                        entry.WriteToDirectory(".", new ExtractionOptions()
                        {
                            ExtractFullPath = true,
                            Overwrite = true
                        });
                    }
                }
            }
        }
    }
}
