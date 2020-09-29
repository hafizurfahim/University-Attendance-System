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
    public partial class marks : Form
    {
        //SqlCommand command;
        SqlDataAdapter da;
        private BindingSource bindingSource = null;
        private SqlCommandBuilder oleCommandBuilder = null;
        DataTable dataTable = new DataTable();
        public marks()
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
                //thisCommand.CommandText= "SELECT * FROM teacher WHERE id='" + textBox1.Text + "' AND password='" + textBox2.Text + "'";

                string list = "SELECT * FROM mark WHERE course_code = '" + comboBox1.Text + "' AND section= '" + comboBox2.Text + "'AND semester= '" + comboBox3.Text + "' ";

                SqlDataAdapter dataadapter = new SqlDataAdapter(list, CN.thisConnection);



                DataSet ds = new DataSet();
                dataadapter.Fill(ds, "mark ");
                dataGridView1.DataSource = ds.Tables[0];
                
                //dataGridView1.Columns[3].Visible = false;

                DataBind();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit(); //very important step
            da.Update(dataTable);

            MessageBox.Show("Updated");
            DataBind();
        }
        private void DataBind()
        {
            dataGridView1.DataSource = null;
            dataTable.Clear();

            Connection CN = new Connection();
            CN.thisConnection.Open();//use your connection string please
            String queryString1 = "select * from mark WHERE course_code = '" + comboBox1.Text + "' AND section= '" + comboBox2.Text + "'AND semester= '" + comboBox3.Text + "' ";


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

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Connection CN = new Connection();
            CN.thisConnection.Open();


            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT DISTINCT course_code FROM mark ", CN.thisConnection);
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

        private void button4_Click_1(object sender, EventArgs e)
        {
            Connection CN = new Connection();
            CN.thisConnection.Open();


            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT DISTINCT section FROM mark ", CN.thisConnection);
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.EndEdit(); //very important step
            da.Update(dataTable);

            MessageBox.Show("Updated");
            DataBind();
        }

        private void button6_Click(object sender, EventArgs e)
        {


        }

        private void button7_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int i;
          

            for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                int c = 0,sum = 0;
                dataGridView1.Rows[i].Cells[14].Value = 0;
                for (int j = 6; i < dataGridView1.Columns.Count - 4; j++)
                {
                 //   MessageBox.Show("i=" + i + "j =" + j.ToString());
                    
                         c = Convert.ToInt32(dataGridView1.Rows[i].Cells[j].Value);
                   
                    // int a = Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                    // int b = Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);
                    // int sum = a+b;
                    sum = sum + c;
                    if (sum < 50 && sum > 0)
                    {
                        dataGridView1.Rows[i].Cells[15].Value = "F";
                    }
                    else if (sum >= 50 && sum <= 59)
                    {
                        dataGridView1.Rows[i].Cells[15].Value = "D";
                    }
                    else if (sum >= 60 && sum <= 64)
                    {
                        dataGridView1.Rows[i].Cells[15].Value = "c+";
                    }
                    else if (sum >= 65 && sum <= 69)
                    {
                        dataGridView1.Rows[i].Cells[15].Value = "B-";
                    }
                    else if (sum >= 70 && sum <= 74)
                    {
                        dataGridView1.Rows[i].Cells[15].Value = "B";
                    }
                    else if (sum >= 75 && sum <= 79)
                    {
                        dataGridView1.Rows[i].Cells[15].Value = "B+";
                    }
                    else if (sum >= 80 && sum <= 84)
                    {
                        dataGridView1.Rows[i].Cells[15].Value = "A-";
                    }
                    else if (sum >= 85 && sum <= 94)
                    {
                        dataGridView1.Rows[i].Cells[15].Value = "A";
                    }
                    else if (sum >= 94 && sum <= 100)
                    {
                        dataGridView1.Rows[i].Cells[15].Value = "A+";
                    }

                    //  dataGridView10.Rows[i].Cells[14].Value = sum;
                    if (j == 14)
                    {
                        break;
                    }

                }
                if(sum>100|| sum < 0)
                {
                    MessageBox.Show(" Enter valid number !!!");
                    sum = 0;
                }
                dataGridView1.Rows[i].Cells[14].Value =sum;
                //MessageBox.Show(sum.ToString());
            }

            //this.Close();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void marks_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

