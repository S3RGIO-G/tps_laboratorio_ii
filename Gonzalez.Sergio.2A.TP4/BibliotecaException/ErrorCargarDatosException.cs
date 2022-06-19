using System;
using System.Runtime.Serialization;

namespace BibliotecaException
{
    public class ErrorCargarDatosException : Exception
    {
        public ErrorCargarDatosException()
        {
        }

        public ErrorCargarDatosException(string message) : base(message)
        {
        }

        public ErrorCargarDatosException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
