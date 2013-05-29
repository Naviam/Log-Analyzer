namespace Naviam.DataGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            const int Sleep = 5;
            while (true)
            {
                PostData();
                Thread.Sleep(Sleep * 1000);
            }
        }

        public static void PostData()
        {
            var url = new Uri(@"http://localhost:6740");
            using (var client = new HttpClient())
            {
                try
                {
                    var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("1", "login") });
                    var result = client.PostAsync(url, content).Result;
                    string resultContent = result.Content.ReadAsStringAsync().Result;
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
