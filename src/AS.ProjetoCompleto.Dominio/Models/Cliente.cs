using AS.ProjetoCompleto.Dominio.Validations.Clientes;
using System;
using System.Collections.Generic;

namespace AS.ProjetoCompleto.Dominio.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; private set; }

        public bool Excluido { get; private set; }

        //Propriedades de Navegação
        //virtual - torna passível a utilização desta propriedade via LazyLoading
        public virtual ICollection<Endereco> Enderecos { get; private set; }


        public Cliente()
        {
            Enderecos = new List<Endereco>();
        }
        
        public void Excluir()
        {
            Ativo = false;
            Excluido = true;
        }
        public void Ativar()
        {
            Ativo = true;
            Excluido = false;
        }

        //AdHoc Setter
        public void AdicionarEndereco(Endereco endereco)
        {
            if (!endereco.EhValido())
                return;

            Enderecos.Add(endereco);
        }

        public override bool EhValido()
        {
            validationResult = new ClienteConsistenciaValidation().Validate(this);
            return validationResult.IsValid;
        }
    }
}
