using System;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;

namespace DownloadBot
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] RemoteURls = { "http://200.152.38.155/CNPJ/DADOS_ABERTOS_CNPJ_01.zip" };

            string FileDownloadPlacementPath = @"C:\Users\gabri\source\repos\DownloadBot\DownloadBot\FileDownload\";

            string ExtrationPath = @"C:\Users\gabri\source\repos\DownloadBot\DownloadBot\ExtractionFolder\";

            string TextPath = @"C:\Users\gabri\source\repos\DownloadBot\DownloadBot\InformationFolder\";

            int count = 1;

            if (!File.Exists(ExtrationPath))
            {
                Directory.CreateDirectory(ExtrationPath);
            }

            if (!File.Exists(TextPath))
            {
                Directory.CreateDirectory(TextPath);
            }

            if (!File.Exists(FileDownloadPlacementPath))
            {
                Directory.CreateDirectory(FileDownloadPlacementPath);
            }

            using (WebClient downloadBot = new WebClient())
            {
                foreach (string link in RemoteURls)
                {
                    if (File.Exists(FileDownloadPlacementPath + "/" + "CNPJ_Aberto_" + count + ".zip"))
                    {
                        Console.WriteLine("Found: " + "CNPJ_Aberto_" + count + ".zip");
                        count++;
                    }
                    else
                    {
                        Console.WriteLine("Initializing Download from: " + link);
                        downloadBot.DownloadFile(link, FileDownloadPlacementPath + "CNPJ_Aberto_" + count + ".zip");
                        Console.WriteLine("Download Complete");
                        count++;
                    }
                }
            }

            string[] ZipFiles = Directory.GetFiles(FileDownloadPlacementPath);

            foreach(string files in ZipFiles)
            {
                Console.WriteLine("Extracting From: " + files);
                ZipFile.ExtractToDirectory(files, ExtrationPath,true);
                Console.WriteLine("Extraction Complete check: " + ExtrationPath);
            }
        }
    }
}
