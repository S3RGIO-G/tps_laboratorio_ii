using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Entidades;
using BibliotecaException;
using System.IO;

namespace Aplicacion
{
    public partial class FrmPrincipal : Form 
    {
        public Ventas venta;
        public List<Cliente> clientes;
        CancellationTokenSource cts;
        public FrmPrincipal()
        {
            InitializeComponent();
            this.venta = new Ventas();
            this.clientes = new List<Cliente>();
            this.cts = new CancellationTokenSource();
            this.imgHistorial.Visible = false;
            this.ActualizarLista();                        
            cmbOrdenarHistorial.Items.Add(EDatosProducto.NombreAsc);
            cmbOrdenarHistorial.Items.Add(EDatosProducto.NombreDesc);
            cmbOrdenarHistorial.Items.Add(EDatosProducto.MarcaAsc);
            cmbOrdenarHistorial.Items.Add(EDatosProducto.MarcaDesc);
            cmbOrdenarHistorial.Items.Add(EDatosProducto.TipoAsc);
            cmbOrdenarHistorial.Items.Add(EDatosProducto.TipoDesc);
            cmbOrdenarHistorial.Items.Add(EDatosProducto.PrecioAsc);
            cmbOrdenarHistorial.Items.Add(EDatosProducto.PrecioDesc);
        }

        #region Eventos del Formulario

        /// <summary>
        /// Agrega un nuevo cliente 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            FrmNuevoCliente frmNuevoCliente = new FrmNuevoCliente();
            frmNuevoCliente.Lista = this.clientes;
            if (frmNuevoCliente.ShowDialog() == DialogResult.OK)
            {
                this.Actualizar(frmNuevoCliente.Cliente, cts.Token);
                this.venta.Usuario = frmNuevoCliente.Cliente;
            }
        }
        /// <summary>
        /// Despliega el panel para seleccionar/modificar/eliminar un usuario ya existente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargarCliente_Click(object sender, EventArgs e)
        {
            if (clientes.Count > 0)
            {
                if (lstHistorialCompras.Enabled)
                {
                    FrmCargarCliente frm = new FrmCargarCliente();
                    frm.Lista = this.clientes;
                    frm.Cliente = this.venta.Usuario;
                    if (frm.ShowDialog() == DialogResult.OK)//En el caso de que seleccione otro usuario
                    {
                        this.Actualizar(frm.Cliente, cts.Token);
                        venta.Usuario = frm.Cliente;
                    }
                    else if (this.clientes.Count > 0 && frm.Cliente is not null) //En el caso de que modifique el usuario ya seleccionado
                    {
                        this.ActualizarInformacionCliente(venta.Usuario);
                    }
                    else //En el caso de que elimine el usuario seleccionado o toda la lista
                    {
                        this.LimpiarTodosLosCampos();
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay ningun cliente cargado en el registro", "Atencion");
            }
        }
        /// <summary>
        /// Despliega una ventana para seleccionar el producto que queremos agregar al carrito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if(venta.Usuario is not null)
            {
                FrmAgregarProducto frmAgregarProducto = new FrmAgregarProducto();
                if (frmAgregarProducto.ShowDialog() == DialogResult.OK)
                {
                    this.lstCarrito.Items.Add(((IMostrar)frmAgregarProducto.Producto).MostrarInformacion());
                    this.venta.Carrito.Add(frmAgregarProducto.Producto);
                    this.AcutalizarTotalCarrito();
                }
            }
            else
            {
                MessageBox.Show("Primero tenes que ingresar un cliente", "Atención");
            }
        }
        /// <summary>
        /// Borra el item del carrito seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if(this.lstCarrito.SelectedIndex != -1)
            {
                this.venta.Carrito.RemoveAt(this.lstCarrito.SelectedIndex);
                this.lstCarrito.Items.RemoveAt(this.lstCarrito.SelectedIndex);
                this.AcutalizarTotalCarrito();
            }
        }
        /// <summary>
        /// Borra todos los items del carrito
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBorrarTodo_Click(object sender, EventArgs e)
        {
            this.lstCarrito.Items.Clear();
            this.venta.Carrito.Clear();
            this.AcutalizarTotalCarrito();
        }

