using MyModels;

namespace BlazorServer.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient client;
        private readonly IConfiguration config;
        public UserService(HttpClient client, IConfiguration config)
        {
            this.client = client;
            this.config = config;
        }
        public async Task<WebUser?> LoginUser(WebUser user)
        {
            var resp = await client.PostAsJsonAsync(
              $"{config["WebsiteConfig:WebApiBaseAddress"]}/api/user/loginuser",
              user);

            WebUser? loginUser = null;
            if (resp.IsSuccessStatusCode)
            {
                loginUser = await resp.Content.ReadFromJsonAsync<WebUser>();
            }
            if (loginUser == null) return null;
            return loginUser;
        }
    }
}
