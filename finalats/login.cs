using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QRCoder;

namespace finalats
{
    public partial class login : Form
    {
        public string s_id,s_code;
        
        public login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sign s = new sign();
            s.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

           
                studenthome h = new studenthome();


                h.Show();
                this.Hide();

               
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();
                SqlCommand thisCommand = new SqlCommand();
                thisCommand.Connection = CN.thisConnection;
               
               
                    thisCommand.CommandText = "SELECT * FROM teacher WHERE id='" + textBox1.Text + "' AND password='" + textBox2.Text + "'";

                    SqlDataReader thisReader = thisCommand.ExecuteReader();
                    if (thisReader.Read())
                    {
                        Home s = new Home();

                        s.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("username or password incorrect");
                    }
                    
                    CN.thisConnection.Close();

                }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void qrbox_Click(object sender, EventArgs e)
        {

        }

        private void da_Click(object sender, EventArgs e)
        {
          
               
            
        }
    }
}
    
