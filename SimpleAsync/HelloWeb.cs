using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleAsync
{
    class HelloWeb
    {

        public static void RunHelloWeb()
        {

            Console.WriteLine("Press any key to start...");
            Console.ReadKey();

            string url = "http://handsofhopenw.org";

            GetPage(url);
            //GetPageAsync(url);
            //GetPageEffecientAsync(url);

            //GetPageEffecient_v45_Async(url);


            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        }

        private static void GetPageEffecient_v45_Async(string url)
        {
            Task<string> getPage = BetterDownloadWebPage_v45_Async(url);

            while (!getPage.IsCompleted)
            {
                Console.Write(".");
                Thread.Sleep(250);
            }
            Console.WriteLine(getPage.Result);
        }

        private static void GetPageEffecientAsync(string url)
        {
            Task<string> getPage = BetterDownloadWebPageAsync(url);

            while (!getPage.IsCompleted)
            {
                Console.Write(".");
                Thread.Sleep(250);
            }
            Console.WriteLine(getPage.Result);
        }

        private static void GetPageAsync(string url)
        {
            Task<string> getPage = DownloadWebPageAsync(url);

            while (!getPage.IsCompleted)
            {
                Console.Write(".");
                Thread.Sleep(250);
            }
            Console.WriteLine(getPage.Result);
        }

        private static void GetPage(string url)
        {
            Thread.Sleep(1000);
            string page = DownloadWebPage(url);
            Console.WriteLine(page);
        }

        private static Task<string> BetterDownloadWebPage_v45_Async(string url)
        {

            WebRequest request = WebRequest.Create(url);
            Task<WebResponse> responseTask = request.GetResponseAsync();
            WebResponse response = responseTask.Result;
            response.GetResponseStream();

            Task<string> downloadTask = Task.Factory.StartNew<string>(() =>
            {
                Thread.Sleep(1500);
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }

            });
            return downloadTask;
        }

        private static Task<string> BetterDownloadWebPageAsync(string url)
        {
            Thread.Sleep(1000);
            WebRequest request = WebRequest.Create(url);
            IAsyncResult iarWeb = request.BeginGetResponse(null, null);

            Task<string> downloadTask = Task.Factory.FromAsync<string>(iarWeb, iar =>
            {
                using (WebResponse response = request.EndGetResponse(iar))
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        return reader.ReadToEnd();
                    }
                }
            });
            return downloadTask;
        }

        private static Task<string> DownloadWebPageAsync(string url)
        {

            return Task.Factory.StartNew(() => DownloadWebPage(url));

        }

        private static string DownloadWebPage(string url)
        {
            Thread.Sleep(1000);
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            {
                return reader.ReadToEnd();
            }

        }

    }
}
