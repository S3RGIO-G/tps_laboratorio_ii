using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto : IMostrar
    {
        private int id;
        private string nombre;
        private string marca;
        private string tipo;
        private float precio;

        public int Id { get => id; }
        public string Nombre { get => this.nombre; set => this.nombre = value; }
        public string Marca { get => this.marca; set => this.marca = value; }
        public string Tipo { get => this.tipo; set => this.tipo = value; }
        public float Precio { get => this.precio; set => this.precio = value; }
        

        public Producto() { }
        public Producto(string nombre, string marca, string tipo, float precio)
        {
            this.nombre = nombre;
            this.marca = marca;
            this.tipo = tipo;
            this.precio = precio;
        }

        public Producto(int id, string nombre, string marca, string tipo, float precio) : this(nombre, marca, tipo, precio)
        {
            this.id = id;
        }
        /// <summary>
        /// Muestra toda la informacion del producto
        /// </summary>
        /// <returns></returns>
        string IMostrar.MostrarInformacion()
        {
            return $" Nombre: {this.nombre} - Marca: {this.Marca} - Tipo: {this.tipo} - Precio: {this.precio : $0.##}";
        }

        /// <summary>
        /// Ordena la lista que recibe por parametro de acuerdo al criterio recibido
        /// </summary>
        /// <param name="dato"> Criterio para ordenar la lista </param>
        /// <param name="lista"> Lista a ordenar </param>
        /// <returns></returns>
        public static List<Producto> OrdernarListaDeProductos(EDatosProducto dato, List<Producto> lista)
        {
            List<Producto> newList = lista;
            if(lista is not null)
            {
                switch (dato)
                {
                    case EDatosProducto.NombreAsc:
                        newList = lista.OrderBy(x=>x.Nombre).ToList();
                        break;
                    case EDatosProducto.NombreDesc:
                        newList = lista.OrderBy(x => x.Nombre).ToList();
                        newList.Reverse();
                        break;
                    case EDatosProducto.MarcaAsc:
                        newList = lista.OrderBy(x => x.Marca).ToList();
                        break;
                    case EDatosProducto.MarcaDesc:
                        newList = lista.OrderBy(x => x.Marca).ToList();
                        newList.Reverse();
                        break;
                    case EDatosProducto.TipoAsc:
                        newList = lista.OrderBy(x => x.Tipo).ToList();
                        break;
                    case EDatosProducto.TipoDesc:
                        newList = lista.OrderBy(x => x.Tipo).ToList();
                        newList.Reverse();
                        break;
                    case EDatosProducto.PrecioAsc:
                        newList = lista.OrderBy(x => x.Precio).ToList();
                        break;
                    case EDatosProducto.PrecioDesc:
                        newList = lista.OrderBy(x => x.Precio).ToList();
                        newList.Reverse();
                        break;
                }
            }
            return newList;
        }
    }
}
