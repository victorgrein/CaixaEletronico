using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginTela_
{
    public partial class AlterarSenha : Form
    {
        Form1 form1 = new Form1();

        public AlterarSenha()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != ""))
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
                con.Close();
                if (dt.Rows.Count > 0)
                {
                    if (textBox3.TextLength < 5)
                    {
                        MessageBox.Show("A senha deve ter 5 Caracteres");
                    }
                    else
                    {
                        if ((textBox3.Text == textBox4.Text))
                        {


                            if (textBox3.Text != textBox2.Text)
                            {
                                string passwordNew = textBox3.Text;

                                con.Open();
                                cmd = new SqlCommand("update usuario set PenultimaSenha = ( select UltimaSenha from Usuario where NomeUsuario= @nome ) where NomeUsuario= @nome", con);
                                cmd.Parameters.AddWithValue("@nome", userid);
                                cmd.Parameters.AddWithValue("@senha", passwordNew);
                                cmd.ExecuteNonQuery();
                                con.Close();

                                con.Open();
                                cmd = new SqlCommand("update usuario set UltimaSenha = ( select Senha from Usuario where NomeUsuario= @nome ) where NomeUsuario= @nome", con);
                                cmd.Parameters.AddWithValue("@nome", userid);
                                cmd.Parameters.AddWithValue("@senha", passwordNew);
                                cmd.ExecuteNonQuery();
                                con.Close();

                                con.Open();
                                cmd = new SqlCommand("update usuario set Senha= @senha where NomeUsuario= @nome", con);
                                cmd.Parameters.AddWithValue("@nome", userid);
                                cmd.Parameters.AddWithValue("@senha", passwordNew);
                                cmd.ExecuteNonQuery();
                                con.Close();

                                Visible = false;
                                form1.Show();

                                con.Close();
                            }
                            else
                            {
                                MessageBox.Show("Nova senha não pode ser igual a senha antiga!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Senhas não são iguais!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Dados Inválidos!");
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Dados Inválidos!");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
            form1.Show();
        }
    }
}
