using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public interface IMensaje
    {
        string MensajeError(Exception error);
    }
}
