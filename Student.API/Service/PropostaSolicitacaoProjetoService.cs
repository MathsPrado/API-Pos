using AutoMapper;
using Student.API.DTOs;
using Student.API.Model;
using Student.API.Repository.Interface;
using Student.API.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student.API.Service
{
    public class PropostaSolicitacaoProjetoService : IPropostaSolicitacaoProjetoService
    {

        private readonly IPropostaSolicitacaoProjetoRepository _repository;
        private readonly IMapper _mapper;

        public PropostaSolicitacaoProjetoService(IPropostaSolicitacaoProjetoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PropostaSolicitacaoProjetoDTO> Create(PropostaSolicitacaoProjetoDTO solicitacaoProjetoDTO)
        {
            var result = await _repository.Create(_mapper.Map<PropostaSolicitacaoProjeto>(solicitacaoProjetoDTO));
            return _mapper.Map<PropostaSolicitacaoProjetoDTO>(solicitacaoProjetoDTO);
        }

        public async Task<PropostaSolicitacaoProjetoDTO> Delete(int id)
        {
            var result = await _repository.Delete(id);
            return _mapper.Map<PropostaSolicitacaoProjetoDTO>(result);
        }

        public async Task<PropostaSolicitacaoProjetoDTO> FindById(int id)
        {
            var result = await _repository.FindById(id);
            return _mapper.Map<PropostaSolicitacaoProjetoDTO>(result);
        }

        public async Task<PropostaSolicitacaoProjetoDTO> FindByIdPropostaSolucao(int id)
        {
            var result = await _repository.FindByIdPropostaSolucao(id);
            return _mapper.Map<PropostaSolicitacaoProjetoDTO>(result);
        }

        public async Task<IEnumerable<PropostaSolicitacaoProjetoDTO>> GetAll()
        {
            var result = await _repository.GetAll();
            return _mapper.Map<IEnumerable<PropostaSolicitacaoProjetoDTO>>(result);
        }

        public async Task<PropostaSolicitacaoProjetoDTO> Update(PropostaSolicitacaoProjetoDTO solicitacaoProjetoDTO)
        {
            var result = await _repository.Update(_mapper.Map<PropostaSolicitacaoProjeto>(solicitacaoProjetoDTO));
            return _mapper.Map<PropostaSolicitacaoProjetoDTO>(solicitacaoProjetoDTO);
        }
    }
}
