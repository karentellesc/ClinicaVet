using ClinicaVet.Data;
using ClinicaVet.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVet.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClinicaVetContext _context;

        public ClienteRepository(ClinicaVetContext context)
        {
            _context = context;
        }

        public void Adicionar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public List<Cliente> Listar()
        {
            return _context.Clientes
            .Include(c => c.Consultas)
            .ToList();
        }

        public Cliente? BuscarPorId(int id)
        {
            return _context.Clientes
            .Include(c => c.Consultas)
            .FirstOrDefault(c => c.Id == id);
        }

        public void Atualizar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }
        
        public void Remover(int id)
        {
            var cliente = BuscarPorId(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}