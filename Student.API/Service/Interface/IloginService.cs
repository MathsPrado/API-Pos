using Student.API.DTOs;
using Student.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student.API.Service.Interface
{
    public interface IloginService
    {
        Task<string> GenerateToken();
    }
}
