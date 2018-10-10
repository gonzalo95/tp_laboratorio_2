using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalculadora
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Constructor por defecto del formulario.
        /// </summary>
        public Form1()
        {
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
            this.btnConvertirABinario.Enabled = false;
            this.btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// Realiza la operacion seleccionada entre los 2 operandos ingresados. Si la operacion es invalida se la considerara suma.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOperar_Click(object sender, EventArgs e)
        {
            if(txtNumero1.Text != "" && txtNumero2.Text != "")
            {
                lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
                this.btnConvertirABinario.Enabled = true;
            }
                
        }

        /// <summary>
        /// Cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Borra los datos ingresados y el resultado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            this.btnConvertirABinario.Enabled = false;
            this.btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// Borra los campos 'Text' de los operandos, el operado y el resultado.
        /// </summary>
        private void Limpiar()
        {
            lblResultado.Text = "";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
        }

        /// <summary>
        /// Instancia 2 objetos de la clase Numero con los operadores ingresados y realiza la operacion ingresada.
        /// </summary>
        /// <param name="numero1">String que representa el numero del primer operando.</param>
        /// <param name="numero2">String que representa el numero del segundo operando.</param>
        /// <param name="operador">Operacion a realizar. De ser invalida o nula se la considerara suma.</param>
        /// <returns>El resultado de la operacion.</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Entidades.Numero num1 = new Entidades.Numero(numero1);
            Entidades.Numero num2 = new Entidades.Numero(numero2);

            return Entidades.Calculadora.Operar(num1, num2, operador);
        }

        /// <summary>
        /// Convierte el resultado a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if(lblResultado.Text != "")
            {
                lblResultado.Text = Entidades.Numero.DecimalBinario(lblResultado.Text);
                this.btnConvertirABinario.Enabled = false;
                this.btnConvertirADecimal.Enabled = true;
            }
                
        }

        /// <summary>
        /// Convierte el resultado a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "")
            {
                lblResultado.Text = Entidades.Numero.BinarioDecimal(lblResultado.Text);
                this.btnConvertirADecimal.Enabled = false;
                this.btnConvertirABinario.Enabled = true;
            }
                
        }
    }
}
