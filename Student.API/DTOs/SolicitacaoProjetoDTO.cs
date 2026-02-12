using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Student.API.DTOs
{
    public class SolicitacaoProjetoDTO
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }
        public bool SemDataInicio { get; set; }
        public bool SemDataFim { get; set; }

        [Required]
        public string Orçamento { get; set; }

        [Required]
        public string Local { get; set; }

        [Required]
        public List<string> ListaConhecimentos { get; set; }

        [Required]
        public string Descricao { get; set; }
    }
}
