using DomainValidation.Validation;
using System;

namespace AS.ProjetoCompleto.Dominio.Models
{
    //classe que não pode ser instanciada
    //somente herdada
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public ValidationResult validationResult { get; set; }

        public void AdicionarErroValidacao(string erro)
        {
            validationResult.Add(new ValidationError(erro));
        }

        public abstract bool EhValido();
    }
}
