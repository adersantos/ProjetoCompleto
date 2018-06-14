using AS.ProjetoCompleto.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS.ProjetoCompleto.Dominio.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>, IRepositoryWrite<Cliente>
    {
        Cliente ObterPorCpf(string cpf);

        Cliente ObterPorEmail(string email);

        IEnumerable<Cliente> ObterAtivos();

        Cliente ObterClienteUnico(Cliente cliente);

    }
}
