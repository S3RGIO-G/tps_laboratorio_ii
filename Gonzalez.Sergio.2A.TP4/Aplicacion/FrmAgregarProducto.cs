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

namespace Aplicacion
{
    public partial class FrmAgregarProducto : Form
    {
        private Producto producto;
        private List<Producto> lista;
        CancellationTokenSource cts;

        public Producto Producto
        {
            get
            {
                return this.producto;
            }
        }

        public List<Producto> Lista { get => this.lista; set => this.lista = value; }

        public FrmAgregarProducto()
        {
            InitializeComponent();
            cts = new CancellationTokenSource();
        }

        /// <summary>
        /// Confirma la seleccion del producto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(cmbProducto.SelectedIndex > -1)
            {
                this.producto = new Producto(this.cmbProducto.Text, this.txtMarca.Text, this.txtTipo.Text, float.Parse(this.txtPrecio.Text));
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Carga el catalogo de productos al comboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FrmAgregarProducto_Load(object sender, EventArgs e)
        {
            try
            {
                cmbProducto.Enabled = false;
                lista = await Task.Run(()=> 
                {
                    Thread.Sleep(800);
                    if (cts.Token.IsCancellationRequested)
                    {
                        throw new TaskCanceledException();
                    }
                    return BD_Productos.ObtenerCatalogoProductos();
                });
                foreach (Producto item in lista)
                {
                    cmbProducto.Items.Add(item.Nombre);
                }
                cmbProducto.Enabled = true;
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Se cancelo la carga de los productos", "ATENCION");
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR, falló la carga de los productos.", "ERROR");
            }            
        }

        /// <summary>
        /// Actualiza los datos de los TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = cmbProducto.SelectedIndex;

            this.txtMarca.Text = lista[indice].Marca;
            this.txtTipo.Text = lista[indice].Tipo;
            this.txtPrecio.Text = lista[indice].Precio.ToString();
        }

        private void FrmAgregarProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            cts.Cancel();
        }
    }
}
