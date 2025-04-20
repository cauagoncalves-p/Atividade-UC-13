using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AtividadeUC13.DubraSkateShopDataSetTableAdapters;
using static AtividadeUC13.DubraSkateShopDataSet;

namespace AtividadeUC13
{
    public partial class Fornecedor: Form
    {
        private void atualizarBanco()
        {
            lboDadosFornecedor.Items.Clear();
            FornecedorTableAdapter fornecedor = new FornecedorTableAdapter();
            var dados = from linha in fornecedor.GetData() select linha;

            foreach (var item in dados)
            {
                lboDadosFornecedor.Items.Add(item);
            }
        }

        private void limparcampos()
        {
            txtID.Clear();
            txtNome.Clear();
            txtcnpj.Clear();
            txtEndereco.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
            txtUF.Clear();
            txtEmail.Clear();
            txtPais.Clear();
        }
        public Fornecedor()
        {
            InitializeComponent();
            atualizarBanco();   
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text) && string.IsNullOrEmpty(txtNome.Text)
                && string.IsNullOrEmpty(txtcnpj.Text) && string.IsNullOrEmpty(txtEndereco.Text) && string.IsNullOrEmpty(txtCidade.Text) && string.IsNullOrEmpty(txtEstado.Text) && string.IsNullOrEmpty(txtUF.Text) && string.IsNullOrEmpty(txtEmail.Text)
                && string.IsNullOrEmpty(txtPais.Text))
            {
                MessageBox.Show("Preencha todos os campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            FornecedorTableAdapter fornecedores = new FornecedorTableAdapter();    
            string nome = txtNome.Text;
            string cnpj = txtcnpj.Text;
            string endereco = txtEndereco.Text;
            string cidade = txtCidade.Text;
            string estado = txtEstado.Text;
            string uf = txtUF.Text;
            string email = txtEmail.Text;
            string pais = txtPais.Text;
            fornecedores.Insert(nome, email,cnpj,endereco,cidade,estado,uf,pais);
            atualizarBanco();
            limparcampos();

        }

        private void lboDadosFornecedor_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lboDadosFornecedor.SelectedItem == null) return;
            FornecedorRow fornecedores = lboDadosFornecedor.SelectedItem as FornecedorRow;
            txtID.Text = fornecedores.Id_fornecedor.ToString();
            txtNome.Text = fornecedores.Nome;
            txtcnpj.Text = fornecedores.CNPJ;
            txtPais.Text = fornecedores.Pais;
            txtUF.Text = fornecedores.UF;
            txtEstado.Text = fornecedores.Estado;
            txtEmail.Text = fornecedores.Email;
            txtCidade.Text = fornecedores.Cidade;
            txtEndereco.Text = fornecedores.Endereco;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "" && txtcnpj.Text == "" && txtEmail.Text == "" && txtCidade.Text == "" &&
                txtEndereco.Text == "" && txtPais.Text == "" && txtUF.Text == "" && txtEstado.Text == "")
            {
                MessageBox.Show("Não há campos para serem limpos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            limparcampos();
            atualizarBanco();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (lboDadosFornecedor.SelectedItem == null)
            {
                MessageBox.Show("Selecione qual campo sera excluido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FornecedorRow excluirFornecedor = lboDadosFornecedor.SelectedItem as FornecedorRow;
            FornecedorTableAdapter fornecedor = new FornecedorTableAdapter();

            try
            {
                fornecedor.DeletarPorID(excluirFornecedor.Id_fornecedor, excluirFornecedor.Email);
                atualizarBanco();
                limparcampos();
            }
            catch (Exception)
            {
                MessageBox.Show("Campo selecionado faz relação com outra tabela", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (lboDadosFornecedor.SelectedItem == null)
            {
                MessageBox.Show("Selecione qual elemento você quer atualizar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            FornecedorRow dadosAtualizar = lboDadosFornecedor.SelectedItem as FornecedorRow;
            FornecedorTableAdapter atualizar = new FornecedorTableAdapter();

            string nome = txtNome.Text;
            string endereco = txtEndereco.Text;
            string email = txtEmail.Text;
            string cidade = txtCidade.Text;
            string estado = txtEstado.Text;
            string uf = txtUF.Text;
            string pais = txtPais.Text;
            string cnpj = txtcnpj.Text;
            // Atualizando os dados 
            dadosAtualizar.Nome = nome;
            dadosAtualizar.Endereco = endereco;
            dadosAtualizar.Estado = estado;
            dadosAtualizar.Cidade = cidade;
            dadosAtualizar.UF = uf;
            dadosAtualizar.Pais = pais;
            dadosAtualizar.CNPJ = cnpj;
            dadosAtualizar.Email = email;
            atualizar.Update(dadosAtualizar);

            atualizarBanco();
            limparcampos();

            MessageBox.Show("Atualizado com sucesso", "PRONTO", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
