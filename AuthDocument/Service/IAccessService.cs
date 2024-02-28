using AuthDocument.Models;

namespace AuthDocument.Service
{
    public interface IAccessService
    {
        Task<string> Register(User user);
        Task<string> Login(User user);
    }
}
