using AS.ProjetoCompleto.Dominio.Models;
using AS.ProjetoCompleto.Dominio.ValueObjects;
using DomainValidation.Interfaces.Specification;

namespace AS.ProjetoCompleto.Dominio.Specifications.Clientes
{
    public class EmailSpecification : ISpecification<Cliente>
    {
        public bool IsSatisfiedBy(Cliente cliente)
        {
            return Email.Validar(cliente.Email);
        }
    }
}
