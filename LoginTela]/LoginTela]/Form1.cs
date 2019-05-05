using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using TelaInicial;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginTela_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=02NB-EMANUEL;Database=Mein;User Id=sa;Password=Teiko@123;";
            con.Open();
            string userid = textBox1.Text;
            string password = textBox2.Text;
            SqlCommand cmd = new SqlCommand("select * from usuario where NomeUsuario='" + userid + "'and senha='" + password + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                con.Close();
                con.Open();
                SqlCommand cmd2 = new SqlCommand("update ultimo_login set id =(select id from usuario where NomeUsuario=@nome)", con);
                cmd2.Parameters.AddWithValue("@nome", userid);
                cmd2.ExecuteNonQuery();
                con.Close();

                TelaInicial.TelaInicial telaInicial = new TelaInicial.TelaInicial();
                telaInicial.Visible = true;
                Visible = false;
            }
            else
            {
                MessageBox.Show("Login ou senha inválidos!");
            }
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
            AlterarSenha alterarSenha = new AlterarSenha();
            alterarSenha.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
