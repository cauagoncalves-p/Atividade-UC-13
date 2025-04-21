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
    public partial class Pedido: Form
    {
        private void atualizarBanco()
        {
            lboDadosPedidos.Items.Clear();
            PedidoTableAdapter pedidos = new PedidoTableAdapter();
            var dados = from linha in pedidos.GetData() select linha;

            foreach (var item in dados)
            {
                lboDadosPedidos.Items.Add(item);
            }
        }

        private void limparcampos()
        {
            txtID.Clear();
            txtStatus.Clear();
            txtDataPedido.Clear();
            txtIDCliente.Clear();
        }
        public Pedido()
        {
            InitializeComponent();
            atualizarBanco();
        }

        private void lboDadosPedidos_SelectedValueChanged(object sender, EventArgs e)
        {
   
            if (lboDadosPedidos.SelectedItem == null) return;
            PedidoRow pedido = lboDadosPedidos.SelectedItem as PedidoRow;
            txtID.Text = pedido.Id_cliente.ToString();
            txtIDCliente.Text = pedido.Id_cliente.ToString();
            txtDataPedido.Text = pedido.Data_pedido.ToString();
            txtStatus.Text = pedido.status_pedido;
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text) && string.IsNullOrEmpty(txtIDCliente.Text)
                && string.IsNullOrEmpty(txtStatus.Text) && string.IsNullOrEmpty(txtDataPedido.Text))
            {
                MessageBox.Show("Preencha todos os campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PedidoTableAdapter pedidos = new PedidoTableAdapter();
            int id_cliente = int.Parse(txtIDCliente.Text);
            string status = txtStatus.Text;
            DateTime data_pedido = Convert.ToDateTime(txtDataPedido.Text);
            pedidos.Insert(id_cliente, data_pedido, status);
            limparcampos();
            atualizarBanco();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {

            if (lboDadosPedidos.SelectedItem == null)
            {
                MessageBox.Show("Selecione qual campo sera excluido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PedidoRow excluirPedido = lboDadosPedidos.SelectedItem as PedidoRow;
            PedidoTableAdapter pedido = new PedidoTableAdapter();

            try
            {
                pedido.Delete(excluirPedido.Id_pedido, excluirPedido.Id_cliente,excluirPedido.Data_pedido);
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
            if (lboDadosPedidos.SelectedItem == null)
            {
                MessageBox.Show("Selecione qual elemento você quer atualizar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            PedidoRow dadosAtualizar = lboDadosPedidos.SelectedItem as PedidoRow;
            PedidoTableAdapter atualizar = new PedidoTableAdapter();
            int id_cliente = int.Parse(txtIDCliente.Text);
            DateTime data_pedido = Convert.ToDateTime(txtDataPedido.Text);
            // Atualizando os dados 
            dadosAtualizar.Data_pedido = data_pedido;
            dadosAtualizar.Id_cliente = id_cliente;
            atualizar.Update(dadosAtualizar);

            atualizarBanco();
            limparcampos();

            MessageBox.Show("Atualizado com sucesso", "PRONTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "" && txtIDCliente.Text == "" && txtStatus.Text == "" && txtDataPedido.Text == "")
            {
                MessageBox.Show("Não há campos para serem limpos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            limparcampos();
            atualizarBanco();
        }
    }
}
