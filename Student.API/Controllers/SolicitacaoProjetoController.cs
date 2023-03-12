using Microsoft.AspNetCore.Mvc;
using Student.API.DTOs;
using Student.API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacaoProjetoController : ControllerBase
    {

        private readonly ISolicitacaoProjetoService _service;

        public SolicitacaoProjetoController(ISolicitacaoProjetoService service)
        {
            _service = service;
        }

        // GET: api/<SolicitacaoProjetoController>
        [HttpGet]
        public async Task<ActionResult<SolicitacaoProjetoDTO>> GetAll()
        {
            try
            {
                var result = await _service.GetAll();
                if (result is not null)
                    return Ok(result);

                return BadRequest("Nenhum cadastro encontrado");
                
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<SolicitacaoProjetoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SolicitacaoProjetoDTO>> Get(int id)
        {
            try
            {
                var result = await _service.FindById(id);
                if(result != null)
                    return Ok(result);

                return BadRequest("Informações não encontradas");
            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<SolicitacaoProjetoController>
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] SolicitacaoProjetoDTO value)
        {
            try
            {
                var result = await _service.Create(value);
                if (result != null)
                    return Ok(result);

                return BadRequest("Informações não encontradas");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<SolicitacaoProjetoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] SolicitacaoProjetoDTO value)
        {
            try
            {
                var result = await _service.Update(value);
                if (result != null)
                    return Ok(result);

                return BadRequest("Informações não encontradas");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<SolicitacaoProjetoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _service.Delete(id);
                if (result != null)
                    return Ok(result);

                return BadRequest("Informações não encontradas");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
