using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BibliotecaException;

namespace Entidades
{
    public class BD_Productos
    {

        private static string conexion;

        static BD_Productos()
        {
            BD_Productos.conexion = "Server=.;Database=BD_Productos;Trusted_Connection=True;";
        }
        /// <summary>
        /// Lee la base de datos y retorna una lista de todos los productos leidos
        /// </summary>
        /// <returns></returns>
        public static List<Producto> ObtenerCatalogoProductos()
        {
            try
            {
                List<Producto> catalogo = new List<Producto>();
                string query = "select * from CatalogoProductos";
                using (SqlConnection connection = new SqlConnection(BD_Productos.conexion))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string nombre = reader.GetString(1);
                        string marca = reader.GetString(2);
                        string tipo = reader.GetString(3);
                        float precio = (float)reader.GetDouble(4);
                        Producto producto = new Producto(id, nombre, marca, tipo, precio);
                        catalogo.Add(producto);
                    }
                }
                return catalogo;
            }
            catch (Exception)
            {
                throw new ErrorBaseDatosException("Ocurrio un error al cargar el catalogo de productos");
            }
        }

        /// <summary>
        /// Busca en la base de datos si el producto ya existe en la base de datos, en caso de que exista, invoca el Action recibido por parametro
        /// </summary>
        /// <param name="producto"></param>
        /// <param name="accion"> </param>
        /// <returns></returns>
        public static bool VerificarSiExiste(Producto producto, Action accion)
        {
            try
            {
                bool resultado = false;
                string query = "select id from CatalogoProductos where nombre=@nombre and marca=@marca and tipo=@tipo";
                using (SqlConnection connection = new SqlConnection(BD_Productos.conexion))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("marca", producto.Marca);
                    cmd.Parameters.AddWithValue("tipo", producto.Tipo);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        if (id > -1)
                        {
                            resultado = true;
                        }
                    }
                    if (resultado && accion is not null)
                    {
                        accion.Invoke();
                    }
                }
                return resultado;
            }
            catch (Exception)
            {
                throw new ErrorBaseDatosException("Ocurrió un error al verificar si existe el producto");
            }
        }

        /// <summary>
        /// Agrega el producto recibido por parametros, a la base de datos.
        /// </summary>
        /// <param name="producto"></param>
        public static void AgregarProducto(Producto producto)
        {
            try
            {
                string query = "insert into CatalogoProductos (nombre, marca, tipo, precio) values (@nombre, @marca, @tipo, @precio)";
                using (SqlConnection connection = new SqlConnection(BD_Productos.conexion))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("marca", producto.Marca);
                    cmd.Parameters.AddWithValue("tipo", producto.Tipo);
                    cmd.Parameters.AddWithValue("precio", producto.Precio);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new ErrorBaseDatosException("Ocurrió un error al agregar el producto");
            }
        }

        /// <summary>
        /// Actualiza los datos del producto recibido, en la base de datos.
        /// </summary>
        /// <param name="producto"></param>
        public static void ActualizarProducto(Producto producto)
        {
            try
            {
                string query = "update CatalogoProductos set nombre=@nombre , marca=@marca , tipo=@tipo , precio=@precio where id=@id";
                using (SqlConnection connection = new SqlConnection(BD_Productos.conexion))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("id", producto.Id);
                    cmd.Parameters.AddWithValue("nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("marca", producto.Marca);
                    cmd.Parameters.AddWithValue("tipo", producto.Tipo);
                    cmd.Parameters.AddWithValue("precio", producto.Precio);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new ErrorBaseDatosException("Ocurrió un error al actualizar el producto");
            }
        }

        /// <summary>
        /// Elimina el producto recibido por parametro, de la base de datos.
        /// </summary>
        /// <param name="producto"></param>
        public static void EliminarProducto(Producto producto)
        {
            try
            {
                string query = "delete from CatalogoProductos where id=@id";
                using (SqlConnection connection = new SqlConnection(BD_Productos.conexion))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    cmd.Parameters.AddWithValue("id", producto.Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new ErrorBaseDatosException("Ocurrió un error al eliminar el producto");
            }
        }
        /// <summary>
        /// Lee la base de datos y la ordena de acuerdo al criterio especificado y retorna una lista con su contenido.
        /// </summary>
        /// <param name="criterio"></param>
        /// <returns></returns>
        public static List<Producto> ObtenerCatalogoProductosOrdenado(string criterio)
        {            
            List<Producto> catalogo = new List<Producto>();
            string query = $"select * from CatalogoProductos order by {criterio}"; //Intenté usar el @criterio pero me tiraba exception siempre
            using (SqlConnection connection = new SqlConnection(BD_Productos.conexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    string marca = reader.GetString(2);
                    string tipo = reader.GetString(3);
                    float precio = (float)reader.GetDouble(4);
                    Producto producto = new Producto(id, nombre, marca, tipo, precio);
                    catalogo.Add(producto);
                }
            }
            return catalogo;
        }

        /// <summary>
        /// Retorna una lista ordenada segun el criterio recibido por parametros
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        public static List<Producto> OrdenarCatalogoProductos(EDatosProducto dato)
        {            
            try
            {
                List<Producto> catalogo = null;
                switch (dato)
                {
                    case EDatosProducto.NombreAsc:
                        catalogo = ObtenerCatalogoProductosOrdenado("nombre asc");
                        break;
                    case EDatosProducto.NombreDesc:
                        catalogo = ObtenerCatalogoProductosOrdenado("nombre desc");
                        break;
                    case EDatosProducto.MarcaAsc:
                        catalogo = ObtenerCatalogoProductosOrdenado("marca asc");
                        break;
                    case EDatosProducto.MarcaDesc:
                        catalogo = ObtenerCatalogoProductosOrdenado("marca desc");
                        break;
                    case EDatosProducto.TipoAsc:
                        catalogo = ObtenerCatalogoProductosOrdenado("tipo asc");
                        break;
                    case EDatosProducto.TipoDesc:
                        catalogo = ObtenerCatalogoProductosOrdenado("tipo desc");
                        break;
                    case EDatosProducto.PrecioAsc:
                        catalogo = ObtenerCatalogoProductosOrdenado("precio asc");
                        break;
                    case EDatosProducto.PrecioDesc:
                        catalogo = ObtenerCatalogoProductosOrdenado("precio desc");
                        break;
                }
                return catalogo;
            }
            catch (Exception)
            {
                throw new ErrorBaseDatosException("Ocurrió un error al ordenar los productos");
            }
        }
    }
}