        /// <summary>
        /// Despliega la ventana para confirmar la compra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            if(this.venta.Carrito.Count > 0)
            {
                FinalizarCompra frm = new FinalizarCompra();
                frm.Venta = this.venta;
                frm.RegistroDeClientes = this.clientes;
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    this.Actualizar(this.venta.Usuario, cts.Token);
                }
            }
            else
            {
                MessageBox.Show("Primero agregue algun producto al carrito", "Atencion");
            }
        }
        /// <summary>
        /// Ejecuta el evento FormClosing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Pregunta si se desea salir, en caso de aceptar, guarda el registro de clientes y catalogo de productos en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {            
            if (MessageBox.Show("¿Estas seguro que deseas salir?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                cts.Cancel();
                this.GuardarLista();
            }            
        }
        /// <summary>
        /// Cambia el orden del historial, dependiendo el criterio que se elija
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbOrdenarHistorial_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstHistorialCompras.Enabled)
                {
                    EDatosProducto dato = (EDatosProducto)cmbOrdenarHistorial.SelectedItem;
                    List<Producto> lista = Producto.OrdernarListaDeProductos(dato, venta.Usuario.HistorialDeCompra);
                    this.ActualizarHistorial(lista);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lo siento, no se pudo ordenar la lista", "Atencion");
            }
        }
        /// <summary>
        /// Despliega la ventana para agregar/modificar/eliminar productos del catalogo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGestionarCatalogo_Click(object sender, EventArgs e)
        {
            if(venta.Carrito.Count == 0)
            {
                FrmGestionarCatalogo frm = new FrmGestionarCatalogo();
                frm.ShowDialog();
                this.ActualizarCarrito();
            }
            else
            {
                MessageBox.Show("No se puede gestionar el catalogo mientras el carrito tenga productos cargados", "Atencion");
            }
        }

        #endregion

        #region Metodos
        private async void Actualizar(Cliente cliente, CancellationToken cancelToken)
        {
            this.ActualizarInformacionCliente(cliente);
            this.lstCarrito.Items.Clear();
            this.venta.Carrito.Clear();
            this.AcutalizarTotalCarrito();
            this.imgHistorial.Visible = true;
            this.lstHistorialCompras.Enabled = false;
            await Task.Run(() =>
            {
                Thread.Sleep(4000);
                if (cancelToken.IsCancellationRequested)
                {
                    throw new TaskCanceledException();
                }
            });
            this.ActualizarHistorial(cliente.HistorialDeCompra);
            this.lstHistorialCompras.Enabled = true;
            this.imgHistorial.Visible = false;
        }
        public void ActualizarHistorial(List<Producto> lista)
        {
            this.lstHistorialCompras.Items.Clear();
            foreach (Producto item in lista)
            {
                lstHistorialCompras.Items.Add(((IMostrar)item).MostrarInformacion());
            }
        }
        private void ActualizarCarrito()
        {
            lstCarrito.Items.Clear();
            foreach (Producto item in this.venta.Carrito)
            {
                lstCarrito.Items.Add(((IMostrar)item).MostrarInformacion());
            }
            this.AcutalizarTotalCarrito();
        }
        private void AcutalizarTotalCarrito()
        {
            lblTotalCarrito.Text = $"$ " + this.venta.CalcularTotalCarrito().ToString();
        }
        private void ActualizarInformacionCliente(Cliente cliente)
        {
            this.txtClienteActualNombre.Text = cliente.Nombre;
            this.txtClienteActualApellido.Text = cliente.Apellido;
            this.txtClienteActualDni.Text = cliente.Dni;
            this.txtClienteActualTipo.Text = cliente.Tipo.ToString();
            this.txtClienteActualPuntos.Text = cliente.Puntos.ToString();
        }
        private void LimpiarTodosLosCampos()
        {
            this.txtClienteActualNombre.Text = string.Empty;
            this.txtClienteActualApellido.Text = string.Empty;
            this.txtClienteActualDni.Text = string.Empty;
            this.txtClienteActualTipo.Text = string.Empty;
            this.txtClienteActualPuntos.Text = string.Empty;
            this.lstHistorialCompras.Items.Clear();
            this.lstCarrito.Items.Clear();
        }
        /// <summary>
        /// Guarda el registro de clientes y el catalogo de productos en la base de datos
        /// </summary>
        private void GuardarLista()
        {
            try
            {
                Archivo<List<Cliente>>.Serializar(this.clientes, "RegistroDeClientes", EArchivo.XML);
            }
            catch (ErrorGuardarDatosException e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
        }
        /// <summary>
        /// Carga el registro de clientes y el catalogo de productos de la base datos
        /// </summary>
        private void ActualizarLista()
        {
            try
            {
                this.clientes = Archivo<List<Cliente>>.Deserializar("RegistroDeClientes.xml", EArchivo.XML);
            }
            catch (ErrorCargarDatosException e)
            {
                MessageBox.Show(e.Message, "ERROR");
            }
        }

        

        #endregion

    }
}
