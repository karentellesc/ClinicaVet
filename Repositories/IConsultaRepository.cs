using ClinicaVet.Models;

namespace ClinicaVet.Repositories
{
    public interface IConsultaRepository
    {
        void Adicionar(Consulta consulta);
        List<Consulta> Listar();
        Consulta? BuscarPorId(int id);
        void Atualizar(Consulta consulta);
        void Remover(int id);
    }
}