using Microsoft.EntityFrameworkCore;
using Student.API.Context;
using Student.API.Model;
using Student.API.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student.API.Repository
{
    public class PerfilUserRepository : IPerfilUserRepository
    {

        private readonly AppDbContext _context;

        public PerfilUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PerfilUser> Create(PerfilUser value)
        {
            _context.PerfilUser.Add(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public async Task<PerfilUser> Delete(int id)
        {
            var result = await FindById(id);
            _context.Remove(result);
            _context.SaveChanges();
            return result;
        }

        public async Task<PerfilUser> FindById(int id)
        {
            var test = await _context.PerfilUser.Where(c => c.Id == id).FirstOrDefaultAsync();
            return test;
        }

        public async Task<PerfilUser> FindByIdPerfilUser(int id)
        {
            var test = await _context.PerfilUser.Where(c => c.Id == id).FirstOrDefaultAsync();
            return test;
        }

        public async Task<IEnumerable<PerfilUser>> GetAll()
        {
            var result = await _context.PerfilUser.ToListAsync();
            return result;
        }

        public async Task<PerfilUser> GetUserByEmailAsync(string email)
        {
            return await _context.PerfilUser
                .FirstOrDefaultAsync(u => u.Email == email);
        }


        public async Task<PerfilUser> Update(PerfilUser value)
        {
            _context.Entry(value).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            await _context.SaveChangesAsync();
            return value;
        }
    }
}
