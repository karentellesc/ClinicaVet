using ClinicaVet.Data;
using ClinicaVet.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVet.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly ClinicaVetContext _context;

        public ConsultaRepository(ClinicaVetContext context)
        {
            _context = context;
        }

        public void Adicionar(Consulta consulta)
        {
            _context.Consultas.Add(consulta);
            _context.SaveChanges();
        }

        public List<Consulta> Listar()
        {
            return _context.Consultas
            .Include(c => c.Cliente)
            .ToList();
        }

        public Consulta? BuscarPorId(int id)
        {
            return _context.Consultas
            .Include(c => c.Cliente)
            .FirstOrDefault(c => c.Id == id);
        }

        public void Atualizar(Consulta consulta)
        {
            _context.Consultas.Update(consulta);
            _context.SaveChanges();
        }
        
        public void Remover(int id)
        {
            var consulta = _context.Consultas.Find(id);
            
            if (consulta != null)
            {
                _context.Consultas.Remove(consulta);
                _context.SaveChanges();
            }
        }
    }
}