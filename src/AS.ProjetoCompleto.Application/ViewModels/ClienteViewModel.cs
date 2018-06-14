using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS.ProjetoCompleto.Application.ViewModels
{
    public class ClienteViewModel
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; private set; }

        public bool Excluido { get; private set; }
    }
}
