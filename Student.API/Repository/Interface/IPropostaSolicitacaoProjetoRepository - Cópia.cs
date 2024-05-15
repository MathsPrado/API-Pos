using Student.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student.API.Repository.Interface
{
    public interface IPerfilUseroRepository
    {
        Task<IEnumerable<PerfilUser>> GetAll();
        Task<PerfilUser> FindById(int id);
        Task<PerfilUser> FindByIdPerfilUser(int id);
        Task<PerfilUser> Create(PerfilUser value);
        Task<PerfilUser> Update(PerfilUser value);
        Task<PerfilUser> Delete(int id);
    }
}
