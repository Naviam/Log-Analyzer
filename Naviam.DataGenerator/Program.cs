namespace Naviam.DataGenerator
{
    using System;
    using System.Configuration;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Web.Script.Serialization;

    class Program
    {
        static void Main()
        {
            int sleep;
            int.TryParse(ConfigurationManager.AppSettings["sleep"] ?? "1000", out sleep);
            
            while (true)
            {
                PostData(ConfigurationManager.AppSettings["url_host"] ?? string.Empty);
                Thread.Sleep(sleep);
            }
        }

        public static void PostData(string url)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var json = new JavaScriptSerializer().Serialize(TestMessage.GetRandomInstance());
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var result = client.PostAsync(url, content).Result;
                    var resultContent = result.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(resultContent);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
