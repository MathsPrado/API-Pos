using Student.API.Model;
using System.Threading.Tasks;

namespace Student.API.Service.Interface
{
    public interface IAuthService
    {
        Task<string> AuthenticateAsync(PerfilUserDTO request);
        Task CreateUserAsync(string username, string password);
    }
}
