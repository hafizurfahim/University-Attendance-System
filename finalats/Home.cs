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

namespace finalats
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sheet s = new sheet();

            s.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            studentinfo info = new studentinfo();
            info.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            marks marrk = new marks();
            marrk.Show();
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
            login ll = new login();
            ll.Show();
            this.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Qr_code q = new Qr_code();
            q.Show();
            this.Hide();
        }
    }
}
