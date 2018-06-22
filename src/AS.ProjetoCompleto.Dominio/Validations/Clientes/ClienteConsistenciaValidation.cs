using AS.ProjetoCompleto.Dominio.Models;
using AS.ProjetoCompleto.Dominio.Specifications.Clientes;
using DomainValidation.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS.ProjetoCompleto.Dominio.Validations.Clientes
{
    public class ClienteConsistenciaValidation : Validator<Cliente>
    {
        public ClienteConsistenciaValidation()
        {
            var CPFCliente = new CPFSpecification();
            var emailCliente = new EmailSpecification();
            var maiorIdadeCliente = new MaiorIdadeSpecification();

            base.Add("CPFCliente", new Rule<Cliente>(CPFCliente,"CPF Inválido."));
            base.Add("emailCliente", new Rule<Cliente>(emailCliente, "e-mail Inválido."));
            base.Add("maiorIdadeCliente", new Rule<Cliente>(maiorIdadeCliente, "Cliente não tem idade suficiente."));
        }
    }
}
