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
    public partial class FrmCargarCliente_Modificar : Form
    {
        private Cliente cliente;
        public FrmCargarCliente_Modificar()
        {
            InitializeComponent();

            cmbTipo.Items.Add(ETipo.NoPremium);
            cmbTipo.Items.Add(ETipo.Premium);
        }

        public Cliente Cliente { get => cliente; set => cliente = value; }

        public void CargarInformacionCliente()
        {
            this.txtNombre.Text = cliente.Nombre;
            this.txtApellido.Text = cliente.Apellido;
            this.cmbTipo.SelectedItem = cliente.Tipo;
        }

        /// <summary>
        /// Confirma la modificacion del hecha al cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro que quieres modificar el cliente?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Persona.VerificarStringSoloLetras(txtNombre.Text) && Persona.VerificarStringSoloLetras(txtApellido.Text))
                {
                    this.cliente.Nombre = this.txtNombre.Text;
                    this.cliente.Apellido = this.txtApellido.Text;
                    this.cliente.Tipo = (ETipo) this.cmbTipo.SelectedItem;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Por favor, rellene los campos con datos validos", "ADVERTENCIA");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }

}
