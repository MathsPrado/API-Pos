using Student.API.DTOs;
using Student.API.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student.API.Service
{
    public class LoginService : IloginService
    {
        public string GenerateTokenMoc()
        {
            return "fake-jwt-token";
        }

        Task<string> IloginService.GenerateToken()
        {
            return Task.FromResult(GenerateTokenMoc());
        }
    }
}
