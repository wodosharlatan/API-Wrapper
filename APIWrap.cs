using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API_Wrapper
{
    public class API
    {
        private HttpClient client;

        public API(string apiKey)
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);
        }

        public async Task<string?> CreateNewUser(string username, string password)
        {
            var data = new { username, password };
            string json = JsonConvert.SerializeObject(data);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://rest-api-db.up.railway.app/new-user", content);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            Console.WriteLine("Error: " + response.StatusCode);
            return null;
        }

        public async Task<string?> Login(string username, string password)
        {
            var data = new { username, password };
            string json = JsonConvert.SerializeObject(data);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://rest-api-db.up.railway.app/login", content);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            Console.WriteLine("Error: " + response.StatusCode);
            return null;
        }

        public async Task<string?> GetAllEntries(string token)
        {
            var data = new { token };
            string json = JsonConvert.SerializeObject(data);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://rest-api-db.up.railway.app/entries", content);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            Console.WriteLine("Error: " + response.StatusCode);
            return null;
        }

        public async Task<string?> GetSpecificEntry(string token, int entryID)
        {
            var data = new { token };
            string json = JsonConvert.SerializeObject(data);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://rest-api-db.up.railway.app/entries/" + Convert.ToString(entryID), content);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            Console.WriteLine("Error: " + response.StatusCode);
            return null;
        }

        public async Task<string?> DeleteSpecificEntry(string token, int entryID)
        {
            var data = new { token };
            string json = JsonConvert.SerializeObject(data);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://rest-api-db.up.railway.app/delete-entry/" + Convert.ToString(entryID), content);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            Console.WriteLine("Error: " + response.StatusCode);
            return null;
        }

        public async Task<string?> UpdateSpecificEntry(string token, int entryID, string ProductName, string Unit, int Count)
        {
            var data = new { token, ProductName, Unit, Count };
            string json = JsonConvert.SerializeObject(data);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(43, 1);
            defaultInterpolatedStringHandler.AppendLiteral("https://rest-api-db.up.railway.app/entries/");
            defaultInterpolatedStringHandler.AppendFormatted(entryID);
            HttpRequestMessage request = new HttpRequestMessage(requestUri: defaultInterpolatedStringHandler.ToStringAndClear(), method: new HttpMethod("PATCH"))
            {
                Content = content
            };
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            Console.WriteLine("Error: " + response.StatusCode);
            return null;
        }

        public async Task<string?> CreateNewEntry(string token, string productName, string unit, int count)
        {
            var data = new { token, productName, unit, count };
            string json = JsonConvert.SerializeObject(data);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("https://rest-api-db.up.railway.app/new-entry", content);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            Console.WriteLine("Error: " + response.StatusCode);
            return null;
        }
    }
}
