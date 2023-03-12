using Microsoft.EntityFrameworkCore;
using Student.API.Context;
using Student.API.Model;
using Student.API.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.API.Repository
{
    public class PropostaSolicitacaoProjetoRepository : IPropostaSolicitacaoProjetoRepository
    {

        private readonly AppDbContext _context;

        public PropostaSolicitacaoProjetoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PropostaSolicitacaoProjeto> Create(PropostaSolicitacaoProjeto value)
        {
            _context.PropostaSolicitacaoProjeto.Add(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public async Task<PropostaSolicitacaoProjeto> Delete(int id)
        {
            var result = await FindById(id);
            _context.Remove(result);
            _context.SaveChanges();
            return result;
        }

        public async Task<PropostaSolicitacaoProjeto> FindById(int id)
        {
            var test = await _context.PropostaSolicitacaoProjeto.Where(c => c.Id == id).FirstOrDefaultAsync();
            return test;
        }

        public async Task<PropostaSolicitacaoProjeto> FindByIdPropostaSolucao(int id)
        {
            var test = await _context.PropostaSolicitacaoProjeto.Where(c => c.IdPropostaSolucao == id).FirstOrDefaultAsync();
            return test;
        }

        public async Task<IEnumerable<PropostaSolicitacaoProjeto>> GetAll()
        {
            var result = await _context.PropostaSolicitacaoProjeto.ToListAsync();
            return result;
        }

        public async Task<PropostaSolicitacaoProjeto> Update(PropostaSolicitacaoProjeto value)
        {
            _context.Entry(value).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            await _context.SaveChangesAsync();
            return value;
        }
    }
}
