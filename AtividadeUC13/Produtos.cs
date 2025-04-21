using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AtividadeUC13.DubraSkateShopDataSetTableAdapters;
using static AtividadeUC13.DubraSkateShopDataSet;

namespace AtividadeUC13
{
    public partial class Produtos: Form
    {
        private void atualizarBanco()
        {
            lboDadosProdutos.Items.Clear();
            ProdutosTableAdapter produtos = new ProdutosTableAdapter();
            var dados = from linha in produtos.GetData() select linha;

            foreach (var item in dados)
            {
                lboDadosProdutos.Items.Add(item);
            }

        }

        private void limparcampos()
        {
            txtID.Clear();
            txtNome.Clear();
            txtPreco.Clear();
            txtPrecoUnitario.Clear();
            txtQuantidade.Clear();
            txtTipo.Clear();
            txtIdFornecedor.Clear();
        }

        public Produtos()
        {
            InitializeComponent();
            atualizarBanco();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text) && string.IsNullOrEmpty(txtNome.Text)
                && string.IsNullOrEmpty(txtTipo.Text) && string.IsNullOrEmpty(txtQuantidade.Text) && string.IsNullOrEmpty(txtPrecoUnitario.Text)
                && string.IsNullOrEmpty(txtPreco.Text) && string.IsNullOrEmpty(txtIdFornecedor.Text) )
            {
                MessageBox.Show("Preencha todos os campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ProdutosTableAdapter fornecedores = new ProdutosTableAdapter();
            string nome = txtNome.Text;
            decimal preco = Convert.ToDecimal(txtPreco.Text);
            decimal precoUnitario = Convert.ToDecimal(txtPrecoUnitario.Text);
            int quantidade = Convert.ToInt32(txtQuantidade.Text);
            string tipo = txtTipo.Text;
            int idFornecedor = Convert.ToInt32(txtIdFornecedor.Text);
            fornecedores.Insert(nome, tipo, preco, quantidade, precoUnitario,idFornecedor);
            atualizarBanco();
            limparcampos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            if (lboDadosProdutos.SelectedItem == null)
            {
                MessageBox.Show("Selecione qual campo sera excluido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProdutosRow excluirProduto = lboDadosProdutos.SelectedItem as ProdutosRow;
            ProdutosTableAdapter produtos = new ProdutosTableAdapter();

            try
            {
                produtos.Delete(excluirProduto.Id_produto,excluirProduto.Nome,excluirProduto.Tipo,excluirProduto.Preco,excluirProduto.Quantidade, excluirProduto.PrecoUnitario, excluirProduto.Id_fornecedor);
                atualizarBanco();
                limparcampos();
            }
            catch (Exception)
            {
                MessageBox.Show("Campo selecionado faz relação com outra tabela", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "" && txtPreco.Text == "" && txtPrecoUnitario.Text == "" && txtQuantidade.Text == "" &&
                txtIdFornecedor.Text == "" && txtID.Text == "" && txtTipo.Text == "")
            {
                MessageBox.Show("Não há campos para serem limpos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            limparcampos();
            atualizarBanco();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {


            if (lboDadosProdutos.SelectedItem == null)
            {
                MessageBox.Show("Selecione qual elemento você quer atualizar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            ProdutosRow dadosAtualizar = lboDadosProdutos.SelectedItem as ProdutosRow;
            ProdutosTableAdapter atualizar = new ProdutosTableAdapter();

            string nome = txtNome.Text;
            decimal preco = Convert.ToDecimal(txtPreco.Text);
            decimal precoUnitario = Convert.ToDecimal(txtPrecoUnitario.Text);
            int quantidade = Convert.ToInt32(txtQuantidade.Text);
            string tipo = txtTipo.Text;
            int idFornecedor = Convert.ToInt32(txtIdFornecedor.Text);
            // Atualizando os dados 
            dadosAtualizar.Nome = nome;
            dadosAtualizar.Preco = preco;
            dadosAtualizar.PrecoUnitario = precoUnitario;
            dadosAtualizar.Quantidade = quantidade;
            dadosAtualizar.Tipo = tipo;
            dadosAtualizar.Id_fornecedor = idFornecedor;
            atualizar.Update(dadosAtualizar);

            atualizarBanco();
            limparcampos();

            MessageBox.Show("Atualizado com sucesso", "PRONTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lboDadosProdutos_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lboDadosProdutos.Items == null) return;

            ProdutosRow produtos = lboDadosProdutos.SelectedItem as ProdutosRow;
            txtID.Text = produtos.Id_produto.ToString();
            txtNome.Text = produtos.Nome.ToString();
            txtPreco.Text = produtos.Preco.ToString();
            txtPrecoUnitario.Text = produtos.PrecoUnitario.ToString();
            txtQuantidade.Text = produtos.Quantidade.ToString();
            txtTipo.Text = produtos.Tipo.ToString();
            txtIdFornecedor.Text = produtos.Id_fornecedor.ToString();
        }
    }
}
