using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace negocio
{
    public class Validaciones
    {
        public bool validaTextoVacio(object control)
        {
            if (control is TextBox texto)
            {
                return string.IsNullOrWhiteSpace(texto.Text);
            }
            return true; 
        }


        public bool validarSoloLetras(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsLetter(caracter))){
                    return false;
                }
            }
            return true;
        }
    

        public static bool validarSoloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                {
                    return false;
                }
            }
            return true;
        }
    }

}
