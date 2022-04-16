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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Llama a Operar y le pasa los valores obtenidos de los txtBox y cmbBox. El resultado de Operar
        /// lo muestra en lblResultado y tambien agrega la operacion a lstOperaciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {

            string txtNumero1 = this.txtNumero1.Text.Replace('.',',');
            string txtNumero2 = this.txtNumero2.Text.Replace('.', ',');

            double resultado = Operar(txtNumero1, txtNumero2, this.cmbOperador.Text);

            if (string.IsNullOrEmpty(this.cmbOperador.Text))
            {
                this.cmbOperador.Text = "+";                
            }

            if(!double.TryParse(txtNumero1, out double txtNumero1Parseado))
            {
                this.txtNumero1.Text = "0";
            }
            if (!double.TryParse(txtNumero2, out double txtNumero2Parseado))
            {
                this.txtNumero2.Text = "0";
            }

            this.lblResultado.Text = $"{resultado:0.###}";
            this.lstOperaciones.Items.Add($"{txtNumero1Parseado} {this.cmbOperador.Text} {txtNumero2Parseado} = {resultado:0.###}");
            
        }

        /// <summary>
        /// Llama al metodo Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }       

        /// <summary>
        /// Llama al metodo Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Convierte el valor obtenido de lblResultado a Binario. En caso de no poder,
        /// muestra "¡Valor Invalido!"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {                     
            this.lblResultado.Text = Operando.DecimalBinario(this.lblResultado.Text);
        }

        /// <summary>
        /// Convierte el valor obtenido de lblResultado a Decimal. En caso de no poder,
        /// muestra "¡Valor Invalido!"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Operando.BinarioDemcimal(this.lblResultado.Text);           
        }

        /// <summary>
        /// Al detectar que el programa esta cerrandose, muestra un mensaje pidiendo que confirme si desea salir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que queres salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Llama al metodo Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //METODOS NORMALES *************************************************************

        /// <summary>
        /// Limpia todo menos el historial de resultados
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = string.Empty;
            this.txtNumero2.Text = string.Empty;
            this.lblResultado.Text = string.Empty;
            this.cmbOperador.SelectedIndex = -1;
        }

        /// <summary>
        /// Crea dos objetos de tipo Operando y llama al metodo Operar de Calculadora
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando operandoUno = new Operando(numero1);
            Operando operandoDos = new Operando(numero2);

            if (!char.TryParse(operador, out char operadorChar))
            {
                operadorChar = ' ';
            }

            return Calculadora.Operar(operandoUno, operandoDos, operadorChar);          
        }
    }
}
