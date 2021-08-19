using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ConsoleTables;

namespace OneListClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            var responseBodyAsAStream = await client.GetStreamAsync("https://one-list-api.herokuapp.com/items?access_token=drew-wilson");

            var items = await JsonSerializer.DeserializeAsync<List<Item>>(responseBodyAsAStream);

            var table = new ConsoleTable("Text");

            foreach (var item in items)
            {
                table.AddRow(item.Text);
            }

            table.Write();
        }
    }
}
