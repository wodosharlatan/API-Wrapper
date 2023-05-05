using Newtonsoft.Json;

namespace NuggetAPIwrapper
{
    public class APIWrap
    {
        private string APIKEY;
        HttpClient client = new HttpClient();

        public APIWrap(string apiString)
        {
            APIKEY = apiString;
        }

        string PrepareUserJsonForInsert(string username, string password)
        {
            if (username == null || password == null)
            {
                return "Username or Password Can't be empty";
            }


            var data = new Dictionary<string, string>
            {
                { "Username", $"{username}" },
                { "Password", $"{password}" }
            };
            var json = JsonConvert.SerializeObject(data);

            return json;
        }

        public async Task<bool> InsertNewUser(string name, string passwd)
        {
            var json = PrepareUserJsonForInsert(name, passwd);

            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.Add("x-api-key", APIKEY);

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
    }
}
