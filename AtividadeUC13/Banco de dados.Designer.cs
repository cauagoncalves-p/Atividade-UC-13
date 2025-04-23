namespace AtividadeUC13
{
    partial class Banco_de_dados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnItensPedido = new System.Windows.Forms.Button();
            this.btnPedido = new System.Windows.Forms.Button();
            this.btnProduto = new System.Windows.Forms.Button();
            this.btnFornecedor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClientes
            // 
            this.btnClientes.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.Location = new System.Drawing.Point(12, 37);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(122, 50);
            this.btnClientes.TabIndex = 0;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnItensPedido
            // 
            this.btnItensPedido.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnItensPedido.Location = new System.Drawing.Point(654, 37);
            this.btnItensPedido.Name = "btnItensPedido";
            this.btnItensPedido.Size = new System.Drawing.Size(122, 50);
            this.btnItensPedido.TabIndex = 1;
            this.btnItensPedido.Text = "ItensPedido";
            this.btnItensPedido.UseVisualStyleBackColor = true;
            this.btnItensPedido.Click += new System.EventHandler(this.btnItensPedido_Click);
            // 
            // btnPedido
            // 
            this.btnPedido.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPedido.Location = new System.Drawing.Point(495, 37);
            this.btnPedido.Name = "btnPedido";
            this.btnPedido.Size = new System.Drawing.Size(122, 50);
            this.btnPedido.TabIndex = 2;
            this.btnPedido.Text = "Pedido";
            this.btnPedido.UseVisualStyleBackColor = true;
            this.btnPedido.Click += new System.EventHandler(this.btnPedido_Click);
            // 
            // btnProduto
            // 
            this.btnProduto.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduto.Location = new System.Drawing.Point(339, 37);
            this.btnProduto.Name = "btnProduto";
            this.btnProduto.Size = new System.Drawing.Size(122, 50);
            this.btnProduto.TabIndex = 3;
            this.btnProduto.Text = "Produto";
            this.btnProduto.UseVisualStyleBackColor = true;
            this.btnProduto.Click += new System.EventHandler(this.btnProduto_Click);
            // 
            // btnFornecedor
            // 
            this.btnFornecedor.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFornecedor.Location = new System.Drawing.Point(177, 37);
            this.btnFornecedor.Name = "btnFornecedor";
            this.btnFornecedor.Size = new System.Drawing.Size(122, 50);
            this.btnFornecedor.TabIndex = 4;
            this.btnFornecedor.Text = "Fornecedor";
            this.btnFornecedor.UseVisualStyleBackColor = true;
            this.btnFornecedor.Click += new System.EventHandler(this.btnFornecedor_Click);
            // 
            // Banco_de_dados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFornecedor);
            this.Controls.Add(this.btnProduto);
            this.Controls.Add(this.btnPedido);
            this.Controls.Add(this.btnItensPedido);
            this.Controls.Add(this.btnClientes);
            this.Name = "Banco_de_dados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Banco de dados";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnItensPedido;
        private System.Windows.Forms.Button btnPedido;
        private System.Windows.Forms.Button btnProduto;
        private System.Windows.Forms.Button btnFornecedor;
    }
}