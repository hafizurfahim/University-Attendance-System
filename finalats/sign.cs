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

namespace finalats
{
    public partial class sign : Form
    {
        public sign()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection sv = new Connection();
            sv.thisConnection.Open();
            
                SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM studen", sv.thisConnection);
            SqlDataAdapter thisAdapterr = new SqlDataAdapter("SELECT * FROM mark", sv.thisConnection);

            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);
            SqlCommandBuilder thisBuilderr = new SqlCommandBuilder(thisAdapterr);
            DataSet thisDataSet = new DataSet();
            DataSet thisDataSett = new DataSet();
            thisAdapter.Fill(thisDataSet, "data");
            thisAdapterr.Fill(thisDataSett, "dataa");
            DataRow thisRoww = thisDataSett.Tables["dataa"].NewRow();
            DataRow thisRow = thisDataSet.Tables["data"].NewRow();
           

                try
                {
                thisRoww["name"] = textBox1.Text;
                thisRow["name"] = textBox1.Text;
                    thisRow["password"] = textBox2.Text;
                //thisRoww["password"] = textBox2.Text;
                thisRow["id"] = textBox3.Text;
                thisRoww["id"] = textBox3.Text;
                thisRow["section"] = textBox4.Text;
                thisRoww["section"] = textBox4.Text;
                thisRow["semester"] = textBox5.Text;
                thisRoww["semester"] = textBox5.Text;
                thisRow["course_code"] = textBox7.Text;
                thisRoww["course_code"] = textBox7.Text;
                thisRow["serial"] = textBox8.Text;
                thisRoww["serial"] = textBox8.Text;


                thisDataSet.Tables["data"].Rows.Add(thisRow);
                thisDataSett.Tables["dataa"].Rows.Add(thisRoww);
                thisAdapterr.Update(thisDataSett, "dataa");

                thisAdapter.Update(thisDataSet, "data");
                    MessageBox.Show("Submitted");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sv.thisConnection.Close();


                login l = new login();
                l.Show();
                this.Hide();
            }
        

        private void button2_Click(object sender, EventArgs e)
        {
            Connection sv = new Connection();
            sv.thisConnection.Open();

            SqlDataAdapter thisAdapter = new SqlDataAdapter("SELECT * FROM teacher", sv.thisConnection);

            SqlCommandBuilder thisBuilder = new SqlCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "data");

            DataRow thisRow = thisDataSet.Tables["data"].NewRow();
            try
            {

                thisRow["name"] = textBox1.Text;
                thisRow["password"] = textBox2.Text;
                thisRow["id"] = textBox3.Text;

               // thisRow["section"] = textBox4.Text;
                //thisRow["semester"] = textBox5.Text;
              
                //thisRow["course_code"] = textBox7.Text;

                thisDataSet.Tables["data"].Rows.Add(thisRow);



                thisAdapter.Update(thisDataSet, "data");
                MessageBox.Show("Submitted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sv.thisConnection.Close();


            login l = new login();
            l.Show();
            this.Hide();
        }
    }
}
