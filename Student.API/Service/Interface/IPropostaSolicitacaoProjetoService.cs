using Student.API.DTOs;
using Student.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student.API.Service.Interface
{
    public interface IPropostaSolicitacaoProjeto
    {
        Task<IEnumerable<PropostaSolicitacaoProjetoDTO>> GetAll();
        Task<PropostaSolicitacaoProjetoDTO> FindById(int id);
        Task<PropostaSolicitacaoProjetoDTO> FindByIdPropostaSolucao(int id);
        Task<PropostaSolicitacaoProjetoDTO> Create(PropostaSolicitacaoProjetoDTO solicitacaoProjetoDTO);
        Task<PropostaSolicitacaoProjetoDTO> Update(PropostaSolicitacaoProjetoDTO solicitacaoProjetoDTO);
        Task<PropostaSolicitacaoProjetoDTO> Delete(int id);
    }
}
