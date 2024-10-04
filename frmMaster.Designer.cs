namespace VPlay
{
    partial class frmMaster
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaster));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cADASTROCLIENTEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewClientes = new System.Windows.Forms.DataGridView();
            this.txtPESQUIZA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDataAtual = new System.Windows.Forms.Label();
            this.lblTotalClientes = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblClientesVencer = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblClientesAtivos = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblClientesVencidos = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rENOVAÇÃOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cADASTRARAPPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cADASTROCLIENTEToolStripMenuItem,
            this.cADASTRARAPPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(993, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cADASTROCLIENTEToolStripMenuItem
            // 
            this.cADASTROCLIENTEToolStripMenuItem.Name = "cADASTROCLIENTEToolStripMenuItem";
            this.cADASTROCLIENTEToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.cADASTROCLIENTEToolStripMenuItem.Text = "CADASTRO CLIENTE";
            this.cADASTROCLIENTEToolStripMenuItem.Click += new System.EventHandler(this.cADASTROCLIENTEToolStripMenuItem_Click);
            // 
            // dataGridViewClientes
            // 
            this.dataGridViewClientes.AllowUserToAddRows = false;
            this.dataGridViewClientes.AllowUserToDeleteRows = false;
            this.dataGridViewClientes.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dataGridViewClientes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClientes.Location = new System.Drawing.Point(12, 101);
            this.dataGridViewClientes.Name = "dataGridViewClientes";
            this.dataGridViewClientes.ReadOnly = true;
            this.dataGridViewClientes.Size = new System.Drawing.Size(969, 453);
            this.dataGridViewClientes.TabIndex = 1;
            this.dataGridViewClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClientes_CellClick);
            this.dataGridViewClientes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewClientes_CellFormatting);
            this.dataGridViewClientes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewClientes_MouseDown);
            // 
            // txtPESQUIZA
            // 
            this.txtPESQUIZA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPESQUIZA.Location = new System.Drawing.Point(87, 38);
            this.txtPESQUIZA.Name = "txtPESQUIZA";
            this.txtPESQUIZA.Size = new System.Drawing.Size(390, 20);
            this.txtPESQUIZA.TabIndex = 2;
            this.txtPESQUIZA.TextChanged += new System.EventHandler(this.txtPESQUIZA_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "PESQUISA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("News706 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(20, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "DATA:";
            // 
            // lblDataAtual
            // 
            this.lblDataAtual.AutoSize = true;
            this.lblDataAtual.Font = new System.Drawing.Font("News706 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataAtual.ForeColor = System.Drawing.Color.Blue;
            this.lblDataAtual.Location = new System.Drawing.Point(86, 72);
            this.lblDataAtual.Name = "lblDataAtual";
            this.lblDataAtual.Size = new System.Drawing.Size(117, 19);
            this.lblDataAtual.TabIndex = 7;
            this.lblDataAtual.Text = "DATA ATUAL";
            // 
            // lblTotalClientes
            // 
            this.lblTotalClientes.AutoSize = true;
            this.lblTotalClientes.Font = new System.Drawing.Font("News706 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblTotalClientes.Location = new System.Drawing.Point(320, 72);
            this.lblTotalClientes.Name = "lblTotalClientes";
            this.lblTotalClientes.Size = new System.Drawing.Size(67, 19);
            this.lblTotalClientes.TabIndex = 11;
            this.lblTotalClientes.Text = "ATUAL";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("News706 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(209, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 19);
            this.label7.TabIndex = 8;
            this.label7.Text = "CLIENTES:";
            // 
            // lblClientesVencer
            // 
            this.lblClientesVencer.AutoSize = true;
            this.lblClientesVencer.Font = new System.Drawing.Font("News706 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientesVencer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblClientesVencer.Location = new System.Drawing.Point(659, 72);
            this.lblClientesVencer.Name = "lblClientesVencer";
            this.lblClientesVencer.Size = new System.Drawing.Size(67, 19);
            this.lblClientesVencer.TabIndex = 13;
            this.lblClientesVencer.Text = "ATUAL";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("News706 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label9.Location = new System.Drawing.Point(549, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 19);
            this.label9.TabIndex = 12;
            this.label9.Text = "À VENCER:";
            // 
            // lblClientesAtivos
            // 
            this.lblClientesAtivos.AutoSize = true;
            this.lblClientesAtivos.Font = new System.Drawing.Font("News706 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientesAtivos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblClientesAtivos.Location = new System.Drawing.Point(476, 72);
            this.lblClientesAtivos.Name = "lblClientesAtivos";
            this.lblClientesAtivos.Size = new System.Drawing.Size(67, 19);
            this.lblClientesAtivos.TabIndex = 15;
            this.lblClientesAtivos.Text = "ATUAL";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("News706 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(393, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 19);
            this.label11.TabIndex = 14;
            this.label11.Text = "ATIVOS:";
            // 
            // lblClientesVencidos
            // 
            this.lblClientesVencidos.AutoSize = true;
            this.lblClientesVencidos.Font = new System.Drawing.Font("News706 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClientesVencidos.ForeColor = System.Drawing.Color.Maroon;
            this.lblClientesVencidos.Location = new System.Drawing.Point(844, 72);
            this.lblClientesVencidos.Name = "lblClientesVencidos";
            this.lblClientesVencidos.Size = new System.Drawing.Size(67, 19);
            this.lblClientesVencidos.TabIndex = 17;
            this.lblClientesVencidos.Text = "ATUAL";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("News706 BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Maroon;
            this.label13.Location = new System.Drawing.Point(732, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 19);
            this.label13.TabIndex = 16;
            this.label13.Text = "VENCIDOS:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rENOVAÇÃOToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 26);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // rENOVAÇÃOToolStripMenuItem
            // 
            this.rENOVAÇÃOToolStripMenuItem.Name = "rENOVAÇÃOToolStripMenuItem";
            this.rENOVAÇÃOToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.rENOVAÇÃOToolStripMenuItem.Text = "RENOVAR PACOTE";
            this.rENOVAÇÃOToolStripMenuItem.Click += new System.EventHandler(this.rENOVAÇÃOToolStripMenuItem_Click);
            // 
            // cADASTRARAPPToolStripMenuItem
            // 
            this.cADASTRARAPPToolStripMenuItem.Name = "cADASTRARAPPToolStripMenuItem";
            this.cADASTRARAPPToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.cADASTRARAPPToolStripMenuItem.Text = "CADASTRAR APP";
            this.cADASTRARAPPToolStripMenuItem.Click += new System.EventHandler(this.cADASTRARAPPToolStripMenuItem_Click);
            // 
            // frmMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 566);
            this.Controls.Add(this.lblClientesVencidos);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblClientesAtivos);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblClientesVencer);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblTotalClientes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblDataAtual);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPESQUIZA);
            this.Controls.Add(this.dataGridViewClientes);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SISTEMA PARA CONTROLE DE PACOTES DE TV. VPLAY";
            this.Load += new System.EventHandler(this.frmMaster_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientes)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cADASTROCLIENTEToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewClientes;
        private System.Windows.Forms.TextBox txtPESQUIZA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblDataAtual;
        public System.Windows.Forms.Label lblTotalClientes;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label lblClientesVencer;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label lblClientesAtivos;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label lblClientesVencidos;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rENOVAÇÃOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cADASTRARAPPToolStripMenuItem;
    }
}

