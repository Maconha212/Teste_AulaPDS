using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
    /// Lógica interna para ListarContato.xaml
    /// </summary>
    public partial class ListarContato : Window
    {
        private MySqlConnection conexao;
        public ListarContato()
        {
            InitializeComponent();
            Conexao();
            Listar();
        }

        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_bd;user=root;password=root;port=3360";
            conexao = new MySqlConnection(conexaoString);
            conexao.Open();
        }

        private void Listar()
        {
            Conexao();

            string sql = "SELECT * FROM contato;";


            var comando = new MySqlCommand(sql, conexao);
            var reader = comando.ExecuteReader();

            var lista = new List<Object>();


            while (reader.Read())
            {
                var contato = new
                {
                    Nome = reader.GetString("nome_con"),
                    Telefone = reader.GetString("telefone_con"),
                    Email = reader.GetString("email_con"),
                    Sexo = reader.GetString("sexo_con"),
                    DataNascimento = reader.GetString("data_nasc_con")
                };

                lista.Add(contato);
            }

            dgvContato.ItemsSource = lista;
        }

        private void dgvContato_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
