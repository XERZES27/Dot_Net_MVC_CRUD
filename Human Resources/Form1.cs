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
using System.Data.OleDb;
using System.IO;

namespace Human_Resources
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=D:\4th Year\DP\Human Resources\Human Resources\bin\Debug\DB_Server1.mdf;Integrated Security = True; Connect Timeout = 30");
        
        
        

        public Form1()
        {
            InitializeComponent();
            display_data();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            bool IsDuplicate = false;
            


            int parsedValue;
            if (!int.TryParse(textBox1.Text, out parsedValue))
            {
                MessageBox.Show("Id field must not contain other charaters other than numbers");
                connection.Close();
                return;

            }
            else if (!int.TryParse(textBox9.Text, out parsedValue))
            {
                MessageBox.Show("Tel field must not contain other charaters other than numbers");
                connection.Close();
                return;
            }



            if ((textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != ""
               && textBox4.Text != "" && textBox5.Text != ""
               && textBox6.Text != "" && textBox7.Text != "" &&
               textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox13.Text != "") && !IsDuplicate)
                {


                    cmd.CommandText = "insert into [Employees] (ID,[First Name],[Last Name],Sex,[Date of Birth],Position,Project,[Salary Level],Tel,Country,[Education Level],Training,[Date of Employement]) values ('" + textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "')";

                    cmd.ExecuteNonQuery();
                    connection.Close();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
                    textBox11.Text = "";
                    textBox12.Text = "";
                    textBox13.Text = "";
                    display_data();
                   IsDuplicate = false;
                    MessageBox.Show("Data inserted Successfully");


                }
                else
                {
                    MessageBox.Show("Pleast fill all the fields");
                    connection.Close();
                }
            }
            
        
            
                
            
        

        public void display_data()
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [Employees]";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(dta);
            dataGridView1.DataSource = dta;
            connection.Close();

            dataGridView1.Columns[0].Width = 45;
            dataGridView1.Columns[3].Width = 45;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 300;
            dataGridView1.Columns[6].Width = 300;
            dataGridView1.Columns[7].Width = 140;
            dataGridView1.Columns[9].Width = 100;
            dataGridView1.Columns[10].Width = 300;
            dataGridView1.Columns[11].Width = 300;
            dataGridView1.Columns[12].Width = 190;
            dataGridView1.RowTemplate.Height = 34;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            display_data();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from [Employees] where [ID]= '" + textBox1.Text + "'";

            if (MessageBox.Show("Are you sure you want to delete this record?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Data deleted Successfully");
            }
            else
            {
                connection.Close();
            }
            //cmd.ExecuteNonQuery();
            //connection.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            display_data();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;

            int parsedValue;
            if (!int.TryParse(textBox1.Text, out parsedValue))
            {
                MessageBox.Show("Id field must not contain other charaters other than numbers");
                connection.Close();
                return;

            }
            else if (!int.TryParse(textBox9.Text, out parsedValue))
            {
                MessageBox.Show("Tel field must not contain other charaters other than numbers");
                connection.Close();
                return;
            }

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != ""
                && textBox4.Text != "" && textBox5.Text != ""
                && textBox6.Text != "" && textBox7.Text != "" &&
                textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox13.Text != "")
            {
                cmd.CommandText = "update Employees set [First Name] = '" + textBox2.Text + "',[Last Name] = '" + textBox3.Text + "' ,[Sex] = '" + textBox4.Text + "',  [Date of Birth] = '" + textBox5.Text + "' , [Position] = '" + textBox6.Text + "'  ,[Project] = '" + textBox7.Text + "' , [Salary Level] = '" + textBox8.Text + "' , [Tel] = '" + textBox9.Text + "' , [Country] = '" + textBox10.Text + "' , [Education Level] = '" + textBox11.Text + "' , [Training] = '" + textBox12.Text + "' , [Date of Employement] = '" + textBox13.Text + "' where ID = '" + textBox1.Text + "'";

                //DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
                cmd.ExecuteNonQuery();
                connection.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";
                display_data();
                MessageBox.Show("Data updated Successfully");
            }
            else
            {
                connection.Close();
                MessageBox.Show("Please don't leave any empty fields!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Columns[0].Frozen = true;
            dataGridView1.Columns[1].Frozen = true;
            dataGridView1.Columns[2].Frozen = true;

            //indexRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                //gets a collection that contains all the rows
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                textBox6.Text = row.Cells[5].Value.ToString();
                textBox7.Text = row.Cells[6].Value.ToString();
                textBox8.Text = row.Cells[7].Value.ToString();
                textBox9.Text = row.Cells[8].Value.ToString();
                textBox10.Text = row.Cells[9].Value.ToString();
                textBox11.Text = row.Cells[10].Value.ToString();
                textBox12.Text = row.Cells[11].Value.ToString();
                textBox13.Text = row.Cells[12].Value.ToString();


            }
        }





        private void button4_Click_1(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText =
           "select * from Employees where [First Name] like '%" + textBox14.Text + "%' or [Last Name] like '%" + textBox14.Text + "%' or [Sex] like '%" + textBox14.Text + "%' or  [Date of Birth]like '%" + textBox14.Text + "%' or [Position] like '%" + textBox14.Text + "%' or[Project] like '%" + textBox14.Text + "%' or [Salary Level]like '%" + textBox14.Text + "%' or [Tel] like '%" + textBox14.Text + "%' or [Country] like '%" + textBox14.Text + "%' or [Education Level]like '%" + textBox14.Text + "%' or [Training] like '%" + textBox14.Text + "%' or [Date of Employement]like '%" + textBox14.Text + "%'";

            //DataGridViewRow newDataRow = dataGridView1.Rows[indexRow];
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";

            //connection.Open();
            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter(
            // "select * from Employees  where [First Name] = '" + textBox2.Text + "'", connection);
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
            //connection.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        
    }

}
