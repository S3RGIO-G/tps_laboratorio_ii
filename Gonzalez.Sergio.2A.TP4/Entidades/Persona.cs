using System;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Cliente))]
    public class Persona
    {
        protected string nombre;
        protected string apellido;
        protected string dni;

        public string Nombre { get => this.nombre; set => this.nombre = value; }
        public string Apellido { get => this.apellido; set => this.apellido = value; }
        public string Dni { get => this.dni; set => this.dni = value; }
        public Persona() { }
        public Persona(string nombre, string apellido, string dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
        }
        
        /// <summary>
        /// Verifica que la cadena recibida solo contenga numeros
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static bool VerificarStringSoloNumeros(string cadena)
        {
            bool resultado = false;
            if (!string.IsNullOrEmpty(cadena))
            {                
                resultado = true;
                foreach (char item in cadena)
                {
                    if (!char.IsDigit(item))
                    {
                        resultado = false;
                    }
                }
            }
            return resultado;
        }
        /// <summary>
        /// Verifica que la cadena recibida solo contenga letras
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static bool VerificarStringSoloLetras(string cadena)
        {
            bool resultado = false;
            if (!string.IsNullOrEmpty(cadena))
            {
                resultado = true;
                foreach (char item in cadena)
                {
                    if (!char.IsLetter(item))
                    {
                        resultado = false;
                    }
                }
            }
            return resultado;
        }
        /// <summary>
        /// Muestra la informacion de la persona
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.nombre} - {this.apellido} - {this.dni}";
        }

    }
}
