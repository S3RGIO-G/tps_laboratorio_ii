using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaException
{
    public class ErrorBaseDatosException : Exception
    {
        public ErrorBaseDatosException()
        {
        }

        public ErrorBaseDatosException(string message) : base(message)
        {
        }

        public ErrorBaseDatosException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
