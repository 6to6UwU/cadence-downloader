
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
			Console.WriteLine("Enter ID (default 13): ");
			int myID = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Enter Download Destination: ");
			string myRoot = Console.ReadLine();
			System.Net.WebClient wc = new System.Net.WebClient();
			byte[] raw = wc.DownloadData("https://cadence.moe/api/images");
			string webData = System.Text.Encoding.UTF8.GetString(raw);
			for (int i = myID; i < 4194304; i+=86)
			{
				try
				{
					Console.WriteLine(webData.Substring(i, 6));
					System.Drawing.Image image = DownloadImageFromUrl("https://cadence.moe/api/images/" + webData.Substring(i, 6));
				    string rootPath = myRoot;
				    string fileName = System.IO.Path.Combine(rootPath, i + ".png");
				    image.Save(fileName);
				}
				catch(Exception ex)
				{
					Console.WriteLine("error 0x1");
				}
			}
			Console.ReadKey();
		}
	}
}
