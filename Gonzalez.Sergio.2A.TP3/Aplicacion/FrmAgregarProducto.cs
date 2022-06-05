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

namespace Aplicacion
{
    public partial class FrmAgregarProducto : Form
    {
        private Producto producto;
        private List<Producto> lista;

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
        private void FrmAgregarProducto_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (Producto item in lista)
                {
                    cmbProducto.Items.Add(item.Nombre);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error, fallo la carga de los productos.", "Error");
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
    }
}
