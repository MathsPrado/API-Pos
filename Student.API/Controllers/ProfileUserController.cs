using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NSwag.Annotations;
using Student.API.DTOs;
using Student.API.Model;
using Student.API.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileUserController : ControllerBase
    {

        private readonly IPerfilUserService _service;
        private readonly IConfiguration _configuration;

        public ProfileUserController(IPerfilUserService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] PerfilUserDTO request)
        {
            // Busca o usuário no banco de dados
            var token = await _service.AuthenticateAsync(request);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Usuário ou senha inválidos.");
            }

            return Ok(new { Token = token });
        }

        private bool VerifyPassword(string password, string passwordHash)
        {
            // Substitua pela sua lógica de verificação de senha hash (ex: BCrypt)
            return password == passwordHash; // Apenas para exemplo. Não use em produção!
        }

        private string GenerateJwtToken(string username)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username)
        };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpirationInMinutes"])),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] PerfilUserDTO request)
        {
            return Ok("Usuário criado com sucesso!");
        }
    }
}
