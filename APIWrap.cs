using Newtonsoft.Json;

namespace Nugge__Test
{
    public class APIWrap
    {
        private string APIKEY;
        HttpClient client = new HttpClient();

        public APIWrap(string apiString)
        {
            APIKEY = apiString;
            client.DefaultRequestHeaders.Add("x-api-key", APIKEY);
        }

        string? PrepareUserJsonForInsert(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }


            var data = new Dictionary<string, string>
            {
                { "Username", $"{username}" },
                { "Password", $"{password}" }
            };
            var json = JsonConvert.SerializeObject(data);

            return json;
        }


        string? PrepareEntryJsonForInsert(string ProductName, string Unit, string Count, string AddedBy)
        {
            if ((string.IsNullOrEmpty(ProductName) || string.IsNullOrEmpty(Unit) || (string.IsNullOrEmpty(Count) || string.IsNullOrEmpty(AddedBy))))
            {
                return null;
            }

            var data = new Dictionary<string, string>
            {
                { "ProductName", $"{ProductName}" },
                { "Unit", $"{Unit}" },
                { "Count", $"{Count}" },
                { "AddedBy", $"{AddedBy}" }
            };
            var json = JsonConvert.SerializeObject(data);

            return json;
        }



        public async Task<bool> InsertNewUser(string name, string passwd)
        {
            var json = PrepareUserJsonForInsert(name, passwd);

            if (json == null)
            {
                return false;
            }

            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            try
            {
                await client.PostAsync("https://rest-api-db.up.railway.app/users", content);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> GetAllUsers()
        {
            try
            {
                var content = await client.GetAsync("https://rest-api-db.up.railway.app/users");
                string result = await content.Content.ReadAsStringAsync();
                return result;
            }
            catch
            {
                return "Unable To Get All Users";
            }
        }

        public async Task<string> GetAllProducts()
        {
            try
            {
                var content = await client.GetAsync("https://rest-api-db.up.railway.app/entries");
                string result = await content.Content.ReadAsStringAsync();
                return result;
            }
            catch
            {
                return "Unable To Get All Products";
            }
        }

        public async Task<string> GetProductByID(int id)
        {
            try
            {
                var content = await client.GetAsync($"https://rest-api-db.up.railway.app/entries/{id}");
                string result = await content.Content.ReadAsStringAsync();
                return result;
            }
            catch
            {
                return "Unable To Get Product";
            }
        }



        public async Task<bool> InsertNewProduct(string ProductName, string Unit, string Count, string AddedBy)
        {
            var json = PrepareEntryJsonForInsert(ProductName, Unit, Count, AddedBy);

            if (json == null)
            {
                return false;
            }

            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            try
            {
                await client.PostAsync("https://rest-api-db.up.railway.app/entries", content);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> DeleteProductByID(int id)
        {
            try
            {
                var content = await client.DeleteAsync($"https://rest-api-db.up.railway.app/entries/{id}");
                string result = await content.Content.ReadAsStringAsync();
                return result;
            }
            catch
            {
                return "Unable To Delete Product";
            }
        }

        public async Task<int> GetCountOfProducts()
        {
            var content = await client.GetAsync("https://rest-api-db.up.railway.app/entries");
            string result = await content.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(result))
            {
                return 0;
            }

            List<object> products = JsonConvert.DeserializeObject<List<object>>(result);
            int count = products.Count;

            return count;
        }

        public async Task<bool> UpdateExistingProduct(int Product_ID, string ProductName, string Unit, string Count, string AddedBy)
        {
            var json = PrepareEntryJsonForInsert(ProductName, Unit, Count, AddedBy);

            if (json == null)
            {
                return false;
            }

            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            try
            {
                await client.PatchAsync($"https://rest-api-db.up.railway.app/entries/{Product_ID}", content);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
