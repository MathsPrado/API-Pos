using Student.API.DTOs;
using Student.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student.API.Service.Interface
{
    public interface ISolicitacaoProjetoService
    {
        Task<IEnumerable<SolicitacaoProjetoDTO>> GetAll();
        Task<SolicitacaoProjetoDTO> FindById(int id);
        Task<SolicitacaoProjetoDTO> Create(SolicitacaoProjetoDTO solicitacaoProjetoDTO);
        Task<SolicitacaoProjetoDTO> Update(SolicitacaoProjetoDTO solicitacaoProjetoDTO);
        Task<SolicitacaoProjetoDTO> Delete(int id);
    }
}
