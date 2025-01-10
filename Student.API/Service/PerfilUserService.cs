using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using Student.API.DTOs;
using Student.API.Model;
using Student.API.Repository.Interface;
using Student.API.Service.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Student.API.Service
{
    public class PerfilUserService : IPerfilUserService
    {

        private readonly IPerfilUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public PerfilUserService(IPerfilUserRepository repository, IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
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

        //public async Task<string> AuthenticateAsync(PerfilUserDTO perfilUserDTO)
        //{
        //    // Busca o usuário pelo nome de usuário
        //    var user = await _repository.GetUserByEmailAsync(perfilUserDTO.Email);

        //    // Valida o usuário e a senha
        //    if (user == null || !VerifyPassword(perfilUserDTO.Password, user.PasswordHash))
        //    {
        //        return null; // Retorna nulo se a validação falhar
        //    }

        //    // Gera o token JWT
        //    return GenerateJwtToken(user.Email);
        //}

        private bool VerifyPassword(string password, string passwordHash)
        {
            // Compara a senha fornecida com o hash armazenado
            return BCrypt.ReferenceEquals(password, passwordHash);
        }

        private string GenerateJwtToken(string email)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, email)
        };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpirationInMinutes"])),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> AuthenticateAsync(PerfilUserDTO value)
        {
            // Busca o usuário pelo nome de usuário
            var user = await _repository.GetUserByEmailAsync(value.Email);

            // Valida o usuário e a senha
            if (user == null || !VerifyPassword(value.Password, user.PasswordHash))
            {
                return null; // Retorna nulo se a validação falhar
            }

            string email = user.Email;
            // Gera o token JWT
            return GenerateJwtToken(email);
        }
    }
}
