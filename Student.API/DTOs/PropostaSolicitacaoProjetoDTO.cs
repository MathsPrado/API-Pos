using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student.API.Model
{
    public class PropostaSolicitacaoProjetoDTO
    {
        public int Id { get; set; }
        public string Descircao { get; set; }
        public int TempoEntrega { get; set; }
        public string Orçamento { get; set; }
        public int IdPropostaSolucao { get; set; }
        public int IdUsuario { get; set; }
    }
}
