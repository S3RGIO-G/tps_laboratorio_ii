using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.IO;
using BibliotecaEventArgs;

namespace Aplicacion
{
    public partial class FinalizarCompra : Form
    {
        private Ventas venta;
        private List<Cliente> registroDeClientes;
        private bool puntosUsados = false;
        private int puntosGastados = 0;
        private int puntosObtenidos = 0;
        public FinalizarCompra()
        {
            InitializeComponent();
        }

        public Ventas Venta { get => this.venta; set => this.venta = value; }
        public List<Cliente> RegistroDeClientes { get => this.registroDeClientes; set => this.registroDeClientes = value; }

        private void FrmFinalizarCompra_Load(object sender, EventArgs e)
        {
            this.CargarInformacion();
            if(this.venta.Usuario.Puntos == 0)
            {
                this.btnUsarPuntos.Enabled = false;
            }
            venta.EventoTicket += this.EmitirTicketRecibido;
        }
        /// <summary>
        /// Usa los puntos que el cliente tenga para descontarlo al total de la compra
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUsarPuntos_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Seguro que deseas usar los puntos?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lblTotalCarrito.Text = $"$ {this.venta.UsarPuntosDelCliente() - this.venta.Descuento: 0.##}"; //Utilizo su extensión
                this.txtClienteActualPuntos.Text = "0";
                puntosGastados = this.venta.Usuario.Puntos;
                this.btnUsarPuntos.Enabled = false;
                puntosUsados = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// si se confirma la compra, se suman los puntos ganados y se actualiza el historial de compra del cliente. Ademas se emite un ticket
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro que deseas confirmar la compra?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(puntosUsados)
                {
                    this.venta.TotalCarrito = this.venta.UsarPuntosDelCliente(); //Utilizo su extensión
                    this.venta.Usuario.Puntos = 0;                    
                }
                this.venta.TotalCarrito -= this.venta.Descuento;
                this.venta.Usuario.Puntos += this.puntosObtenidos;
                venta.EjecutarEmisionDeTicket("GRACIAS POR SU COMPRA");
                this.ActualizarHistorialDelCliente();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void CargarInformacion()
        {
            this.txtClienteActualNombre.Text = venta.Usuario.Nombre;
            this.txtClienteActualApellido.Text = venta.Usuario.Apellido;
            this.txtClienteActualDni.Text = venta.Usuario.Dni;
            this.txtClienteActualTipo.Text = venta.Usuario.Tipo.ToString();
            this.txtClienteActualPuntos.Text = venta.Usuario.Puntos.ToString();

            lblDescuento.Text = $"$ {this.venta.CalcularDescuento():0.##}";
            lblTotalCarrito.Text = $"$ {this.venta.TotalCarrito - this.venta.Descuento: 0.##}";
            puntosObtenidos = this.venta.CalcularPuntos(); //Utilizo su extensión
            lblPuntosObtenidos.Text = $"{puntosObtenidos}";

            dtaGrdCarrito.DataSource = this.venta.Carrito;
            dtaGrdCarrito.Columns.Remove(dtaGrdCarrito.Columns[0]);
            this.lblProductoMasCaro.Text = venta.ObtenerDescripcionProductoMasCaro();

        }

        /// <summary>
        /// Es el meotodo que se asocia a EventoTicket, simula la emision de un ticket
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EmitirTicketRecibido(Ventas sender, VentaEventArgs e)
        {
            string path = $"../../../../Base de datos/Ticket_{sender.Usuario.Nombre}_{sender.Usuario.Apellido}-" + DateTime.Now.ToString("HH-mm-ss") + ".txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine($"*************** Este es un Ticket de compra *************** \n");
                    sw.WriteLine(((IMostrar)sender).MostrarInformacion());
                    sw.WriteLine("Fecha: " + DateTime.Now.ToString());
                    sw.WriteLine($"Total: $ {sender.TotalCarrito}");
                    sw.WriteLine($"Descuento aplicado: $ {sender.Descuento}");
                    sw.WriteLine($"Puntos gastados: {this.puntosGastados}");
                    sw.WriteLine($"Puntos obtenidos por comprar: {this.puntosObtenidos}");
                    sw.WriteLine($"\n*************** {e.Contenido} ***************");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al emitir ticket", "ERROR");
            }
        }

        /// <summary>
        /// Agrega los productos del carrio al historial del cliente
        /// </summary>
        private void ActualizarHistorialDelCliente()
        {
            foreach (Producto item in venta.Carrito)
            {
                venta.Usuario.HistorialDeCompra.Add(item);
            }            
            int indice = Cliente.ObtenerIndiceDelCliente(venta.Usuario, registroDeClientes);
            registroDeClientes[indice] = venta.Usuario;
        }
    }
}
