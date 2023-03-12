using System;
using System.Collections.Generic;

namespace Student.API.DTOs
{
    public class SolicitacaoProjetoDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public bool SemDataInicio { get; set; }
        public bool SemDataFim { get; set; }
        public string Orçamento { get; set; }
        public string Local { get; set; }
        public List<string> ListaConhecimentos { get; set; }
        public string Descricao { get; set; }
    }
}
