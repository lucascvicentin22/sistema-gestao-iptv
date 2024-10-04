using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace VPlay
{
    public partial class frmMaster : Form
    {
        private string connectionString = "Server=localhost;Database=db_vplay;User ID=root;Password=2707;";
        public DateTime NovaDataVencimento { get; private set; }
        private ComboBox cbPrefixo; // Verifique se está declarado aqui
        private frmcadastro cadastroForm;
        public frmMaster()
        {
            InitializeComponent();
            FiltrarClientes();
            contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(contextMenuStrip1_Opening);
            dataGridViewClientes.MouseDown += new MouseEventHandler(dataGridViewClientes_MouseDown);
            CarregarDadosClientes();
            ObterTotalClientes();
            ObterTotalClientesAtivos();
            ObterClientesVencer();
            ObterClientesVencidos();

        }
        public void AtualizarStatusClientes()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE tb_clientes SET status_pagamento = CASE " +
                                   "WHEN data_vencimento < CURDATE() THEN 'VENCIDO' " +
                                   "WHEN data_vencimento = CURDATE() THEN 'PENDENTE' " +
                                   "WHEN DATEDIFF(data_vencimento, CURDATE()) <= 7 AND DATEDIFF(data_vencimento, CURDATE()) > 0 THEN 'À VENCER' " +
                                   "ELSE 'PAGO' END;";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }

                // Após atualizar o status, recarregue os dados do DataGridView
                CarregarDadosClientes(); // Método para carregar os dados no DataGridView
                ObterTotalClientes();
                ObterTotalClientesAtivos();
                ObterClientesVencer();
                ObterClientesVencidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar status dos clientes: {ex.Message}");
            }
        }
        private void frmMaster_Load(object sender, EventArgs e)
        {
            // Atualiza o status dos clientes
            AtualizarStatusClientes();

            // Carregar dados do banco de dados
            CarregarDadosClientes();

            // Atualiza as labels com as informações corretas
            lblDataAtual.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblTotalClientes.Text = ObterTotalClientes().ToString();
            lblClientesAtivos.Text = ObterTotalClientesAtivos().ToString();
            lblClientesVencer.Text = ObterClientesVencer().ToString();
            lblClientesVencidos.Text = ObterClientesVencidos().ToString();
        }
        public int ObterTotalClientes()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM tb_clientes";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int ObterTotalClientesAtivos()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM tb_clientes WHERE status_pagamento = 'PAGO'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        public int ObterClientesVencer()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                // Contar clientes que estão a vencer nos próximos 7 dias
                string query = "SELECT COUNT(*) FROM tb_clientes WHERE DATEDIFF(data_vencimento, CURDATE()) BETWEEN 1 AND 7";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int ObterClientesVencidos()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM tb_clientes WHERE data_vencimento < CURDATE()";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        private void CarregarClientes()
        {
            // Supondo que você tenha uma consulta para obter os dados do cliente
            string query = "SELECT id_cliente, nome, senha FROM tb_clientes"; // Exemplo de consulta

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                dataGridViewClientes.Rows.Clear();

                while (reader.Read())
                {
                    int rowIndex = dataGridViewClientes.Rows.Add();
                    DataGridViewRow row = dataGridViewClientes.Rows[rowIndex];
                    row.Cells["id_cliente"].Value = reader["id_cliente"];
                    row.Cells["nome"].Value = reader["nome"];
                    row.Cells["senha"].Value = new string('*', reader["senha"].ToString().Length); // Exibir asteriscos
                    row.Cells["senhaOriginal"].Value = reader["senha"].ToString(); // Armazenar senha original
                }
            }
        }

        public void CarregarDadosClientes()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT *, senha AS senhaOriginal FROM tb_clientes"; // Inclui a senha original
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridViewClientes.DataSource = dataTable;

                    // Renomear colunas
                    dataGridViewClientes.Columns["id_cliente"].HeaderText = "ID";
                    dataGridViewClientes.Columns["nome"].HeaderText = "NOME DO CLIENTE";
                    dataGridViewClientes.Columns["usuario"].HeaderText = "USUÁRIO";
                    dataGridViewClientes.Columns["senha"].HeaderText = "SENHA";
                    dataGridViewClientes.Columns["applicativo"].HeaderText = "APPLICATIVO";
                    dataGridViewClientes.Columns["whatsapp"].HeaderText = "WHATSAPP";
                    dataGridViewClientes.Columns["data_vencimento"].HeaderText = "DATA DE VENCIMENTO";
                    dataGridViewClientes.Columns["status_pagamento"].HeaderText = "STATUS";

                    // Adiciona a coluna oculta para a senha original
                    dataGridViewClientes.Columns["senhaOriginal"].Visible = false; // Coluna oculta

                    // Ajustar tamanhos de coluna
                    dataGridViewClientes.Columns["id_cliente"].Width = 40;
                    dataGridViewClientes.Columns["nome"].Width = 200;
                    dataGridViewClientes.Columns["usuario"].Width = 150;
                    dataGridViewClientes.Columns["senha"].Width = 115;
                    dataGridViewClientes.Columns["applicativo"].Width = 100;
                    dataGridViewClientes.Columns["whatsapp"].Width = 100;
                    dataGridViewClientes.Columns["data_vencimento"].Width = 120; // Adicionei a largura para a coluna de data
                    dataGridViewClientes.Columns["status_pagamento"].Width = 100; // Adicionei a largura para a coluna de status
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados dos clientes: " + ex.Message);
            }
        }

        private void cADASTROCLIENTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcadastro frmcadastro = new frmcadastro(this); // Passa a referência do frmMaster
            frmcadastro.ShowDialog();
        }
        
        private void txtPESQUIZA_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPESQUIZA.Text))
            {
                FiltrarClientes();
            }
            else
            {
                CarregarDadosClientes(); // Carrega todos os clientes se a pesquisa estiver vazia
            }
        }

        private void FiltrarClientes()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT `id_cliente`, `nome`, `usuario`, `senha`, `applicativo`, `whatsapp`, `data_vencimento`, `status_pagamento`
                                     FROM `tb_clientes`
                                     WHERE `nome` LIKE @search OR `usuario` LIKE @search;";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@search", "%" + txtPESQUIZA.Text + "%");

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridViewClientes.DataSource = dataTable;

                    // Atualiza a label com o total de clientes filtrados
                    lblTotalClientes.Text = dataTable.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao buscar dados: " + ex.Message);
            }
        }

        private void dataGridViewClientes_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dataGridViewClientes.HitTest(e.X, e.Y);
                if (hit.RowIndex != -1) // Verifica se clicou em uma linha
                {
                    dataGridViewClientes.ClearSelection(); // Limpa a seleção atual
                    dataGridViewClientes.Rows[hit.RowIndex].Selected = true; // Seleciona a linha clicada
                    contextMenuStrip1.Show(dataGridViewClientes, e.Location); // Mostra o menu de contexto
                }
            }
        }
        
        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Verifica se há uma linha selecionada no DataGridView
            e.Cancel = dataGridViewClientes.SelectedRows.Count == 0;
        }
        
        private void dataGridViewClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifica se a coluna é "senha" e se há um valor
            if (dataGridViewClientes.Columns[e.ColumnIndex].Name == "senha" && e.Value != null)
            {
                // Obtém o id_cliente da linha
                string idCliente = dataGridViewClientes.Rows[e.RowIndex].Cells["id_cliente"].Value.ToString();

                // Exibe a senha como asteriscos ou deixa visível, dependendo do estado
                if (senhaVisivelPorId.TryGetValue(idCliente, out bool isVisible) && isVisible)
                {
                    e.Value = e.Value.ToString(); // Exibe a senha
                }
                else
                {
                    e.Value = new string('*', e.Value.ToString().Length); // Exibe asteriscos
                }

                e.FormattingApplied = true; // Indica que a formatação foi aplicada
            }
        }
        private Dictionary<string, bool> senhaVisivelPorId = new Dictionary<string, bool>(); // Dicionário para armazenar visibilidade da senha
        private void dataGridViewClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica se a célula clicada está na coluna "senha"
            if (e.ColumnIndex == dataGridViewClientes.Columns["senha"].Index && e.RowIndex >= 0)
            {
                // Obtém o id_cliente da linha clicada
                string idCliente = dataGridViewClientes.Rows[e.RowIndex].Cells["id_cliente"].Value.ToString();

                // Alterna a visibilidade da senha para o cliente correspondente
                if (senhaVisivelPorId.ContainsKey(idCliente))
                {
                    senhaVisivelPorId[idCliente] = !senhaVisivelPorId[idCliente]; // Alterna o estado
                }
                else
                {
                    senhaVisivelPorId[idCliente] = true; // Define como visível se ainda não estiver no dicionário
                }

                // Atualiza a visualização do DataGridView
                dataGridViewClientes.Refresh();
            }
            // Verifica se a célula clicada está na coluna "whatsapp"
            else if (e.ColumnIndex == dataGridViewClientes.Columns["whatsapp"].Index && e.RowIndex >= 0)
            {
                // Obtém o número do WhatsApp da célula clicada
                string numeroWhatsApp = dataGridViewClientes.Rows[e.RowIndex].Cells["whatsapp"].Value.ToString();

                // Cria a URL do WhatsApp
                string urlWhatsApp = $"https://wa.me/{numeroWhatsApp}"; // Formato da URL para enviar mensagem via WhatsApp

                // Abre a URL no navegador padrão
                System.Diagnostics.Process.Start(urlWhatsApp);
            }
        }


        private void rENOVAÇÃOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewClientes.SelectedRows.Count > 0)
            {
                // Obter o idCliente da linha selecionada
                string idCliente = dataGridViewClientes.SelectedRows[0].Cells["id_cliente"].Value.ToString();

                // Obter a data de vencimento atual da linha selecionada
                DateTime dataVencimentoAtual = Convert.ToDateTime(dataGridViewClientes.SelectedRows[0].Cells["data_vencimento"].Value);

                // Abrir o formulário de renovação, passando o idCliente, a data de vencimento atual e a referência do frmMaster
                frmRenovacao frmRenovacao = new frmRenovacao(idCliente, dataVencimentoAtual, this);
                frmRenovacao.ShowDialog();

                // Atualiza o DataGridView apenas se o formulário de renovação foi fechado
                // e o método AtualizarStatusClientes será chamado dentro do frmRenovacao após a confirmação.
            }
            else
            {
                MessageBox.Show("Por favor, selecione um cliente.");
            }
        }

        private void cADASTRARAPPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApp app = new frmApp();
            app.ShowDialog();
        }
    }
}
