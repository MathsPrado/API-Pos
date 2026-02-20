using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Student.API.Model
{
    public class Habilidade
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        
        public string Nivel { get; set; }

        [ForeignKey("PerfilUser")]
        public int PerfilUserId { get; set; }

        public PerfilUser PerfilUser { get; set; }
    }
}