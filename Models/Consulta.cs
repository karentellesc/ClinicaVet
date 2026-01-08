using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVet.Models
{
    public class Consulta
    {
        public int Id { get; set; }
        public string Exames { get; set; }
        public string Diagnostico { get; set; }
        public string Medicacoes { get; set; }
        public string Conduta { get; set; }

        public bool HouveInternacao { get; set; }
        public string DiasInternacao { get; set; }
        public string ProcedimentosInternacao { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}