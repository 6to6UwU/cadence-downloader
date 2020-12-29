
using System;
using System.Drawing;

namespace cadence_downloader
{
    class Program
    {
        public static System.Drawing.Image DownloadImageFromUrl(string imageUrl)
        {
            System.Drawing.Image image = null;

            try
            {
                System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(imageUrl);
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.Timeout = 30000;

                System.Net.WebResponse webResponse = webRequest.GetResponse();

                System.IO.Stream stream = webResponse.GetResponseStream();

                image = System.Drawing.Image.FromStream(stream);

                webResponse.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("error 0x2");
            }

            return image;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter Download iamge link: ");
            string myRoot = Console.ReadLine();
            try
            {
                System.Drawing.Image image = DownloadImageFromUrl(myRoot );
                string rootPath = string.Empty;
                string fileName = System.IO.Path.Combine(rootPath, "dupI" + ".png");
                image.Save(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("greshka choveshka");

            }


            Console.ReadKey();
        }
    }
}
