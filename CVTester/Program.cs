using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CVTester
{
    class Program
    {
        const string GoogleApiKey = "AIzaSyC3E6KWp9rLiIt3mVG4CsABiZcafO7456A";
        const string SearchEngineCx = "015363661733912743555:c60m6j8qy2o";
        static void Main(string[] args)
        {
            try
            {
                var imageTypes = new[] {"car", "laptop", "phone"};
                var requestUrl = CreateRequest(imageTypes[0]);
                var response = MakeRequest(requestUrl);

                foreach (var item in response.items)
                {
                    Console.WriteLine(item.link);
                }
                Console.Read();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static string CreateRequest(string query)
        {
            var reqeustString = "https://www.googleapis.com/customsearch/v1?key="
                                + GoogleApiKey + "&cx=" + SearchEngineCx + "&q=" + query
                                + "&searchType=image";

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
