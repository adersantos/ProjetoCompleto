using AS.ProjetoCompleto.Dominio.Interfaces;
using AS.ProjetoCompleto.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AS.ProjetoCompleto.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        //o método Buscar está implementado lá na classe Repository
        //que está sendo herdada

        public IEnumerable<Cliente> ObterAtivos()
        {
            return Buscar(c => c.Ativo && !c.Excluido);
        }

        public Cliente ObterClienteUnico(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c => c.CPF == cpf && !c.Excluido).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email && !c.Excluido).FirstOrDefault();
        }

        public override void Remover(Guid id)
        {
            //exclusão apenas lógica
            var cliente = ObterPorId(id);
            cliente.Excluir();
            Atualizar(cliente);
        }
    }
}
