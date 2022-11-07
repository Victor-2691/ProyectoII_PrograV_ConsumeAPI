using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeApis.Clases
{
    public class Validaciones
    {

        #region "Arreglos"

        // Arreglos para validar caracteres

        private string[] minusculas = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "ñ", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", };
        private string[] mayusculas = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "Ñ", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        private string[] especiales = { "=", "?", "%", "&", "$", "#", "!", ",", "(", ")", "*", "+", "{", "}", "[", "]", ">", "<", "^", "|", "'", "¿", "¡", "" };
        #endregion

        // valida que no se meta letras en campos numericos(codig error - 100)
        public string ValidarCadenaNumerica(string cadena)
        {

            #region "cadena"

            for (int i = 0; i < minusculas.Length; i++)
            {
                for (int n = 0; n < cadena.Length; n++)
                {
                    if (minusculas[i].ToString() == cadena[n].ToString())
                    {
                        return "100";
                    }

                }


            }

            for (int i = 0; i < mayusculas.Length; i++)
            {
                for (int n = 0; n < cadena.Length; n++)
                {
                    if (mayusculas[i].ToString() == cadena[n].ToString())
                    {
                        return "100";
                    }

                }


            }

            for (int i = 0; i < especiales.Length; i++)
            {
                for (int n = 0; n < cadena.Length; n++)
                {
                    if (especiales[i].ToString() == cadena[n].ToString())
                    {
                        return "100";
                    }

                }


            }

            #endregion

            return "V";
        }

        // valida que no se meta caracteres sql injection (codig error - 101)
        public string ValidarCadena(string cadena)
        {
            for (int i = 0; i < especiales.Length; i++)
            {
                for (int n = 0; n < cadena.Length; n++)
                {
                    if (especiales[i].ToString() == cadena[n].ToString())
                    {
                        return "101";
                    }

                }


            }



            return "V";
        }

        // valida que se seleccione el tipo de identificacion (codig error - 102)
        public string ValidarDropDownList(string cadena)
        {
            if (cadena == "Seleccione")
            {
                return "102";
            }
            else
            {
                return "V";
            }

        }

        // valida que no haya campos en blanco (codig error - 103)
        public string ValidarCadenaVacia(string cadena)
        {
            if (cadena.Length == 0)
            {
                return "103";

            }
            else
            {
                return "V";
            }

        }
    }
}
