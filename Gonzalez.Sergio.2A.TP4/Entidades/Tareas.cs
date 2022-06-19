using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public static class Tareas
    {
        /// <summary>
        /// Lee la informacion de la base de datos en un hilo distinto y retorna una lista con el contenido en caso de que no se cancele la tarea.
        /// </summary>
        /// <param name="cancelToken"></param>
        /// <returns></returns>
        public static async Task<List<Producto>> ActualizarCatalogo_task(CancellationToken cancelToken)
        {
            List<Producto> catalogo = await Task.Run(() =>
            {
                Thread.Sleep(2000);
                if (cancelToken.IsCancellationRequested)
                {
                    throw new TaskCanceledException();
                }
                return BD_Productos.ObtenerCatalogoProductos();
            });
            return catalogo;
        }
    }
}
