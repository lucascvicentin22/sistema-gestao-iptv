namespace VPlay
{
    partial class frmcadastro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmcadastro));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDataVencimento = new System.Windows.Forms.MaskedTextBox();
            this.cbAPP = new System.Windows.Forms.ComboBox();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.txtWhatsapp = new System.Windows.Forms.TextBox();
            this.txtIDCadastro = new System.Windows.Forms.TextBox();
            this.dataGridViewClientesCadastrados = new System.Windows.Forms.DataGridView();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cbPrefixo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientesCadastrados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(168, 307);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(153, 49);
            this.btnSalvar.TabIndex = 9;
            this.btnSalvar.Text = "SALVAR";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "NOME";
            // 
            // txtNome
            // 
            this.txtNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNome.Location = new System.Drawing.Point(127, 46);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(250, 20);
            this.txtNome.TabIndex = 1;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(127, 72);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(250, 20);
            this.txtUsuario.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "USUARIO";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(127, 98);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(250, 20);
            this.txtSenha.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "SENHA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(392, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "APPLICATIVO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(400, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "WHATSAPP";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(390, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "VENCIMENTO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(70, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "STATUS";
            // 
            // txtDataVencimento
            // 
            this.txtDataVencimento.Location = new System.Drawing.Point(474, 125);
            this.txtDataVencimento.Mask = "00/00/0000";
            this.txtDataVencimento.Name = "txtDataVencimento";
            this.txtDataVencimento.Size = new System.Drawing.Size(249, 20);
            this.txtDataVencimento.TabIndex = 6;
            this.txtDataVencimento.ValidatingType = typeof(System.DateTime);
            // 
            // cbAPP
            // 
            this.cbAPP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAPP.FormattingEnabled = true;
            this.cbAPP.Location = new System.Drawing.Point(475, 49);
            this.cbAPP.Name = "cbAPP";
            this.cbAPP.Size = new System.Drawing.Size(249, 21);
            this.cbAPP.TabIndex = 4;
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "PAGO"});
            this.cbStatus.Location = new System.Drawing.Point(127, 124);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(249, 21);
            this.cbStatus.TabIndex = 7;
            // 
            // txtWhatsapp
            // 
            this.txtWhatsapp.Location = new System.Drawing.Point(473, 102);
            this.txtWhatsapp.Name = "txtWhatsapp";
            this.txtWhatsapp.Size = new System.Drawing.Size(250, 20);
            this.txtWhatsapp.TabIndex = 5;
            // 
            // txtIDCadastro
            // 
            this.txtIDCadastro.Location = new System.Drawing.Point(127, 20);
            this.txtIDCadastro.Name = "txtIDCadastro";
            this.txtIDCadastro.Size = new System.Drawing.Size(52, 20);
            this.txtIDCadastro.TabIndex = 0;
            this.txtIDCadastro.Visible = false;
            // 
            // dataGridViewClientesCadastrados
            // 
            this.dataGridViewClientesCadastrados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClientesCadastrados.Location = new System.Drawing.Point(12, 151);
            this.dataGridViewClientesCadastrados.Name = "dataGridViewClientesCadastrados";
            this.dataGridViewClientesCadastrados.Size = new System.Drawing.Size(712, 150);
            this.dataGridViewClientesCadastrados.TabIndex = 8;
            this.dataGridViewClientesCadastrados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClientesCadastrados_CellClick);
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(327, 307);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(153, 49);
            this.btnDeletar.TabIndex = 14;
            this.btnDeletar.Text = "DELETAR";
            this.btnDeletar.UseVisualStyleBackColor = true;
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(415, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "PREFIXO";
            // 
            // cbPrefixo
            // 
            this.cbPrefixo.FormattingEnabled = true;
            this.cbPrefixo.Location = new System.Drawing.Point(475, 77);
            this.cbPrefixo.Name = "cbPrefixo";
            this.cbPrefixo.Size = new System.Drawing.Size(248, 21);
            this.cbPrefixo.TabIndex = 16;
            this.cbPrefixo.SelectedIndexChanged += new System.EventHandler(this.cbPrefixo_SelectedIndexChanged);
            // 
            // frmcadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 362);
            this.Controls.Add(this.cbPrefixo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.dataGridViewClientesCadastrados);
            this.Controls.Add(this.txtIDCadastro);
            this.Controls.Add(this.txtWhatsapp);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.cbAPP);
            this.Controls.Add(this.txtDataVencimento);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalvar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmcadastro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CADASTRO DE CLIENTES";
            this.Load += new System.EventHandler(this.frmcadastro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientesCadastrados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox txtDataVencimento;
        private System.Windows.Forms.ComboBox cbAPP;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.TextBox txtWhatsapp;
        private System.Windows.Forms.TextBox txtIDCadastro;
        private System.Windows.Forms.DataGridView dataGridViewClientesCadastrados;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbPrefixo;
    }
}