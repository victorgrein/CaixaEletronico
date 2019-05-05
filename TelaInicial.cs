using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelaInicial
{

    public partial class TelaInicial : Form
    {
        public int Saldo { get; set; }
        
        public TelaInicial()
        {
            InitializeComponent();
        }

        private void btnConsultarSaldo_Click(object sender, EventArgs e)
        {
            TelaSaldo telaSaldo = new TelaSaldo();
            telaSaldo.Visible = true;
            Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
