using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ventas: IMostrar
    {
        private Cliente usuario;
        private List<Producto> carrito;
        private float totalCarrito;
        private float descuento;

        public Ventas()
        {
            this.carrito = new List<Producto>();
        }

        public Cliente Usuario { get => this.usuario; set => this.usuario = value; }
        public List<Producto> Carrito { get => this.carrito; set => this.carrito = value; }
        public float TotalCarrito { get => this.totalCarrito; set => this.totalCarrito = value; }        
        public float Descuento { get => this.descuento; }
        /// <summary>
        /// Resta los puntos del usuario al total del carrito y retorna el resutado
        /// </summary>
        /// <returns></returns>
        public float UsarPuntosDeCliente()
        {
            float total =  this.totalCarrito - this.usuario.Puntos;
            return total;
        }
        /// <summary>
        /// Calcula el descuento que se aplica por se Premium y lo retorna
        /// </summary>
        /// <returns></returns>
        public float CalcularDescuento()
        {
            this.descuento = 0;
            if(this.usuario.Tipo == ETipo.Premium)
            {
                this.descuento = this.totalCarrito * (float) 0.13;
            }
            return this.descuento;
        }
        /// <summary>
        /// Calcula la cantidad de puntos que obtiene el usuario
        /// </summary>
        /// <param name="totalDeCompra"></param>
        /// <returns></returns>
        public static int CalcularPuntos(float totalDeCompra)
        {
            int puntos =  (int) (totalDeCompra * (float) 0.05) ;
            return puntos; 
        }
        /// <summary>
        /// Suma todos los precios de los productos dentro de la lista y se lo asigna al totalCarrito
        /// </summary>
        /// <returns></returns>
        public float CalcularTotalCarrito()
        {
            this.totalCarrito = 0;
            foreach (Producto item in this.carrito)
            {
                this.totalCarrito += item.Precio;
            }
            return this.totalCarrito;
        }
        /// <summary>
        /// Muestra toda la informacion de del Cliente y todos los elementos del carrito
        /// </summary>
        /// <returns></returns>
        string IMostrar.MostrarInformacion()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(((IMostrar)this.Usuario).MostrarInformacion());
            sb.AppendLine($"\n--------------- PRODUCTOS COMPRADOS ---------------\n");
            foreach (Producto item in this.Carrito)
            {
                sb.AppendLine(((IMostrar)item).MostrarInformacion());
            }
            sb.AppendLine($"\n--------------- --------------- ---------------");
            return sb.ToString();
        }
    }
}
