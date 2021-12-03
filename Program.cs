using System.Net.Http.Headers;
using System.Net.Http;
using System;
using System.Threading.Tasks;

namespace console_weatherapp
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var stringTask = client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");

            var msg = await stringTask;
            Console.WriteLine(msg);

        }

        static async Task Main(string[] args)
        {
            await ProcessRepositories();
            
        }
    }
}
