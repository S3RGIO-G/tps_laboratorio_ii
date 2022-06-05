using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente : Persona, IMostrar
    {
        private ETipo tipo;
        private int puntos;
        private List<Producto> historialDeCompra;

        public int Puntos { get => this.puntos; set => this.puntos = value; }
        public ETipo Tipo { get => this.tipo; set => this.tipo = value; }
        public List<Producto> HistorialDeCompra { get => this.historialDeCompra; set => this.historialDeCompra = value; }

        public Cliente() { }
        public Cliente(string nombre, string apellido, string dni, ETipo tipo, int puntos): base(nombre, apellido, dni)
        {
            this.tipo = tipo;
            this.puntos = puntos;
            this.historialDeCompra = new List<Producto>();
        }
        public Cliente(string nombre, string apellido, string dni, ETipo tipo) : this(nombre, apellido, dni, tipo, 0) //Para un cliente nuevo
        {
        }
        /// <summary>
        /// Busca si el cliente se encuentra en la lista, utiliza la sobrecarga del ==
        /// </summary>
        /// <param name="clienteBuscado"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        public static int ObtenerIndiceDelCliente(Cliente clienteBuscado, List<Cliente> lista)
        {
            int indice = -1;
            if(clienteBuscado is not null && lista != null && lista.Count > 0)
            {
                foreach (Cliente item in lista)
                {
                    if(item == clienteBuscado)
                    {
                        indice = lista.IndexOf(item);
                        break;
                    }
                }
            }
            return indice;
        }

        /// <summary>
        /// Muestra toda la informacion del cliente
        /// </summary>
        /// <returns></returns>
        string IMostrar.MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Nombre: {this.Nombre}");
            sb.AppendLine($"Apellido: {this.Apellido}");
            sb.AppendLine($"Dni: {this.Dni}");
            sb.AppendLine($"Tipo de Cliente: {this.Tipo}");
            return sb.ToString();
        }

        /// <summary>
        /// Compara dos clientes por su dni
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool operator ==(Cliente c1, Cliente c2)
        {
            return c1.dni == c2.dni;
        }
        /// <summary>
        /// Utiliza la sobrecarga del == y retorna lo contrario
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <returns></returns>
        public static bool operator !=(Cliente c1, Cliente c2)
        {
            return !(c1 == c2);
        }        

        /// <summary>
        /// Agrega los datos del cliente a los datos de la base
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + $" - {this.Tipo} - {this.puntos}";
        }
    }
}
