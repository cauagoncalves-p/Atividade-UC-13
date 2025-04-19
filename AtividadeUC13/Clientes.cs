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
    public partial class Clientes: Form
    {

        private void atualizarBanco() 
        {
            lboDadosClientes.Items.Clear();
            ClienteTableAdapter cliente = new ClienteTableAdapter();
            var dados = from linha in cliente.GetData() select linha;

            foreach (var item in dados)
            {
                lboDadosClientes.Items.Add(item);
            }
        }

        private void limparcampos() 
        {
            txtID.Clear();
            txtNome.Clear();
            txtSobrenome.Clear();
            txtEndereco.Clear();
            txtCidade.Clear();
            txtEstado.Clear();
            txtUF.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            txtPais.Clear();    
        }

        public Clientes()
        {
            InitializeComponent();
            atualizarBanco();   
        }

        private void lboDadosClientes_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lboDadosClientes.SelectedItem == null) return;
            ClienteRow clientes = lboDadosClientes.SelectedItem as ClienteRow;
            txtID.Text = clientes.Id_cliente.ToString();
            txtNome.Text = clientes.Nome;
            txtSobrenome.Text = clientes.Sobrenome;
            txtPais.Text = clientes.Pais;
            txtUF.Text = clientes.UF;
            txtTelefone.Text = clientes.Telefone;
            txtEstado.Text = clientes.Estado;
            txtEmail.Text = clientes.Email;
            txtCidade.Text = clientes.Cidade;
            txtEndereco.Text = clientes.Endereco;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtID.Text) && string.IsNullOrEmpty(txtNome.Text)
                && string.IsNullOrEmpty(txtSobrenome.Text) && string.IsNullOrEmpty(txtEndereco.Text) && string.IsNullOrEmpty(txtCidade.Text) && string.IsNullOrEmpty(txtEstado.Text) && string.IsNullOrEmpty(txtUF.Text) && string.IsNullOrEmpty(txtEmail.Text)
                && string.IsNullOrEmpty(txtTelefone.Text) && string.IsNullOrEmpty(txtPais.Text))
            {
                MessageBox.Show("Preencha todos os campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ClienteTableAdapter adicionarcliente = new ClienteTableAdapter();   

            string nome = txtNome.Text;
            string sobrenome = txtSobrenome.Text;
            string endereco = txtEndereco.Text;
            string cidade = txtCidade.Text;
            string estado = txtEstado.Text;
            string uf = txtUF.Text;
            string email = txtEmail.Text;
            string telefone = txtTelefone.Text; 
            string pais = txtPais.Text;

            adicionarcliente.Insert(nome, sobrenome, endereco, cidade, estado, uf, email, telefone, pais);
            atualizarBanco();
            limparcampos();

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (lboDadosClientes.SelectedItem == null)
            {
                MessageBox.Show("Selecione qual campo sera excluido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ClienteRow excluirCliente = lboDadosClientes.SelectedItem as ClienteRow;
            ClienteTableAdapter cliente = new ClienteTableAdapter();

            try 
            {
                cliente.Delete(excluirCliente.Id_cliente, excluirCliente.Nome, excluirCliente.Sobrenome, excluirCliente.Email
                , excluirCliente.Telefone, excluirCliente.Endereco, excluirCliente.Cidade, excluirCliente.Estado, excluirCliente.UF, excluirCliente.Pais);
                atualizarBanco();
                limparcampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Campo selecionado faz relação com outra tabela", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {

            if (txtNome.Text == "" && txtSobrenome.Text == "" && txtEmail.Text == "" && txtCidade.Text == "" &&
               txtEndereco.Text == "" && txtPais.Text == "" && txtUF.Text == "" && txtTelefone.Text == "" && txtEstado.Text == "")
            {
                MessageBox.Show("Não há campos para serem limpos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            limparcampos();
            atualizarBanco(); 
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (lboDadosClientes.SelectedItem == null)
            {
                MessageBox.Show("Selecione qual elemento você quer atualizar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            ClienteRow dadosAtualizar = lboDadosClientes.SelectedItem as ClienteRow;
            ClienteTableAdapter atualizar = new ClienteTableAdapter();

            string nome = txtNome.Text;
            string endereco = txtEndereco.Text;
            string email = txtEmail.Text;
            string cidade = txtCidade.Text;
            string estado = txtEstado.Text;
            string uf = txtUF.Text;
            string telefone = txtTelefone.Text;
            string pais = txtPais.Text;
            string sobrenome = txtSobrenome.Text;
            // Atualizando os dados 
            dadosAtualizar.Nome = nome;
            dadosAtualizar.Endereco = endereco;
            dadosAtualizar.Estado = estado;
            dadosAtualizar.Cidade = cidade;
            dadosAtualizar.UF = uf;
            dadosAtualizar.Pais = pais;
            dadosAtualizar.Telefone = telefone;
            dadosAtualizar.Sobrenome = sobrenome;
            dadosAtualizar.Email = email;
            atualizar.Update(dadosAtualizar);

            atualizarBanco();
            limparcampos();

            MessageBox.Show("Atualizado com sucesso", "PRONTO", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
