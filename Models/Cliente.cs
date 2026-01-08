using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicaVet.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string NomeAnimal { get; set; }
        public string Idade { get; set; }
        public string Sexo { get; set; }
        public string Especie { get; set; }
        public string Raca { get; set; }
        public string Porte { get; set; }

        public string NomeDono { get; set; }
        public string Telefone { get; set; }
        public string MotivoConsulta { get; set; }

        public List<Consulta> Consultas { get; set; } = new List<Consulta>();
    }
}