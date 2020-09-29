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
    public partial class sheet : Form
    {
        //SqlCommand command;
        SqlDataAdapter da;
        private BindingSource bindingSource = null;
        private SqlCommandBuilder oleCommandBuilder = null;
        DataTable dataTable = new DataTable();
        public sheet()
        {
            InitializeComponent();
        }

        private void sheet_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Connection CN = new Connection();
            CN.thisConnection.Open();
            SqlCommand thisCommand = new SqlCommand();
            thisCommand.Connection = CN.thisConnection;
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null)
            {

                MessageBox.Show("Select course,section,semester first !.");
            }
            else
            {
                try {
                    //thisCommand.CommandText= "SELECT * FROM teacher WHERE id='" + textBox1.Text + "' AND password='" + textBox2.Text + "'";

                    string list = "SELECT * FROM studen WHERE course_code = '" + comboBox1.Text + "' AND section= '" + comboBox2.Text + "'AND semester= '" + comboBox3.Text + "' ";

                    SqlDataAdapter dataadapter = new SqlDataAdapter(list, CN.thisConnection);



                    DataSet ds = new DataSet();
                    dataadapter.Fill(ds, "studen ");
                   
                    dataGridView1.DataSource = ds.Tables[0];
                    

                    //dataGridView1.Columns[3].Visible = false;

                    DataBind();
                }
                catch (Exception ex) { }
                }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                dataGridView1.EndEdit(); //very important step
                da.Update(dataTable);

                MessageBox.Show("Updated");
                DataBind();
            }
            catch (Exception ex)
            {

            }
            }
        private void DataBind()
        {
            dataGridView1.DataSource = null;
            dataTable.Clear();

            Connection CN = new Connection();

            CN.thisConnection.Open();//use your connection string please
            String queryString1 = "select * from studen WHERE course_code = '" + comboBox1.Text + "' AND section= '" + comboBox2.Text + "'AND semester= '" + comboBox3.Text + "' ";


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

        private void button3_Click(object sender, EventArgs e)
        {
            Connection CN = new Connection();
            CN.thisConnection.Open();


            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT DISTINCT course_code FROM studen ", CN.thisConnection);
            DataTable dt = new DataTable();

            thisAdapter.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.DroppedDown = true;
                comboBox1.Items.Add(dt.Rows[i]["course_code"]);
                //dataGridView1.DataSource = dt;
            }
            // dataGridView1.DataSource = dt;
            // CN.thisConnection.Close();


            CN.thisConnection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Connection CN = new Connection();
            CN.thisConnection.Open();


            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT DISTINCT section FROM studen ", CN.thisConnection);
            DataTable dt = new DataTable();

            thisAdapter.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox2.DroppedDown = true;
                comboBox2.Items.Add(dt.Rows[i]["section"]);

                // dataGridView1.DataSource = dt;
            }
            // dataGridView1.DataSource = dt;
            // CN.thisConnection.Close();


            CN.thisConnection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Connection CN = new Connection();
            CN.thisConnection.Open();


            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT DISTINCT semester FROM studen ", CN.thisConnection);
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            DateTime date = this.dateTimePicker1.Value;

            this.textBox1.Text = date.ToString("yyyy-mm-dd");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                Connection CN = new Connection();
                CN.thisConnection.Open();
                SqlCommand thisCommand = new SqlCommand();
                thisCommand.Connection = CN.thisConnection;



                string c = "[";
                string b = c + textBox1.Text.ToString();
                string a = b + "]";


                thisCommand.CommandText = "ALTER TABLE [studen] ADD " + a + "BIT NOT NULL DEFAULT 0";
                SqlDataReader thisReader = thisCommand.ExecuteReader();
                if (thisReader.Read())
                {
                    MessageBox.Show("use");
                }


                CN.thisConnection.Close();
            }
            catch
            {


            }
            //this.Show();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            hm.Show();
            this.Close();



        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns["password"].Visible = false;
            int i;


            for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                int c = 0, sum = 0;
                dataGridView1.Rows[i].Cells[7].Value = 0;
                for (int j = 8; i < dataGridView1.Columns.Count; j++)
                {
                     // MessageBox.Show("i=" + i + "j =" + j.ToString());
                    if (j == dataGridView1.Columns.Count)
                    {
                        break;
                    }

                    c = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                    //MessageBox.Show(c.ToString());

                    sum = sum + c;

                   
                }
                dataGridView1.Rows[i].Cells[7].Value = sum;
            }
        }

    }
}