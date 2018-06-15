using AS.ProjetoCompleto.Dominio.Interfaces;
using AS.ProjetoCompleto.Dominio.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AS.ProjetoCompleto.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        //o método Buscar está implementado lá na classe Repository
        //que está sendo herdada

        public override Cliente ObterPorId(Guid id)
        {
            var sql = @"SELECT * FROM Clientes c " +
                      "LEFT JOIN Enderecos e " +
                      "ON c.Id = e.ClienteId " +
                      "WHERE c.Id = @uid AND c.Excluido = 0 AND c.Ativo = 1";

            return Db.Database.Connection.Query<Cliente, Endereco, Cliente>(sql,
                (c, e) => {
                    c.Enderecos.Add(e);
                    return c;
                }, new { uid = id}).FirstOrDefault();

        }
        public IEnumerable<Cliente> ObterAtivos()
        {
            var sql = @"SELECT * FROM Clientes C " +
                    " WHERE C.EXCLUIDO =0 AND C.ATIVO=1";

            //return Buscar(c => c.Ativo && !c.Excluido);

            return Db.Database.Connection.Query<Cliente>(sql);
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
