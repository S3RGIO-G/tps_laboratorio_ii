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
    public partial class FrmNuevoCliente : Form
    {
        private Cliente cliente;
        private List<Cliente> lista;
        public FrmNuevoCliente()
        {
            InitializeComponent();
            cmbTipo.Items.Add(ETipo.NoPremium);
            cmbTipo.Items.Add(ETipo.Premium);
            cmbTipo.SelectedIndex = 0;
        }

        public Cliente Cliente
        {
            get
            {
                return this.cliente;
            }
        }

        public List<Cliente> Lista { get => this.lista; set => this.lista = value; }

        /// <summary>
        /// Agrega un nuevo cliente solo si el dni no coincide con el de otro ya cargado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(Persona.VerificarStringSoloLetras(txtNombre.Text) && Persona.VerificarStringSoloLetras(txtApellido.Text) && Persona.VerificarStringSoloNumeros(txtDni.Text))
            {
                ETipo tipo = (ETipo)cmbTipo.SelectedItem;
                cliente = new Cliente(this.txtNombre.Text, this.txtApellido.Text, this.txtDni.Text, tipo);
                if (Cliente.ObtenerIndiceDelCliente(cliente, lista) == -1)
                {
                    if (MessageBox.Show("¿Estas seguro que quieres guardar este usuario?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        lista.Add(cliente);
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else
                {
                    MessageBox.Show("Ya existe un usuario con ese DNI, porfavor puebe cargando el cliente", "ERROR");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
