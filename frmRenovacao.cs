using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace VPlay
{
    public partial class frmRenovacao : Form
    {
        private string connectionString = "Server=localhost;Database=db_vplay;User ID=root;Password=2707;";
        private frmMaster masterForm; // Referência para o frmMaster
        public string IdCliente { get; private set; }
        public DateTime DataVencimentoAtual { get; private set; }

        // Construtor que aceita idCliente e dataVencimentoAtual
        public frmRenovacao(string idCliente, DateTime dataVencimentoAtual, frmMaster master)
        {
            InitializeComponent();
            IdCliente = idCliente;
            DataVencimentoAtual = dataVencimentoAtual;
            masterForm = master; // Armazena a referência do frmMaster

            // Ajusta as propriedades do DateTimePicker
            dtpNovaDataVencimento.MinDate = DateTime.Today; // Garante que a data mínima seja hoje
            dtpNovaDataVencimento.MaxDate = new DateTime(9998, 12, 31);

            // Verifica se a dataVencimentoAtual está dentro do intervalo permitido
            if (dataVencimentoAtual < dtpNovaDataVencimento.MinDate)
            {
                dtpNovaDataVencimento.Value = dtpNovaDataVencimento.MinDate;
            }
            else if (dataVencimentoAtual > dtpNovaDataVencimento.MaxDate)
            {
                dtpNovaDataVencimento.Value = dtpNovaDataVencimento.MaxDate;
            }
            else
            {
                // Carrega a data de vencimento atual no DateTimePicker se estiver dentro do intervalo permitido
                dtpNovaDataVencimento.Value = dataVencimentoAtual;
            }

            // Obter e exibir a data de vencimento do banco de dados
            lblVencimento.Text = ObterDataVencimento().ToString("dd/MM/yyyy");
        }
        
        // Método para buscar a data de vencimento do banco de dados
        private DateTime ObterDataVencimento()
        {
            DateTime dataVencimento = DateTime.MinValue;

            // Conectar ao banco de dados
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT data_vencimento FROM tb_clientes WHERE id_cliente = @idCliente";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idCliente", IdCliente);

                        // Executa a consulta e obtém o resultado
                        object result = cmd.ExecuteScalar();
                        if (result != null && DateTime.TryParse(result.ToString(), out dataVencimento))
                        {
                            return dataVencimento; // Retorna a data de vencimento obtida
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao buscar a data de vencimento: {ex.Message}");
                }
            }

            return dataVencimento; // Retorna a data de vencimento ou a data mínima caso haja erro
        }

        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {
            DateTime novaDataVencimento = dtpNovaDataVencimento.Value; // Obtém a nova data escolhida

            // Conectar ao banco de dados e atualizar a data de vencimento e o status_pagamento
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE tb_clientes SET data_vencimento = @novaDataVencimento, status_pagamento = 'PAGO' WHERE id_cliente = @idCliente";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@novaDataVencimento", novaDataVencimento);
                        cmd.Parameters.AddWithValue("@idCliente", IdCliente);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data de vencimento e status de pagamento atualizados com sucesso!");

                            // Atualiza o status dos clientes após salvar
                            masterForm.AtualizarStatusClientes(); // Chama o método para atualizar o status dos clientes

                            // Atualiza as contagens de clientes
                            int totalClientes = masterForm.ObterTotalClientes();
                            int totalClientesAtivos = masterForm.ObterTotalClientesAtivos();
                            int clientesVencer = masterForm.ObterClientesVencer();
                            int clientesVencidos = masterForm.ObterClientesVencidos();

                            masterForm.lblTotalClientes.Text = masterForm.ObterTotalClientes().ToString();
                            masterForm.lblClientesAtivos.Text = masterForm.ObterTotalClientesAtivos().ToString();
                            masterForm.lblClientesVencer.Text = masterForm.ObterClientesVencer().ToString();
                            masterForm.lblClientesVencidos.Text = masterForm.ObterClientesVencidos().ToString();

                            masterForm.CarregarDadosClientes();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Nenhum registro foi atualizado. Verifique o ID do cliente.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao atualizar a data de vencimento e o status de pagamento: {ex.Message}");
                }
            }
        }
    }
}
