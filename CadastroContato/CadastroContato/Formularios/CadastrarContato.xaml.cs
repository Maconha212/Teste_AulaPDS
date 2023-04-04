using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace CadastroContato.Formularios
{
    /// <summary>
    /// Lógica interna para CadastrarContato.xaml
    /// </summary>
    public partial class CadastrarContato : Window
    {
        private MySqlConnection conexao;

        private MySqlCommand comando;

        public CadastrarContato()
        {
            InitializeComponent();
            txtNome.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();

            Conexao();
        }

        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_bd;user=root;password=root;port=3360";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }
        public void limparEspacos()
        {
            txtNome.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
        }

        private void btnSalvar(object sender, RoutedEventArgs e)
        {
            try
            {
                var nome = txtNome.Text;
                var sexo = "Feminino";
                var email = txtEmail.Text;
                var telefone = txtTelefone.Text;
                DateTime? dataNascimento = null;

                if (dateDataNascimento.SelectedDate != null)
                {
                    dataNascimento = (DateTime)dateDataNascimento.SelectedDate;
                }

                if (nome != "" && sexo != "" && email != "" && telefone != "" && dataNascimento != null)
                {
                    var sql = "INSERT INTO contato (nome_con, sexo_con, email_con, telefone_con, data_nasc_con) VALUES (@_nome, @_sexo, @_email, @_telefone, @_dataNasc);";
                    var cmd = new MySqlCommand(sql, conexao);

                    cmd.Parameters.AddWithValue("@_nome", nome);
                    cmd.Parameters.AddWithValue("@_sexo", sexo);
                    cmd.Parameters.AddWithValue("@_email", email);
                    cmd.Parameters.AddWithValue("@_telefone", telefone);
                    cmd.Parameters.AddWithValue("@_dataNasc", dataNascimento?.ToString("yyyy-MM-dd"));

                    cmd.ExecuteNonQuery();

                    limparEspacos();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
