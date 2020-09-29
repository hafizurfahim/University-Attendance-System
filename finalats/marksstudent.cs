using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System
    .Windows.Forms;

namespace finalats
{
    public partial class marksstudent : Form
    {
        //SqlCommand command;
        SqlDataAdapter da;
        private BindingSource bindingSource = null;
        private SqlCommandBuilder oleCommandBuilder = null;
        DataTable dataTable = new DataTable();
        public marksstudent()
        {
            InitializeComponent();
        }

        private void sheet_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void DataBind()
        {
            dataGridView1.DataSource = null;
            dataTable.Clear();

            Connection CN = new Connection();

            CN.thisConnection.Open();//use your connection string please
            String queryString1 = "select * from mark WHERE semester= '" + comboBox3.Text + "' AND id='" + textBox1.Text + "' ";


            SqlCommand command = CN.thisConnection.CreateCommand();
            command.CommandText = queryString1;
            try
            {
                da = new SqlDataAdapter(queryString1, CN.thisConnection);
                oleCommandBuilder = new SqlCommandBuilder(da);
                da.Fill(dataTable);
                bindingSource = new BindingSource { DataSource = dataTable };
                dataGridView1.DataSource = bindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Connection CN = new Connection();
            CN.thisConnection.Open();
            SqlCommand thisCommand = new SqlCommand();
            thisCommand.Connection = CN.thisConnection;
            if (comboBox3.SelectedItem == null)
            {

                MessageBox.Show("semester first !.");
            }
            else
            {
                //thisCommand.CommandText= "SELECT * FROM teacher WHERE id='" + textBox1.Text + "' AND password='" + textBox2.Text + "'";

                string list = "SELECT * FROM studen WHERE  semester= '" + comboBox3.Text + "'AND id='" + textBox1.Text + "' ";

                SqlDataAdapter dataadapter = new SqlDataAdapter(list, CN.thisConnection);



                DataSet ds = new DataSet();
                dataadapter.Fill(ds, "mark ");
                dataGridView1.DataSource = ds.Tables[0];
                //dataGridView1.Columns[3].Visible = false;

                DataBind();

            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            studenthome shm = new studenthome();
            shm.Show();
            this.Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Connection CN = new Connection();
            CN.thisConnection.Open();


            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT DISTINCT semester FROM mark ", CN.thisConnection);
            DataTable dt = new DataTable();

            thisAdapter.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox3.DroppedDown = true;
                comboBox3.Items.Add(dt.Rows[i]["semester"]);
                //  dataGridView1.DataSource = dt;
            }



            CN.thisConnection.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection CN = new Connection();
            CN.thisConnection.Open();
            SqlCommand thisCommand = new SqlCommand();
            thisCommand.Connection = CN.thisConnection;
            if (comboBox3.SelectedItem == null)
            {

                MessageBox.Show("semester first !.");
            }
            else
            {
                //thisCommand.CommandText= "SELECT * FROM teacher WHERE id='" + textBox1.Text + "' AND password='" + textBox2.Text + "'";

                string list = "SELECT * FROM studen WHERE  semester= '" + comboBox3.Text + "'AND id='" + textBox1.Text + "' ";

                SqlDataAdapter dataadapter = new SqlDataAdapter(list, CN.thisConnection);



                DataSet ds = new DataSet();
                dataadapter.Fill(ds, "mark ");
                dataGridView1.DataSource = ds.Tables[0];
                //dataGridView1.Columns[3].Visible = false;

                DataBind();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
