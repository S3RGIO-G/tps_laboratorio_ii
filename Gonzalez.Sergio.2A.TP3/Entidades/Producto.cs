using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto : IMostrar
    {
        private string nombre;
        private string marca;
        private string tipo;
        private float precio;

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
                    case EDatosProducto.Nombre:
                        newList = lista.OrderBy(x=>x.Nombre).ToList();
                        break;
                    case EDatosProducto.Marca:
                        newList = lista.OrderBy(x => x.Marca).ToList();
                        break;
                    case EDatosProducto.Tipo:
                        newList = lista.OrderBy(x => x.Tipo).ToList();
                        break;
                    case EDatosProducto.Precio:
                        newList = lista.OrderBy(x => x.Precio).ToList();
                        break;
                }
            }
            return newList;
        }
    }
}
