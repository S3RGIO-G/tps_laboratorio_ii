using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class VentaExtendido
    {
        /// <summary>
        /// Calcula la cantidad de puntos que obtiene el usuario
        /// </summary>
        /// <param name="venta"></param>
        /// <returns></returns>
        public static int CalcularPuntos(this Ventas venta)
        {
            return (int)(venta.TotalCarrito * (float)0.05);
        }
        /// <summary>
        /// Resta los puntos del usuario al total del carrito y retorna el resutado
        /// </summary>
        /// <param name="venta"></param>
        /// <returns></returns>
        public static float UsarPuntosDelCliente(this Ventas venta) 
        {
            return venta.TotalCarrito - venta.Usuario.Puntos;
        }
        /// <summary>
        /// Retorna la descripcion del producto mas caro encontrado en la lista recorrida
        /// </summary>
        /// <param name="venta"></param>
        /// <returns></returns>
        public static string ObtenerDescripcionProductoMasCaro(this Ventas venta)
        {
            Producto  producto = null;
            float precioMasAlto = 0;
            bool flag = true;
            venta.Carrito.ForEach(x => 
            {
                if (flag || precioMasAlto < x.Precio)
                {
                    precioMasAlto = x.Precio;
                    producto = x;
                    flag = false;
                }
            });
            return $"El producto mas caro es: {producto.Nombre} - {producto.Marca} - {producto.Tipo} - $ {producto.Precio}";
        }
    }
}
