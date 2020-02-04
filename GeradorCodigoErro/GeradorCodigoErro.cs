using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorCodigoErro
{
    public partial class GeradorCodigoErro : Form
    {
        public GeradorCodigoErro()
        {
            InitializeComponent();
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            int unidade = Convert.ToInt32(Properties.Settings.Default["Unidades"]);

            int codigo = GerarNumeroCodigo(unidade);

            if (codigo.ToString().Length != (unidade + 1))
            {
                codigo = GerarNumeroCodigo(unidade);
            }

            txtCodigo.Text = $"E{codigo.ToString()}";

            Clipboard.Clear();
            Clipboard.SetText(txtCodigo.Text);
        }

        #region ' GerarNumeroCodigo '
        /// <summary>
        /// Método responsável por gerar o número do código de erro
        /// </summary>
        /// <param name="unidade">Parâmetro que representa a quantidade de repetição dos números</param>
        /// <returns>Um número gerado aleatóriamente, de acordo com o limite informado</returns>
        private int GerarNumeroCodigo(int unidade)
        {
            Random rnd = new Random();

            int valorMinimo = Convert.ToInt32($"1{GerarLimiteUnidade(0, unidade)}");

            int valorMaximo = Convert.ToInt32($"9{GerarLimiteUnidade(9, unidade)}");

            return rnd.Next(valorMinimo, valorMaximo);
        } 
        #endregion

        #region ' GerarLimiteUnidade '
        /// <summary>
        /// Método responsável por retornar um número limite
        /// </summary>
        /// <param name="numero">Parâmetro que representa o número a ser repetido</param>
        /// <param name="repeticao">Parâmetro que representa quantas vezes esse número deve ser repetido</param>
        /// <returns>Um texto com o limite requerido</returns>
        private string GerarLimiteUnidade(int numero, int repeticao)
        {
            string limite = string.Empty;

            for (int i = 0; i < repeticao; i++)
            {
                limite += numero.ToString();
            }

            return limite;
        }    
        #endregion
    }
}
