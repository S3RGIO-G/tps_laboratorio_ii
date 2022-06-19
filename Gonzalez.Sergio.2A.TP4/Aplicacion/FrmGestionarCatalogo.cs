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
using BibliotecaException;

namespace Aplicacion
{
    public partial class FrmGestionarCatalogo : Form
    {
        List<Producto> catalogo;
        CancellationTokenSource cts;
        public FrmGestionarCatalogo()
        {
            InitializeComponent();
            cts = new CancellationTokenSource();

            cmbOrdenar.Items.Add(EDatosProducto.NombreAsc);
            cmbOrdenar.Items.Add(EDatosProducto.NombreDesc);
            cmbOrdenar.Items.Add(EDatosProducto.MarcaAsc);
            cmbOrdenar.Items.Add(EDatosProducto.MarcaDesc);
            cmbOrdenar.Items.Add(EDatosProducto.TipoAsc);
            cmbOrdenar.Items.Add(EDatosProducto.TipoDesc);
            cmbOrdenar.Items.Add(EDatosProducto.PrecioAsc);
            cmbOrdenar.Items.Add(EDatosProducto.PrecioDesc);
        }
        public List<Producto> Catalogo { get => this.catalogo; set => this.catalogo = value; }

        /// <summary>
        /// Despliega el Formulario para agregar un producto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dtagrdCatalogo.Enabled)
            {
                FrmGestionarCatalogo_AgregarOEditar frm = new FrmGestionarCatalogo_AgregarOEditar();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        BD_Productos.AgregarProducto(frm.Producto);
                        this.ActualizarCatalogo();
                    }
                    catch (ErrorBaseDatosException x)
                    {
                        MessageBox.Show(x.Message, "ERROR");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Algo salio mal", "ERROR");
                    }
                }
            }
        }
        /// <summary>
        /// Le pasa el producto seleccionado al Formulario de modificacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtagrdCatalogo.Enabled)
            {
                FrmGestionarCatalogo_AgregarOEditar frm = new FrmGestionarCatalogo_AgregarOEditar();
                frm.Producto = (Producto)this.dtagrdCatalogo.CurrentRow.DataBoundItem;
                if (frm.ShowDialog() == DialogResult.OK)
                {                    
                    try
                    {
                        BD_Productos.ActualizarProducto(frm.Producto);
                        this.dtagrdCatalogo.Refresh();
                    }
                    catch (ErrorBaseDatosException x)
                    {
                        MessageBox.Show(x.Message, "ERROR");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Algo salio mal", "ERROR");
                    }
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
            if (dtagrdCatalogo.Enabled)
            {
                if (MessageBox.Show("¿Estas seguro que deseas eliminar este producto?", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {                    
                    try
                    {
                        BD_Productos.EliminarProducto((Producto)dtagrdCatalogo.CurrentRow.DataBoundItem);
                        this.ActualizarCatalogo();
                    }
                    catch (ErrorBaseDatosException x)
                    {
                        MessageBox.Show(x.Message, "ERROR");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Algo salio mal", "ERROR");
                    }
                }
            }
        }
        /// <summary>
        /// Carga el catalogo de productos al listBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FrmGestionarCatalogo_Load(object sender, EventArgs e)
        {
            try
            {                
                dtagrdCatalogo.Enabled = false;
                dtagrdCatalogo.DataSource = await Tareas.ActualizarCatalogo_task(cts.Token);
                imgCargar.Visible = false;
                dtagrdCatalogo.Enabled = true;
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Se canceló la carga del catalogo de productos", "ATENCIÓN");
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR al cargar el catálogo de productos", "ERROR");
            }
        }
        /// <summary>
        /// Ordena los productos dependiendo del criterio seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if(dtagrdCatalogo.Enabled && cmbOrdenar.SelectedIndex > -1)
                {
                    EDatosProducto dato = (EDatosProducto)cmbOrdenar.SelectedItem;
                    dtagrdCatalogo.DataSource = null;
                    dtagrdCatalogo.DataSource = BD_Productos.OrdenarCatalogoProductos(dato);
                }
            }
            catch(ErrorBaseDatosException x)
            {
                MessageBox.Show(x.Message, "ERROR");
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
        private void ActualizarCatalogo()
        {
            this.dtagrdCatalogo.DataSource = null;
            this.dtagrdCatalogo.DataSource = BD_Productos.ObtenerCatalogoProductos();
        }

        private void FrmGestionarCatalogo_FormClosing(object sender, FormClosingEventArgs e)
        {
            cts.Cancel();
        }
    }
}
