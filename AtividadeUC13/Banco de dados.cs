using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtividadeUC13
{
    public partial class Banco_de_dados : Form
    {
        public Banco_de_dados()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            clientes.ShowDialog();    
        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            Fornecedor fonnecedor = new Fornecedor();
            fonnecedor.ShowDialog();
        }

        private void btnProduto_Click(object sender, EventArgs e)
        {
            Produtos produtos = new Produtos(); 
            produtos.ShowDialog();
        }


        private void btnPedido_Click(object sender, EventArgs e)
        {
            Pedido pedido = new Pedido();
            pedido.ShowDialog();
        }

        private void btnItensPedido_Click(object sender, EventArgs e)
        {
            ItensPedido itens = new ItensPedido();
            itens.ShowDialog(); 
        }
    }
}
