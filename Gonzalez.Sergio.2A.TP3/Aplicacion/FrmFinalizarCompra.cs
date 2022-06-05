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

namespace Aplicacion
{
    public partial class FrmFinalizarCompra : Form
    {
        private Ventas venta;
        private List<Cliente> registroDeClientes;
        private bool puntosUsados = false;
        private int puntosGastados = 0;
        private int puntosObtenidos = 0;
        public FrmFinalizarCompra()
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
        }

        private void btnUsarPuntos_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Seguro que deseas usar los puntos?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lblTotalCarrito.Text = $"$ {this.venta.UsarPuntosDeCliente() - this.venta.Descuento: 0.##}";
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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro que deseas confirmar la compra?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(puntosUsados)
                {
                    this.venta.TotalCarrito = this.venta.UsarPuntosDeCliente();
                    this.venta.Usuario.Puntos = 0;                    
                }
                this.venta.TotalCarrito -= this.venta.Descuento;
                this.venta.Usuario.Puntos += this.puntosObtenidos;
                this.EmitirTicket();
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
            puntosObtenidos = Ventas.CalcularPuntos(this.venta.TotalCarrito);
            lblPuntosObtenidos.Text = $"{puntosObtenidos}";

            foreach (Producto item in venta.Carrito)
            {
                lstCarrito.Items.Add(((IMostrar)item).MostrarInformacion());
            }
        }

        public void EmitirTicket()
        {
            string path = $"../../../../Base de datos/Ticket_{venta.Usuario.Nombre}_{venta.Usuario.Apellido}-" + DateTime.Now.ToString("HH-mm-ss") + ".txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine($"*************** Este es un Ticket de compra *************** \n");
                    sw.WriteLine(((IMostrar)venta).MostrarInformacion()) ; //Uso la interfaz IMostrar
                    sw.WriteLine("Fecha: " + DateTime.Now.ToString());
                    sw.WriteLine($"Total: $ {venta.TotalCarrito}");
                    sw.WriteLine($"Descuento aplicado: $ {venta.Descuento}");
                    sw.WriteLine($"Puntos gastados: {this.puntosGastados}");
                    sw.WriteLine($"Puntos obtenidos por comprar: {this.puntosObtenidos}");
                    sw.WriteLine($"\n*************** GRACIAS POR SU COMPRA ***************");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al emitir ticket","ERROR");
            }
        }

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
