using Student.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student.API.Repository.Interface
{
    public interface IPropostaSolicitacaoProjetoRepository
    {
        Task<IEnumerable<PropostaSolicitacaoProjeto>> GetAll();
        Task<PropostaSolicitacaoProjeto> FindById(int id);
        Task<PropostaSolicitacaoProjeto> FindByIdPropostaSolucao(int id);
        Task<PropostaSolicitacaoProjeto> Create(PropostaSolicitacaoProjeto value);
        Task<PropostaSolicitacaoProjeto> Update(PropostaSolicitacaoProjeto value);
        Task<PropostaSolicitacaoProjeto> Delete(int id);
    }
}
