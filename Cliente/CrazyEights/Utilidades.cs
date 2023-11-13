using CrazyEights.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace CrazyEights
{
    internal class Utilidades
    {
        public static bool ValidarNombreUsuario(string nombreUsuario)
        {
            bool esNombreUsuarioValido = false;
            if (nombreUsuario.Length >= 6)
            {
                esNombreUsuarioValido = true;
            }

            return esNombreUsuarioValido;
        }

        public static bool ValidarCorreoElectronico(string correoElectronico)
        {
            bool esCorreoValido = false;
            if (Regex.IsMatch(correoElectronico, "^[a-zA-Z0-9\\-_]{5,20}@(gmail|outlook|hotmail)\\.com$"))
            {
                esCorreoValido = true;
            }

            return esCorreoValido;
        }

        public static bool ValidarContrasena(string contrasena)
        {
            bool esContrasenaValida = false;
            if (Regex.IsMatch(contrasena, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[$@$!%*?&#.$($)\\-_])[A-Za-z\\d$@$!%*?&#.$($)\\-_]{8,16}$"))
            {
                esContrasenaValida = true;
            }

            return esContrasenaValida;
        }
    }
}
