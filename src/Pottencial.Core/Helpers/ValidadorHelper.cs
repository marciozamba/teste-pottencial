using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Pottencial.Core.Helpers
{
    public static class ValidadorHelper
    {
        public static string ValidaCPF(string cpfString)
        {
            if (String.IsNullOrEmpty(cpfString))
            {
                return cpfString;
            }

            decimal cpf;

            cpfString = RetornaNumeros(cpfString);
            decimal.TryParse(cpfString, out cpf);

            if (cpf == 0 || cpfString.Length != 11)
            {
                return null;
            }
            else
            {
                return cpfString;
            }
        }

        public static string ValidaTelefone(string telefoneString)
        {
            if (String.IsNullOrEmpty(telefoneString))
            {
                return telefoneString;
            }

            decimal telefone;

            telefoneString = RetornaNumeros(telefoneString);
            decimal.TryParse(telefoneString, out telefone);

            if (telefone == 0 || (telefoneString.Length != 11 && telefoneString.Length != 10))
            {
                return null;
            }
            else
            {
                return telefoneString;
            }
        }

        private static string RetornaNumeros(string str)
        {
            var digitos = new Regex(@"[^\d]");

            return digitos.Replace(str, "");
        }
    }
}
