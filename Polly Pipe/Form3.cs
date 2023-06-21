using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Polly_Pipe
{
    public partial class Form3 : Form

    {
        private static string myConn = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        string eid, emt, name, salary, cont, srch;
        public Form3()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            {
                DialogResult mm1;
                mm1 = MessageBox.Show("Are you sure,Do you really want to Exit...?", "Exit", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);
                if (mm1.ToString() == "Yes")
                {
                    Application.Exit();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();

        }
        private void LoadData()
        {
            eid = textBox2.Text;
            emt = textBox3.Text;
            name = textBox4.Text;
            salary = textBox5.Text;
            cont = textBox6.Text;
        }

        private void ClearControls()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void LoaGridView()
        {
            try
            {
                LoadData();
                string Getdata = "select * from Table_2";
                var datatable = new DataTable();
                using (SqlConnection con = new SqlConnection(myConn))
                {
                    con.Open();

                    using (SqlCommand com2 = new SqlCommand(Getdata, con))
                    {

                        using (SqlDataAdapter adapter = new SqlDataAdapter(com2))
                        {
                            adapter.Fill(datatable);
                            dataGridView1.DataSource = datatable;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //con.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Emp ID cannot be empty!");
                }

                int rows;
                string UpdateQuery = "Update Table_2 set Emp_Type=@Emp_Type, Name=@Name, salary=@salary,co_num=@co_num where emp_id=@emp_id";
                using (SqlConnection con = new SqlConnection(myConn))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(UpdateQuery, con))
                    {
                        com.Parameters.AddWithValue("@emp_id", eid);
                        com.Parameters.AddWithValue("@Emp_Type", emt);
                        com.Parameters.AddWithValue("@Name", name);
                        com.Parameters.AddWithValue("@salary", salary);
                        com.Parameters.AddWithValue("@co_num", cont);
                        rows = com.ExecuteNonQuery();
                    }
                    LoaGridView();
                    ClearControls();
                }
                if (rows > 0)
                {
                    MessageBox.Show("Update Successfull!", "update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //con.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                string DeleteQuery = "Delete from Table_2 where emp_id=@emp_id";
                int rows;
                using (SqlConnection con = new SqlConnection(myConn))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(DeleteQuery, con))
                    {
                        com.Parameters.AddWithValue("@emp_id", eid);
                        rows = com.ExecuteNonQuery();
                    }
                    LoaGridView();
                    ClearControls();
                }
                if (rows > 0)
                {
                    MessageBox.Show("Delete Successfull!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // con.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            srch = textBox7.Text;
            DataTable datatable = new DataTable();
            string SearchQuery = "select * from Table_2 where emp_id=@emp_id";
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(SearchQuery, con))
                {
                    com.Parameters.AddWithValue("@emp_id", srch);
                    //com.Parameters.AddWithValue("@Srch", srch);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                        dataGridView1.DataSource = datatable;
                    }
                }

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();

                if (textBox2.Text == "")
                {
                    MessageBox.Show("Emp ID cannot be empty!");
                }

                string InsertQuery = "insert into Table_2 (emp_id,Emp_Type,Name,salary,co_num)  values ( '" + eid + "', '" + emt + "', '" + name + "', '" + salary + "', '" + cont + "')";

                int rows;
                using (SqlConnection con = new SqlConnection(myConn))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(InsertQuery, con))
                    {

                        rows = com.ExecuteNonQuery();
                    }

                    LoaGridView();
                    ClearControls();
                }
                if (rows > 0)
                {
                    MessageBox.Show("Insert Successfull!", "insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (SqlException)
            {
                MessageBox.Show("This Customet is ID Exists.Provide different Customer ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //  con.Close();
            }

        }
        }
}
