using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS.ProjetoCompleto.Dominio.ValueObjects
{
    public class CPF
    {
        public static bool Validar(string cpf)
        {
            if (cpf.Length > 11)
            {
                return false;
            }

            while (cpf.Length != 11)
            {
                cpf = '0' + cpf;
            }

            var igual = true;
            for (int i = 0; i < 11 && igual; i++)
            {
                if (cpf[i] != cpf[0])
                    igual = false;
            }

            if (igual || cpf == "12345678909")
                return false;

            return igual;
        }
    }
}
