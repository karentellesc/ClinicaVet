using ClinicaVet.Models;

namespace ClinicaVet.Repositories
{
    public interface IClienteRepository
    {
        void Adicionar(Cliente cliente);
        List<Cliente> Listar();
        Cliente? BuscarPorId(int id);
        void Atualizar(Cliente cliente);
        void Remover(int id);
    }
}