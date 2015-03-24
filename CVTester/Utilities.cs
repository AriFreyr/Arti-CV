using System;
using System.Net;
using System.IO;
using System.Drawing;

namespace CVTester
{
    public class Utilities
    {
        public static System.Drawing.Image GetImageFromUrl(string url)
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
                        return System.Drawing.Image.FromStream(stream);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception in GetImageFromUrl: " + e.Message);
            }
            return null;
        }

    }
}
