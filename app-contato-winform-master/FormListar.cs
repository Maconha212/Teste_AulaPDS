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
    public partial class FormListar : Form
    {
        private MySqlConnection conexao;
        public FormListar()
        {
            InitializeComponent();
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

            string sql = "SELECT * FROM Contato";
            var comando = new MySqlCommand(sql, conexao);
            var adaptador = new MySqlDataAdapter(comando);

            DataTable tabela = new DataTable();

            adaptador.Fill(tabela);

            tabela.Columns["id_con"].ColumnName = "ID";

            dgvContato.DataSource = tabela;
        }
    }
}
