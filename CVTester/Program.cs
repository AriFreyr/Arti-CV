using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using CVTester.DAL;
using Newtonsoft.Json;
using CVTester.Models;
using Image = System.Drawing.Image;

namespace CVTester
{
    class Program
    {
        const string GoogleApiKey = "AIzaSyC3E6KWp9rLiIt3mVG4CsABiZcafO7456A";
        const string SearchEngineCx = "015363661733912743555:c60m6j8qy2o";
        static void Main(string[] args)
        {
            var imageTypes = new[] {"car", "laptop", "phone"};
            var db = new ImageContext();
            var count = 1;

            while (db.Image.Count() < 150)
            {
                var requestUrl = CreateRequest(imageTypes[2], count);
                var response = MakeRequest(requestUrl);
                count = response.queries.nextPage[0].count;
                foreach (var item in response.items)
                {
                    try
                    {
                        var img = Utilities.GetImageFromUrl(item.link);

                        if (img != null)
                        {
                            db.Image.Add(new ImageData
                            {
                                Image = Utilities.ImageToByteArray(img),
                                Link = item.link,
                                Type = "phone"
                            });
                            db.SaveChanges();
                        }
                    }
                    catch (WebException e)
                    {
                        Console.WriteLine("Could not reach: " + item.link + " " + e.Message);
                    }
                }
            }
        }

        public static string CreateRequest(string query, int count)
        {
            var reqeustString = "https://www.googleapis.com/customsearch/v1?key="
                                + GoogleApiKey + "&cx=" + SearchEngineCx + "&q=" + query
                                + "&searchType=image" + "&start=" + count+ "&imgSize=medium";

            return reqeustString;
        }

        public static Response MakeRequest(string requestUrl)
        {
            var request = (HttpWebRequest) WebRequest.Create(requestUrl);
            using (var response = (HttpWebResponse) request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(String.Format(
                                            "Server error (HTTP {0}: {1}).",
                                        response.StatusCode,
                    response.StatusDescription));
                }
                var serializer = new JsonSerializer();

                Response result;
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    result = (Response)serializer.Deserialize(reader, typeof(Response));
                }

                return result;

            }
        }
    }
}
