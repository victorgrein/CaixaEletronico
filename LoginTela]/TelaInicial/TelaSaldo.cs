using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using TelaInicial;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TelaInicial
{
    public partial class TelaSaldo : Form 
    {
        public TelaSaldo()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TelaInicial telaInicial = new TelaInicial(); 
            telaInicial.Visible = true;
            Visible = false;
        }

        private void TelaSaldo_Load(object sender, EventArgs e)
        {
            TelaInicial telaInicial = new TelaInicial();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=02NB-EMANUEL;Database=Mein;User Id=sa;Password=Teiko@123;";
            con.Open();
            SqlCommand cmd = new SqlCommand("select saldo from Saldo where Id =(select id from ultimo_login)", con);
            Int32 sql_max = Convert.ToInt32(cmd.ExecuteScalar());
            lblSaldo.Text = sql_max.ToString();
            con.Close();
        }
    }
}
     