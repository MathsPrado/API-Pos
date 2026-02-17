using Microsoft.EntityFrameworkCore;
using Student.API.Context;
using Student.API.Model;
using Student.API.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.API.Repository
{
    public class SolicitacaoProjetoRepository : ISolicitacaoProjetoRepository
    {

        private readonly AppDbContext _context;

        public SolicitacaoProjetoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SolicitacaoProjeto> Create(SolicitacaoProjeto value)
        {
            try
            {
                _context.SolicitacaoProjeto.Add(value);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                return null;
            }
            return value;
        }

        public async Task<bool> Exists(SolicitacaoProjeto value)
        {
            if (value == null)
                return false;

            return await _context.SolicitacaoProjeto.AnyAsync(s => s.Titulo == value.Titulo && s.DataInicio == value.DataInicio);
        }

        public async Task<SolicitacaoProjeto> Delete(int id)
        {
            var category = await FindById(id);
            _context.Remove(category);
            _context.SaveChanges();
            return category;
        }

        public async Task<SolicitacaoProjeto> FindById(int id)
        {
            var test = await _context.SolicitacaoProjeto.Where(c => c.Id == id).FirstOrDefaultAsync();
            return test;
        }

        public async Task<IEnumerable<SolicitacaoProjeto>> GetAll()
        {
            var result = await _context.SolicitacaoProjeto.ToListAsync();
            return result;
        }

        public async Task<SolicitacaoProjeto> Update(SolicitacaoProjeto value)
        {
            _context.Entry(value).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            await _context.SaveChangesAsync();
            return value;
        }
    }
}
