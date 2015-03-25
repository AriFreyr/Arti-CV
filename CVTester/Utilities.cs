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
                    using (var stream = httpWebResponse.GetResponseStream())
                    {
                        if (stream == null)
                        {
                            throw new ArgumentNullException(url);
                        }
                        return Image.FromStream(stream);
                    }
                }
            }
            catch (WebException e)
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

    }
}
