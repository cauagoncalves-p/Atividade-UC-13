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

namespace AtividadeUC13
{
    public partial class Clientes: Form
    {

        private void atualizarBanco() 
        {
            ClienteTableAdapter cliente = new ClienteTableAdapter();
            var dados = from linha in cliente.GetData() select linha;

            foreach (var item in dados)
            {
                lboDadosClientes.Items.Add(item);
            }

        }
        public Clientes()
        {
            InitializeComponent();
            atualizarBanco();   
        }
    }
}
