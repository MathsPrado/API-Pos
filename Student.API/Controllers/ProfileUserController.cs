using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Student.API.DTOs;
using Student.API.Model;
using Student.API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileUserController : ControllerBase
    {

        private readonly IPerfilUserService _service;

        public ProfileUserController(IPerfilUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<PerfilUserDTO>> GetAll()
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

        [HttpGet("{id}")]
        public async Task<ActionResult<PerfilUserDTO>> Get(int id)
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

        [HttpGet("PerfilUser/{id}")]
        public async Task<ActionResult<PerfilUserDTO>> GetProposta(int id)
        {
            try
            {
                var result = await _service.FindByIdPropostaSolucao(id);
                if (result != null)
                    return Ok(result);

                return BadRequest("Informações não encontradas");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<SolicitacaoProjetoController>
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] PerfilUserDTO value)
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
        public async Task<ActionResult> Put([FromBody] PerfilUserDTO value)
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
