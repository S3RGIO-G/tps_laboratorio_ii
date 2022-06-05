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
using BibliotecaException;

namespace Aplicacion
{
    public partial class FrmCargarCliente : Form
    {
        private Cliente cliente;
        private List<Cliente> lista;
        public FrmCargarCliente()
        {
            InitializeComponent();
        }

        public List<Cliente> Lista { get => this.lista; set => this.lista = value; }
        public Cliente Cliente { get => this.cliente; set => this.cliente = value; }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Carga el registro de clientes al listBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCargarCliente_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (Cliente item in lista)
                {
                    lstRegistroClientes.Items.Add(item.ToString());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR al cargar la lista de clientes", "ERROR");
            }
        }

        /// <summary>
        /// Selecciona el cliente solo si es diferente al cliente actual
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            int indice = lstRegistroClientes.SelectedIndex;
            if(indice > -1)
            {
                if(cliente is null || cliente != lista[indice])
                {
                    this.cliente = lista[indice];
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Ese cliente ya esta seleccionado", "Atencion");
                }
            }
        }
        /// <summary>
        /// Elimina el cliente seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int indice = lstRegistroClientes.SelectedIndex;
            if (indice > -1 && MessageBox.Show("¿Estas seguro que quieres eliminar este usuario?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.lista.RemoveAt(indice);
                this.lstRegistroClientes.Items.RemoveAt(indice);
                this.cliente = null;
            }
        }

        /// <summary>
        /// Busca a un cliente por DNI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarPorDni_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtBuscarPorDni.Text) && lista != null)
            {
                string dni = txtBuscarPorDni.Text;
                int indice = -1;

                foreach (Cliente item in lista)
                {
                    if(item.Dni == dni)
                    {
                        indice = lista.IndexOf(item);
                        break;
                    }
                }

                if(indice != -1)
                {
                    lstRegistroClientes.SelectedIndex = indice;
                }
            }
        }
        /// <summary>
        /// Envia el cliente seleccionado al Form de modificacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int indice = this.lstRegistroClientes.SelectedIndex;
            if(indice > -1)
            {
                FrmCargarCliente_Modificar frm = new FrmCargarCliente_Modificar();
                frm.Cliente = this.lista[indice];
                frm.CargarInformacionCliente();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.lista[indice] = frm.Cliente;
                    this.lstRegistroClientes.Items[indice] = frm.Cliente.ToString();
                }
            }            
        }

        private void txtBuscarPorDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
