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
    public partial class FrmGestionarCatalogo : Form
    {
        List<Producto> catalogo;
        public FrmGestionarCatalogo()
        {
            InitializeComponent();

            cmbOrdenar.Items.Add(EDatosProducto.Nombre);
            cmbOrdenar.Items.Add(EDatosProducto.Marca);
            cmbOrdenar.Items.Add(EDatosProducto.Tipo);
            cmbOrdenar.Items.Add(EDatosProducto.Precio);
        }
        public List<Producto> Catalogo { get => this.catalogo; set => this.catalogo = value; }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmGestionarCatalogo_AgregarOEditar frm = new FrmGestionarCatalogo_AgregarOEditar();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                catalogo.Add(frm.Producto);
                lstCatalogo.Items.Add(((IMostrar)frm.Producto).MostrarInformacion());
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int index = lstCatalogo.SelectedIndex;
            if (index > -1)
            {
                FrmGestionarCatalogo_AgregarOEditar frm = new FrmGestionarCatalogo_AgregarOEditar();
                frm.Producto = this.catalogo[index];
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.catalogo[index] = frm.Producto;
                    lstCatalogo.Items[index] = ((IMostrar)frm.Producto).MostrarInformacion();
                }
            }            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int index = lstCatalogo.SelectedIndex;
            if (index > -1 && MessageBox.Show("¿Estas seguro que deseas eliminar este producto?", "Atencion",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.catalogo.RemoveAt(index);
                lstCatalogo.Items.RemoveAt(index);
            }
        }
        private void FrmGestionarCatalogo_Load(object sender, EventArgs e)
        {
            foreach (Producto item in this.catalogo)
            {
                lstCatalogo.Items.Add(((IMostrar)item).MostrarInformacion());
            }
        }

        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EDatosProducto dato = (EDatosProducto)cmbOrdenar.SelectedItem;
                List<Producto> lista = Producto.OrdernarListaDeProductos(dato, catalogo);
                this.ActualizarCatalogo(lista);
            }
            catch (Exception)
            {
                MessageBox.Show("Lo siento, no se pudo ordenar la lista", "Atencion");
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void ActualizarCatalogo(List<Producto> lista)
        {
            this.lstCatalogo.Items.Clear();
            foreach (Producto item in lista)
            {
                lstCatalogo.Items.Add(((IMostrar)item).MostrarInformacion());
            }
        }

    }
}
