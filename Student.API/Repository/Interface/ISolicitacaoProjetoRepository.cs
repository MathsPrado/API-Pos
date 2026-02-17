using Student.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student.API.Repository.Interface
{
    public interface ISolicitacaoProjetoRepository
    {
        Task<IEnumerable<SolicitacaoProjeto>> GetAll();
        Task<SolicitacaoProjeto> FindById(int id);
        Task<bool> Exists(SolicitacaoProjeto value);
        Task<SolicitacaoProjeto> Create(SolicitacaoProjeto value);
        Task<SolicitacaoProjeto> Update(SolicitacaoProjeto value);
        Task<SolicitacaoProjeto> Delete(int id);
    }
}
