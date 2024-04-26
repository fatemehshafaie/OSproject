using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace IDM
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> links = new List<string>
            {
                "https://dl.musicdel.ir/tag/music/1403/02/04/Arman%20Garshasbi%20-%20Az%20To%20Goftam%20Piano%20Version%20(128).mp3",
                "https://dl.musicdel.ir/tag/music/1403/02/04/Sina%20Derakhshandeh%20-%20Baroon%20Baroone%20(128).mp3",
                "https://dl.musicdel.ir/tag/music/1403/02/06/Farzad%20Farzin%20-%20Ghotbe%20Shomal%20(128).mp3"
            };

            DownloadFiles(links);

            Console.WriteLine("files successfully downloded !!");
            Console.ReadKey();
        }

        static void DownloadFiles(List<string> links)
        {
            List<Thread> threads = new List<Thread>();
            Console.WriteLine("loading...");
            foreach (string link in links)
            {
                Thread thread = new Thread(() =>
                {
                    string fileName = GetFileNameFromUrl(link);
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(link, fileName);
                    }

                    Console.WriteLine($"{fileName} : 100% downloaded");
                });

                threads.Add(thread);
                thread.Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }
        }

        static string GetFileNameFromUrl(string url)
        {
            Uri uri = new Uri(url);
            return uri.Segments[^1];
        }
    }
}