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
    public partial class FrmGestionarCatalogo_AgregarOEditar : Form
    {
        Producto producto;

        public Producto Producto { get => this.producto; set => this.producto = value; }

        public FrmGestionarCatalogo_AgregarOEditar()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Guarda el producto dependiendo si se presionó "Agregar" o "Modificar"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Persona.VerificarStringSoloLetras(this.txtNombre.Text) && Persona.VerificarStringSoloLetras(this.txtMarca.Text) && Persona.VerificarStringSoloLetras(this.txtTipo.Text) &&  float.TryParse(this.txtPrecio.Text, out float precio))
            {
                if(MessageBox.Show("¿Estas seguro que deseas continuar?", "Atencion",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (this.producto is null)
                    {
                        producto = new Producto(this.txtNombre.Text, this.txtMarca.Text, this.txtTipo.Text, precio);
                    }
                    else
                    {
                        producto.Nombre = this.txtNombre.Text;
                        producto.Marca = this.txtMarca.Text;
                        producto.Tipo = this.txtTipo.Text;
                        producto.Precio = precio;
                    }

                    this.DialogResult = DialogResult.OK;
                }                
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Carga los datos del producto si es que esta cargado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmGestionarCatalogo_AgregarOEditar_Load(object sender, EventArgs e)
        {
            if(producto is not null)
            {
                this.txtNombre.Text = producto.Nombre;
                this.txtMarca.Text = producto.Marca;
                this.txtTipo.Text = producto.Tipo;
                this.txtPrecio.Text = producto.Precio.ToString();
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}
