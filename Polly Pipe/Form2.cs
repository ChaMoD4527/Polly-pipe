using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Polly_Pipe
{
    public partial class Form2 : Form
    {
   
        private static string myConn = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        string cid, name, email, gender, cn, srch;
        public Form2()
        {
            InitializeComponent();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();

                if (textBox2.Text == "")
                {
                    MessageBox.Show("Customer ID cannot be empty!");
                }
                int rows;
                string UpdateQuery = "Update Table_1 set Name=@Name, Email=@Email, Gender=@Gender,C_Num=@C_Num where Cus_ID=@Cus_ID";
                using (SqlConnection con = new SqlConnection(myConn))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(UpdateQuery, con))
                    {
                        com.Parameters.AddWithValue("@Cus_ID", cid);
                        com.Parameters.AddWithValue("@Name", name);
                        com.Parameters.AddWithValue("@Email", email);
                        com.Parameters.AddWithValue("@Gender", gender);
                        com.Parameters.AddWithValue("@C_Num", cn);
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
            //button3.ForeColor = Color.DarkRed;
        }

        private void LoadData()
        {
            cid = textBox2.Text;

            name = textBox3.Text;
            email = textBox4.Text;
         //   gender = textBox5.Text;
            cn = textBox6.Text;
            if (radioButton1.Checked)
            {
                gender = radioButton1.Text;
            }

            if (radioButton2.Checked)
            {
                gender = radioButton2.Text;
            }
        }

        private void ClearControls()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            // textBox5.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox6.Text = "";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();

                if (textBox2.Text == "")
                {
                    MessageBox.Show("Customer ID cannot be empty!");
                }

                string InsertQuery = "insert into Table_1 (Cus_ID,Name,Email,Gender,C_Num)  values ( '" + cid + "', '" + name + "', '" + email + "', '" + gender + "', '" + cn + "')";

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

        private void LoaGridView()
        {
            try
            {
                LoadData();
                string Getdata = "select * from Table_1";
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

        private void button1_Click(object sender, EventArgs e)
        {
           // button1.ForeColor = Color.DarkRed;
            srch = searchTxt.Text;
            DataTable datatable = new DataTable();
            string SearchQuery = "select * from Table_1 where Cus_ID=@Cus_ID";
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(SearchQuery, con))
                {
                    com.Parameters.AddWithValue("@Cus_ID", srch);
                    //com.Parameters.AddWithValue("@Srch", srch);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                        dataGridView1.DataSource = datatable;
                    }
                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                string DeleteQuery = "Delete from Table_1 where Cus_ID=@Cus_ID";
                int rows;
                using (SqlConnection con = new SqlConnection(myConn))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(DeleteQuery, con))
                    {
                        com.Parameters.AddWithValue("@Cus_ID", cid);
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
            //button6.ForeColor = Color.DarkRed;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoaGridView();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
            this.Hide();


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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
