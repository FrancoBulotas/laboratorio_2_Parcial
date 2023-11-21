using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public interface ILoginUsuario
    {
        Dictionary<string, string> ValidarUsuarioLogin(string nombreIngresado, string contraseniaIngresada);
    }
}
