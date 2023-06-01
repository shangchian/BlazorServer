using MyModels;

namespace BlazorServer.Services
{
    public interface IUserService
    {
        Task<WebUser?> LoginUser(WebUser user);
    }
}
