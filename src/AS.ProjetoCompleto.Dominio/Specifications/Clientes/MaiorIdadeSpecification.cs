using AS.ProjetoCompleto.Dominio.Models;
using DomainValidation.Interfaces.Specification;
using System;

namespace AS.ProjetoCompleto.Dominio.Specifications.Clientes
{
    public class MaiorIdadeSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return DateTime.Now.Year - cliente.DataNascimento.Year >= 18;
        }
    }
}
