using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace VPlay
{
    public partial class frmApp : Form
    {
        private string connectionString = "Server=localhost;Database=db_vplay;User ID=root;Password=2707;";
        private int? idClienteAtual = null;
        private frmMaster masterForm;
        public frmApp()
        {
            InitializeComponent();
            this.Load += new EventHandler(frmApp_Load); // Evento Load
        }

        private void frmApp_Load(object sender, EventArgs e)
        {
            CarregarApps(); // Carrega os apps ao abrir o formulário
        }

        private void btnCADASTRAR_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAPP.Text))
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();

                        if (!string.IsNullOrEmpty(txtIDAPP.Text)) // Editar um app existente
                        {
                            string query = "UPDATE tb_app SET nome = @nome WHERE id_app = @idApp";
                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@nome", txtAPP.Text);
                                cmd.Parameters.AddWithValue("@idApp", Convert.ToInt32(txtIDAPP.Text));
                                cmd.ExecuteNonQuery();
                            }
                            MessageBox.Show("Aplicativo atualizado com sucesso!");
                        }
                        else // Inserir um novo app
                        {
                            string query = "INSERT INTO tb_app (nome) VALUES (@nome)";
                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@nome", txtAPP.Text);
                                cmd.ExecuteNonQuery();
                            }
                            MessageBox.Show("Aplicativo cadastrado com sucesso!");
                        }

                        // Atualizar a lista e limpar os campos após a inserção/edição
                        CarregarApps();
                        LimparCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar o aplicativo: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira o nome do aplicativo.");
            }
        }

        private void btnDELETAR_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIDAPP.Text))
            {
                try
                {
                    DialogResult result = MessageBox.Show("Tem certeza que deseja deletar este aplicativo?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        using (MySqlConnection conn = new MySqlConnection(connectionString))
                        {
                            conn.Open();
                            string query = "DELETE FROM tb_app WHERE id_app = @idApp";
                            using (MySqlCommand cmd = new MySqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@idApp", Convert.ToInt32(txtIDAPP.Text));
                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Aplicativo deletado com sucesso!");
                            CarregarApps();
                            LimparCampos();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao deletar o aplicativo: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Nenhum aplicativo selecionado para deletar.");
            }
        }

        private void dataGridViewAPP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica se a linha é válida
            {
                DataGridViewRow row = dataGridViewAPP.Rows[e.RowIndex];
                txtIDAPP.Text = row.Cells["id_app"].Value.ToString(); // Captura o ID do app
                txtAPP.Text = row.Cells["nome"].Value.ToString(); // Exibe o nome do app selecionado no campo de texto
            }
        }
        private void LimparCampos()
        {
            txtIDAPP.Clear();
            txtAPP.Clear();
        }

        private void CarregarApps()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id_app, nome FROM tb_app";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridViewAPP.DataSource = dt; // Preenche o DataGridView com os apps

                            // Renomear as colunas
                            dataGridViewAPP.Columns["id_app"].HeaderText = "ID";
                            dataGridViewAPP.Columns["nome"].HeaderText = "APP";

                            dataGridViewAPP.Columns["id_app"].Width = 25;
                            dataGridViewAPP.Columns["nome"].Width = 190;
                        }
                    }
                }
                dataGridViewAPP.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os aplicativos: " + ex.Message);
            }
        }

        private void txtIDAPP_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
