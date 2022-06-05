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

        /// <summary>
        /// Despliega el Formulario para agregar un producto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmGestionarCatalogo_AgregarOEditar frm = new FrmGestionarCatalogo_AgregarOEditar();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                catalogo.Add(frm.Producto);
                lstCatalogo.Items.Add(((IMostrar)frm.Producto).MostrarInformacion());
            }
        }
        /// <summary>
        /// Le pasa el producto seleccionado al Formulario de modificacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Elimina del catalogo el producto seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int index = lstCatalogo.SelectedIndex;
            if (index > -1 && MessageBox.Show("¿Estas seguro que deseas eliminar este producto?", "Atencion",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.catalogo.RemoveAt(index);
                lstCatalogo.Items.RemoveAt(index);
            }
        }
        /// <summary>
        /// Carga el catalogo de productos al listBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmGestionarCatalogo_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (Producto item in this.catalogo)
                {
                    lstCatalogo.Items.Add(((IMostrar)item).MostrarInformacion());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR al cargar el catalodo de productos", "ERROR");
            }
        }
        /// <summary>
        /// Ordena los productos dependiendo del criterio seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        /// PIDO DISCULPAS POR USAR UN LISTBOX, PARA EL TP4 PROMETO USAR UN DATAGRID
        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EDatosProducto dato = (EDatosProducto)cmbOrdenar.SelectedItem;
                catalogo = Producto.OrdernarListaDeProductos(dato, catalogo);
                this.ActualizarCatalogo(catalogo);
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
        /// <summary>
        /// Carga los datos de la lista pasada por parametros al listbox
        /// </summary>
        /// <param name="lista"></param>
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
