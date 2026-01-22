using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Student.API.Model;
using Student.API.Repository.Interface;
using Student.API.Service;
using Xunit;

namespace XUnitStudentAPI
{
    public class PropostaSolicitacaoProjetoServiceTests
    {
        private readonly Mock<IPropostaSolicitacaoProjetoRepository> _repoMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly PropostaSolicitacaoProjetoService _service;

        public PropostaSolicitacaoProjetoServiceTests()
        {
            _repoMock = new Mock<IPropostaSolicitacaoProjetoRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new PropostaSolicitacaoProjetoService(_repoMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Create_Should_CallRepositoryCreate_AndReturnMappedDto()
        {
            var inputDto = new PropostaSolicitacaoProjetoDTO
            {
                Id = 0,
                Descircao = "desc",
                TempoEntrega = 5,
                Orçamento = "100",
                IdPropostaSolucao = 2,
                IdUsuario = 3
            };

            var modelFromDto = new PropostaSolicitacaoProjeto
            {
                Id = 1,
                Descircao = inputDto.Descircao,
                TempoEntrega = inputDto.TempoEntrega,
                Orçamento = inputDto.Orçamento,
                IdPropostaSolucao = inputDto.IdPropostaSolucao,
                IdUsuario = inputDto.IdUsuario
            };

            var dtoFromModel = new PropostaSolicitacaoProjetoDTO
            {
                Id = modelFromDto.Id,
                Descircao = modelFromDto.Descircao,
                TempoEntrega = modelFromDto.TempoEntrega,
                Orçamento = modelFromDto.Orçamento,
                IdPropostaSolucao = modelFromDto.IdPropostaSolucao,
                IdUsuario = modelFromDto.IdUsuario
            };

            _mapperMock.Setup(m => m.Map<PropostaSolicitacaoProjeto>(It.IsAny<PropostaSolicitacaoProjetoDTO>()))
                .Returns(modelFromDto);
            // Método Create, na implementação atual, retorna Map<PropostaSolicitacaoProjetoDTO>(solicitacaoProjetoDTO)
            // então simulamos map DTO->DTO retornando o próprio DTO (ou uma cópia).
            _mapperMock.Setup(m => m.Map<PropostaSolicitacaoProjetoDTO>(It.IsAny<PropostaSolicitacaoProjetoDTO>()))
                .Returns((PropostaSolicitacaoProjetoDTO s) => s);
            _repoMock.Setup(r => r.Create(It.IsAny<PropostaSolicitacaoProjeto>()))
                .ReturnsAsync(modelFromDto);

            var result = await _service.Create(inputDto);

            _repoMock.Verify(r => r.Create(It.Is<PropostaSolicitacaoProjeto>(p => p.Descircao == inputDto.Descircao && p.TempoEntrega == inputDto.TempoEntrega)), Times.Once);
            Assert.Equal(inputDto.Descircao, result.Descircao);
            Assert.Equal(inputDto.TempoEntrega, result.TempoEntrega);
            Assert.Equal(inputDto.Orçamento, result.Orçamento);
        }

        [Fact]
        public async Task Delete_Should_CallRepositoryDelete_AndReturnMappedDto()
        {
            var id = 10;
            var model = new PropostaSolicitacaoProjeto { Id = id, Descircao = "rm" };
            var dto = new PropostaSolicitacaoProjetoDTO { Id = id, Descircao = "rm" };

            _repoMock.Setup(r => r.Delete(id)).ReturnsAsync(model);
            _mapperMock.Setup(m => m.Map<PropostaSolicitacaoProjetoDTO>(It.IsAny<PropostaSolicitacaoProjeto>())).Returns(dto);

            var result = await _service.Delete(id);

            _repoMock.Verify(r => r.Delete(id), Times.Once);
            Assert.Equal(dto.Id, result.Id);
            Assert.Equal(dto.Descircao, result.Descircao);
        }

        [Fact]
        public async Task FindById_Should_CallRepositoryFindById_AndReturnMappedDto()
        {
            var id = 5;
            var model = new PropostaSolicitacaoProjeto { Id = id, Descircao = "f" };
            var dto = new PropostaSolicitacaoProjetoDTO { Id = id, Descircao = "f" };

            _repoMock.Setup(r => r.FindById(id)).ReturnsAsync(model);
            _mapperMock.Setup(m => m.Map<PropostaSolicitacaoProjetoDTO>(It.IsAny<PropostaSolicitacaoProjeto>())).Returns(dto);

            var result = await _service.FindById(id);

            _repoMock.Verify(r => r.FindById(id), Times.Once);
            Assert.Equal(dto.Id, result.Id);
        }

        [Fact]
        public async Task FindByIdPropostaSolucao_Should_CallRepositoryFindByIdPropostaSolucao_AndReturnMappedDto()
        {
            var id = 7;
            var model = new PropostaSolicitacaoProjeto { Id = id, Descircao = "ps" };
            var dto = new PropostaSolicitacaoProjetoDTO { Id = id, Descircao = "ps" };

            _repoMock.Setup(r => r.FindByIdPropostaSolucao(id)).ReturnsAsync(model);
            _mapperMock.Setup(m => m.Map<PropostaSolicitacaoProjetoDTO>(It.IsAny<PropostaSolicitacaoProjeto>())).Returns(dto);

            var result = await _service.FindByIdPropostaSolucao(id);

            _repoMock.Verify(r => r.FindByIdPropostaSolucao(id), Times.Once);
            Assert.Equal(dto.Id, result.Id);
        }

        [Fact]
        public async Task GetAll_Should_CallRepositoryGetAll_AndReturnMappedEnumerable()
        {
            var models = new List<PropostaSolicitacaoProjeto>
            {
                new PropostaSolicitacaoProjeto { Id = 1, Descircao = "a" },
                new PropostaSolicitacaoProjeto { Id = 2, Descircao = "b" }
            };

            var dtos = new List<PropostaSolicitacaoProjetoDTO>
            {
                new PropostaSolicitacaoProjetoDTO { Id = 1, Descircao = "a" },
                new PropostaSolicitacaoProjetoDTO { Id = 2, Descircao = "b" }
            };

            _repoMock.Setup(r => r.GetAll()).ReturnsAsync(models);
            _mapperMock.Setup(m => m.Map<IEnumerable<PropostaSolicitacaoProjetoDTO>>(It.IsAny<IEnumerable<PropostaSolicitacaoProjeto>>()))
                .Returns(dtos);

            var result = await _service.GetAll();

            _repoMock.Verify(r => r.GetAll(), Times.Once);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task Update_Should_CallRepositoryUpdate_AndReturnMappedDto()
        {
            var inputDto = new PropostaSolicitacaoProjetoDTO
            {
                Id = 3,
                Descircao = "upd",
                TempoEntrega = 2,
                Orçamento = "200",
                IdPropostaSolucao = 4,
                IdUsuario = 5
            };

            var modelFromDto = new PropostaSolicitacaoProjeto
            {
                Id = inputDto.Id,
                Descircao = inputDto.Descircao,
                TempoEntrega = inputDto.TempoEntrega,
                Orçamento = inputDto.Orçamento,
                IdPropostaSolucao = inputDto.IdPropostaSolucao,
                IdUsuario = inputDto.IdUsuario
            };

            _mapperMock.Setup(m => m.Map<PropostaSolicitacaoProjeto>(It.IsAny<PropostaSolicitacaoProjetoDTO>()))
                .Returns(modelFromDto);
            _repoMock.Setup(r => r.Update(It.IsAny<PropostaSolicitacaoProjeto>())).ReturnsAsync(modelFromDto);
            // A implementação atual devolve Map<PropostaSolicitacaoProjetoDTO>(solicitacaoProjetoDTO)
            _mapperMock.Setup(m => m.Map<PropostaSolicitacaoProjetoDTO>(It.IsAny<PropostaSolicitacaoProjetoDTO>()))
                .Returns((PropostaSolicitacaoProjetoDTO s) => s);

            var result = await _service.Update(inputDto);

            _repoMock.Verify(r => r.Update(It.Is<PropostaSolicitacaoProjeto>(p => p.Id == inputDto.Id && p.Descircao == inputDto.Descircao)), Times.Once);
            Assert.Equal(inputDto.Id, result.Id);
            Assert.Equal(inputDto.Descircao, result.Descircao);
        }
    }
}