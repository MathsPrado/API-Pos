using AutoMapper;
using Student.API.DTOs;
using Student.API.Model;
using Student.API.Repository.Interface;
using Student.API.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student.API.Service
{
    public class SolicitacaoProjetoService : ISolicitacaoProjetoService
    {

        private readonly ISolicitacaoProjetoRepository _repository;
        private readonly IMapper _mapper;

        public SolicitacaoProjetoService(ISolicitacaoProjetoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SolicitacaoProjetoDTO> Create(SolicitacaoProjetoDTO solicitacaoProjetoDTO)
        {
            var result = await _repository.Create(_mapper.Map<SolicitacaoProjeto>(solicitacaoProjetoDTO));
            return _mapper.Map<SolicitacaoProjetoDTO>(solicitacaoProjetoDTO);
        }

        public async Task<SolicitacaoProjetoDTO> Delete(int id)
        {
            var result = await _repository.Delete(id);
            return _mapper.Map<SolicitacaoProjetoDTO>(id);
        }

        public async Task<SolicitacaoProjetoDTO> FindById(int id)
        {
            var result = await _repository.FindById(id);
            return _mapper.Map<SolicitacaoProjetoDTO>(result);
        }

        public async Task<IEnumerable<SolicitacaoProjetoDTO>> GetAll()
        {
            var result = await _repository.GetAll();
            return _mapper.Map<IEnumerable<SolicitacaoProjetoDTO>>(result);
        }

        public async Task<SolicitacaoProjetoDTO> Update(SolicitacaoProjetoDTO solicitacaoProjetoDTO)
        {
            var result = await _repository.Update(_mapper.Map<SolicitacaoProjeto>(solicitacaoProjetoDTO));
            return _mapper.Map<SolicitacaoProjetoDTO>(solicitacaoProjetoDTO);
        }
    }
}
