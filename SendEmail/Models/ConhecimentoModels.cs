using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SendEmail.Models
{
    public class ConhecimentoModels
    {
        public string nome { get; set; }
        public string descricao { get; set; }
        public int nota { get; set; }
        public tipoCandidato tipo { get; set; }

        public enum tipoCandidato
        {
            Front_End,
            Back_End,
            Mobile,
            Generico
        };
    }
}