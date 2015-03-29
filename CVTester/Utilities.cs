using System;
using System.IO;
using System.Net;
using Image = System.Drawing.Image;

namespace CVTester
{
    public class Utilities
    {
        public static Image GetImageFromUrl(string url)
        {
            var httpWebRequest = (HttpWebRequest) WebRequest.Create(url);

            try
            {
                using (var httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse())
                {
                    using (Stream stream = httpWebResponse.GetResponseStream())
                    {
                        if (stream == null)
                        {
                            throw new ArgumentNullException(url);
                        }
                        return Image.FromStream(stream);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in GetImageFromUrl: " + e.Message);
            }
            return null;
        }

        public static byte[] ImageToByteArray(Image img)
        {
            var ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        public static string GetClassFromInt(int c)
        {
            switch (c)
            {
                case 0:
                    return "car";
                case 1:
                    return "laptop";
                case 2:
                    return "bicycle";
                default:
                    return null;
            }
        }

        public static int GetIntFromClass(string c)
        {
            switch (c)
            {
                case "car":
                    return 0;
                case "laptop":
                    return 1;
                case "bicycle":
                    return 2;
                default:
                    return 100000;
            }
        }

    }
}
