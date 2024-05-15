using Student.API.DTOs;
using Student.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student.API.Service.Interface
{
    public interface IPerfilUserService
    {
        Task<IEnumerable<PerfilUserDTO>> GetAll();
        Task<PerfilUserDTO> FindById(int id);
        Task<PerfilUserDTO> FindByIdPropostaSolucao(int id);
        Task<PerfilUserDTO> Create(PerfilUserDTO solicitacaoProjetoDTO);
        Task<PerfilUserDTO> Update(PerfilUserDTO solicitacaoProjetoDTO);
        Task<PerfilUserDTO> Delete(int id);
    }
}
