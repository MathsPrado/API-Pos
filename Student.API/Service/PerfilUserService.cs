using AutoMapper;
using Student.API.DTOs;
using Student.API.Model;
using Student.API.Repository.Interface;
using Student.API.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student.API.Service
{
    public class PerfilUserService : IPerfilUserService
    {

        private readonly IPerfilUserRepository _repository;
        private readonly IMapper _mapper;

        public PerfilUserService(IPerfilUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PerfilUserDTO> Create(PerfilUserDTO solicitacaoProjetoDTO)
        {
            var result = await _repository.Create(_mapper.Map<PerfilUser>(solicitacaoProjetoDTO));
            return _mapper.Map<PerfilUserDTO>(solicitacaoProjetoDTO);
        }

        public async Task<PerfilUserDTO> Delete(int id)
        {
            var result = await _repository.Delete(id);
            return _mapper.Map<PerfilUserDTO>(result);
        }

        public async Task<PerfilUserDTO> FindById(int id)
        {
            var result = await _repository.FindById(id);
            return _mapper.Map<PerfilUserDTO>(result);
        }

        public async Task<PerfilUserDTO> FindByIdPropostaSolucao(int id)
        {
            var result = await _repository.FindByIdPerfilUser(id);
            return _mapper.Map<PerfilUserDTO>(result);
        }

        public async Task<IEnumerable<PerfilUserDTO>> GetAll()
        {
            var result = await _repository.GetAll();
            return _mapper.Map<IEnumerable<PerfilUserDTO>>(result);
        }

        public async Task<PerfilUserDTO> Update(PerfilUserDTO solicitacaoProjetoDTO)
        {
            var result = await _repository.Update(_mapper.Map<PerfilUser>(solicitacaoProjetoDTO));
            return _mapper.Map<PerfilUserDTO>(solicitacaoProjetoDTO);
        }
    }
}
