using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Store.Infrastructure.Commands.User;
using Store.Infrastructure.DTO;

namespace Store.Tests.Integration.controllers.Utilities
{
    public static class Extensions
    {
        public static StringContent GetPayload(this object data){
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json,Encoding.UTF8, "application/json");
        }
        public static T DeserializeAs<T>(this string responseContentString)
        {
            return JsonConvert.DeserializeObject<T>(responseContentString);
        }
        public static async Task<UserDto> CreateAndGetUser(this HttpClient Client, CreateUser command)
        {
            var payload = GetPayload(command);
            var response = await Client.PostAsync("users/",payload);
            
            var userDto = await Client.GetUserAsync(command.Email);
            return userDto;
        }
        public static async Task<UserDto> GetUserAsync(this HttpClient Client,string email)
        {
            var response = await Client.GetAsync($"users/{email}");            
            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<UserDto>(responseString);

            return user;
        }  
        public static async Task LoginAsync(this HttpClient Client,string email, string password)
        {
            // var login = new Login{
            //     Email = email,
            //     Password= password,
            // };
            // var payload = login.GetPayload();
            // var response = await Client.PostAsync("login/", payload);            
            // var responseString = await response.Content.ReadAsStringAsync();
            // var jwt = JsonConvert.DeserializeObject<JwtDto>(responseString);

            // Client.AddToken(jwt.Token);
        }
        public static void AddToken(this HttpClient cl, string token)
        {
            string contentType = "application/json";
            cl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
            cl.DefaultRequestHeaders.Remove("Authorization");
            cl.DefaultRequestHeaders.Add("Authorization", string.Format($"Bearer {token}"));            
           
        }
    }
}