using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppContatoForm
{
    public partial class ContatoForm : Form
    {
        private MySqlConnection conexao;

        private MySqlCommand comando;

        public ContatoForm()
        {
            InitializeComponent();

            Conexao();
        }

        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_bd;user=root;password=root;port=3360";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {

                if (!rdSexo1.Checked && !rdSexo2.Checked)
                {
                    MessageBox.Show("Marque uma opção");
                }

                var nome = txtNome.Text;
                var email = txtEmail.Text;
                var data_nascimento = dateDataNascimento.ToString();
                var telefone = txtTelefone.Text;
                var sexo = "Feminino";


                if (rdSexo1.Checked)
                {
                    sexo = "Masculino";
                }


                if (nome != null && email != null && sexo != null && data_nascimento != null && telefone != null)
                {
                    string query = "INSERT INTO contato (nome_con, email_con, sexo_con, data_nasc_con, telefone_con) VALUES (@_nome, @_email, @_sexo, @_data_nasc, @_telefone)";
                    var comando = new MySqlCommand(query, conexao);

                    comando.Parameters.AddWithValue("@_nome", nome);
                    comando.Parameters.AddWithValue("@_email", email);
                    comando.Parameters.AddWithValue("@_sexo", sexo);
                    comando.Parameters.AddWithValue("@_data_nasc", data_nascimento);
                    comando.Parameters.AddWithValue("@_telefone", telefone);

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Os dados foram salvos com sucesso!!!");
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos!!!");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}