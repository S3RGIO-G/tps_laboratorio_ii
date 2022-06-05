using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaException
{
    public class ErrorGuardarDatosException : Exception
    {
        public ErrorGuardarDatosException()
        {
        }

        public ErrorGuardarDatosException(string message) : base(message)
        {
        }

        public ErrorGuardarDatosException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
