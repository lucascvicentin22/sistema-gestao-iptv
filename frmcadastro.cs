using System;
using System.Data;
using System.Diagnostics.Metrics;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace VPlay
{
    public partial class frmcadastro : Form
    {
        private string connectionString = "Server=localhost;Database=db_vplay;User ID=root;Password=2707;";
        private int? idClienteAtual = null;
        private frmMaster masterForm;

        public frmcadastro(frmMaster master)
        {
            InitializeComponent();
            masterForm = master; // Recebe a referência do frmMaster
        }

        private void frmcadastro_Load(object sender, EventArgs e)
        {
            CarregarApps();
            CarregarClientes(); // Carrega os clientes ao abrir o formulário
            CarregarPrefixos();
            masterForm.ObterTotalClientes();
            masterForm.ObterTotalClientesAtivos();
            masterForm.ObterClientesVencer();
            masterForm.ObterClientesVencidos();
        }
        private void CarregarPrefixos()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT prefixo FROM tb_paises";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            cbPrefixo.Items.Clear(); // Limpa itens antigos
                            while (reader.Read())
                            {
                                cbPrefixo.Items.Add(reader["prefixo"].ToString()); // Adiciona o valor do campo prefixo
                            }

                            if (cbPrefixo.Items.Count == 0)
                            {
                                MessageBox.Show("Nenhum prefixo encontrado.");
                            }
                            else
                            {
                                // Seleciona o prefixo do Brasil como padrão (supondo que o prefixo do Brasil seja "+55")
                                string prefixoBrasil = "+55";
                                if (cbPrefixo.Items.Contains(prefixoBrasil))
                                {
                                    cbPrefixo.SelectedItem = prefixoBrasil;
                                }
                                else
                                {
                                    MessageBox.Show("Prefixo do Brasil não encontrado.");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os prefixos: " + ex.Message);
            }
        }


        private void CarregarApps()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT nome FROM tb_app";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            cbAPP.Items.Clear(); // Limpa itens antigos
                            while (reader.Read())
                            {
                                cbAPP.Items.Add(reader["nome"].ToString());
                            }

                            if (cbAPP.Items.Count == 0)
                            {
                                MessageBox.Show("Nenhum aplicativo encontrado na tabela tb_app.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar aplicativos: " + ex.Message);
            }
        }

        private void CarregarClientes()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id_cliente, nome, usuario, senha, applicativo, whatsapp, data_vencimento, status_pagamento FROM tb_clientes";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridViewClientesCadastrados.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os clientes: " + ex.Message);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Obtém o valor selecionado da ComboBox cbPrefixo
                    string prefixo = cbPrefixo.SelectedItem?.ToString() ?? string.Empty;

                    // Verifica se o WhatsApp está preenchido
                    string numeroWhatsApp = txtWhatsapp.Text.Trim();
                    if (string.IsNullOrEmpty(numeroWhatsApp))
                    {
                        MessageBox.Show("Por favor, insira um número de WhatsApp.");
                        return;
                    }

                    // Adiciona o prefixo ao número de WhatsApp
                    string whatsappCompleto = $"{prefixo}{numeroWhatsApp}";

                    if (idClienteAtual.HasValue) // Se estiver editando um cliente existente
                    {
                        string query = @"UPDATE tb_clientes 
                 SET nome = @nome, 
                     prefixo = @prefixo,
                     usuario = @usuario, 
                     senha = @senha, 
                     applicativo = @applicativo, 
                     whatsapp = @whatsapp, 
                     data_vencimento = @data_vencimento, 
                     status_pagamento = @status_pagamento 
                 WHERE id_cliente = @idCliente";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@idCliente", idClienteAtual.Value);
                            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                            cmd.Parameters.AddWithValue("@prefixo", prefixo);
                            cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                            cmd.Parameters.AddWithValue("@senha", txtSenha.Text);
                            cmd.Parameters.AddWithValue("@applicativo", cbAPP.SelectedItem?.ToString() ?? string.Empty);
                            cmd.Parameters.AddWithValue("@whatsapp", whatsappCompleto); // Usa o whatsapp completo

                            string dataVencimentoInput = txtDataVencimento.Text;
                            DateTime dataVencimento;
                            if (DateTime.TryParseExact(dataVencimentoInput, "dd/MM/yyyy",
                                                        System.Globalization.CultureInfo.InvariantCulture,
                                                        System.Globalization.DateTimeStyles.None,
                                                        out dataVencimento))
                            {
                                cmd.Parameters.AddWithValue("@data_vencimento", dataVencimento.ToString("yyyy-MM-dd"));
                            }
                            else
                            {
                                MessageBox.Show("Data de vencimento inválida! O formato correto é dd/MM/yyyy.");
                                return;
                            }

                            cmd.Parameters.AddWithValue("@status_pagamento", "PAGO");

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Dados atualizados com sucesso!");
                            idClienteAtual = null; // Reseta o ID após a atualização
                        }
                    }
                    else // Se for um novo registro
                    {
                        string query = @"INSERT INTO tb_clientes 
                 (nome, prefixo, usuario, senha, applicativo, whatsapp, data_vencimento, status_pagamento)
                 VALUES 
                 (@nome, @prefixo, @usuario, @senha, @applicativo, @whatsapp, @data_vencimento, @status_pagamento)";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            // Verifica o valor do prefixo
                            if (string.IsNullOrEmpty(prefixo))
                            {
                                MessageBox.Show("Prefixo não selecionado. Por favor, selecione um prefixo.");
                                return;
                            }

                            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                            cmd.Parameters.AddWithValue("@prefixo", prefixo);
                            cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                            cmd.Parameters.AddWithValue("@senha", txtSenha.Text);
                            cmd.Parameters.AddWithValue("@applicativo", cbAPP.SelectedItem?.ToString() ?? string.Empty);
                            cmd.Parameters.AddWithValue("@whatsapp", whatsappCompleto); // Usa o whatsapp completo

                            string dataVencimentoInput = txtDataVencimento.Text;
                            DateTime dataVencimento;
                            if (DateTime.TryParseExact(dataVencimentoInput, "dd/MM/yyyy",
                                                        System.Globalization.CultureInfo.InvariantCulture,
                                                        System.Globalization.DateTimeStyles.None,
                                                        out dataVencimento))
                            {
                                cmd.Parameters.AddWithValue("@data_vencimento", dataVencimento.ToString("yyyy-MM-dd"));
                            }
                            else
                            {
                                MessageBox.Show("Data de vencimento inválida! O formato correto é dd/MM/yyyy.");
                                return;
                            }

                            cmd.Parameters.AddWithValue("@status_pagamento", "PAGO");

                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Dados salvos com sucesso!");
                        }
                    }

                    masterForm.AtualizarStatusClientes();
                    masterForm.CarregarDadosClientes(); // Atualiza os dados no frmMaster
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar os dados: " + ex.Message);
            }

        }
       
        private void dataGridViewClientesCadastrados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica se a linha é válida
            {
                DataGridViewRow row = dataGridViewClientesCadastrados.Rows[e.RowIndex];
                idClienteAtual = Convert.ToInt32(row.Cells["id_cliente"].Value);
                txtNome.Text = row.Cells["nome"].Value.ToString();
                txtUsuario.Text = row.Cells["usuario"].Value.ToString();
                txtSenha.Text = row.Cells["senha"].Value.ToString();
                cbAPP.SelectedItem = row.Cells["applicativo"].Value.ToString();
                txtWhatsapp.Text = row.Cells["whatsapp"].Value.ToString();

                if (row.Cells["data_vencimento"].Value != DBNull.Value)
                {
                    DateTime dataVencimento = Convert.ToDateTime(row.Cells["data_vencimento"].Value);
                    txtDataVencimento.Text = dataVencimento.ToString("dd/MM/yyyy");
                }

                cbStatus.SelectedItem = row.Cells["status_pagamento"].Value.ToString();
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (idClienteAtual.HasValue)
            {
                try
                {
                    // Confirmação antes de deletar
                    DialogResult result = MessageBox.Show("Tem certeza que deseja deletar este cliente?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        using (MySqlConnection conn = new MySqlConnection(connectionString))
                        {
                            conn.Open();

                            // Adicione verificação de dependências (opcional)
                            // Exemplo: Verificar se existem registros em outras tabelas relacionadas a este cliente.

                            string query = "DELETE FROM tb_clientes WHERE id_cliente = @idCliente";

                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@idCliente", idClienteAtual.Value);
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Cliente deletado com sucesso!");

                                    // Atualiza o status e as labels no frmMaster
                                    masterForm.AtualizarStatusClientes();
                                    masterForm.lblTotalClientes.Text = masterForm.ObterTotalClientes().ToString();
                                    masterForm.lblClientesAtivos.Text = masterForm.ObterTotalClientesAtivos().ToString();
                                    masterForm.lblClientesVencer.Text = masterForm.ObterClientesVencer().ToString();
                                    masterForm.lblClientesVencidos.Text = masterForm.ObterClientesVencidos().ToString();

                                    // Limpar os campos de texto após a exclusão
                                    LimparCampos();

                                    // Recarrega a lista de clientes no DataGridView
                                    CarregarClientes();

                                    // Reseta o ID do cliente atual
                                    idClienteAtual = null;
                                }
                                else
                                {
                                    MessageBox.Show("Cliente não encontrado. A exclusão falhou.");
                                }
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Erro de banco de dados ao deletar o cliente: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao deletar o cliente: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Nenhum cliente selecionado para deletar.");
            }

        }
        // Método auxiliar para limpar os campos de entrada
        private void LimparCampos()
        {
            txtNome.Clear();
            txtUsuario.Clear();
            txtSenha.Clear();
            cbAPP.SelectedIndex = -1; // Desseleciona qualquer item
            txtWhatsapp.Clear();
            txtDataVencimento.Clear();
            cbStatus.SelectedIndex = -1;
            cbPrefixo.SelectedIndex = -1;
        }

        private void cbPrefixo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
