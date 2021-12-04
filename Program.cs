using System.Runtime.Serialization.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;

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

            var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);
            foreach (var repo in repositories)
            {
                Console.WriteLine(repo.Name);
            }

        }

        static async Task Main(string[] args)
        {
            await ProcessRepositories();
            
        }
    }
}
