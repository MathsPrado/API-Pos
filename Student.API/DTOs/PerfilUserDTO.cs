using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.API.Model
{
    public class PerfilUserDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Biografia { get; set; }
    }
}
