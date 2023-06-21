using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Polly_Pipe
{
    public partial class Form4 : Form
    {
        private static string myConn = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        string eqid, name, sort, price, Quantity, srch;
        public Form4()
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
                    MessageBox.Show("Equ ID cannot be empty!");
                }

                int rows;
                string UpdateQuery = "Update Table_3 set Name=@Name, sort=@sort, price=@price,Quantity=@Quantity where Equ_id=@Equ_id";
                using (SqlConnection con = new SqlConnection(myConn))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(UpdateQuery, con))
                    {
                        com.Parameters.AddWithValue("@Equ_id", eqid);
                        com.Parameters.AddWithValue("@Name", name);
                        com.Parameters.AddWithValue("@sort", sort);
                        com.Parameters.AddWithValue("@price", price);
                        com.Parameters.AddWithValue("@Quantity", Quantity);
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

        private void LoadData()
        {
            eqid = textBox2.Text;
            name = textBox3.Text;
            sort = textBox4.Text;
            price = textBox5.Text;
            Quantity = textBox6.Text;
        }

        private void ClearControls()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                string DeleteQuery = "Delete from Table_3 where Equ_id=@Equ_id";
                int rows;
                using (SqlConnection con = new SqlConnection(myConn))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(DeleteQuery, con))
                    {
                        com.Parameters.AddWithValue("@Equ_id", eqid);
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
        {//textBox7
            srch = searchTxt.Text;
            DataTable datatable = new DataTable();
            string SearchQuery = "select * from Table_3 where Equ_ID=@Equ_ID";
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(SearchQuery, con))
                {
                    com.Parameters.AddWithValue("@Equ_ID", srch);
                    //com.Parameters.AddWithValue("@Srch", srch);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                        dataGridView1.DataSource = datatable;
                    }
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Hide();

        }
        private void LoaGridView()
        {
            try
            {
                LoadData();
                string Getdata = "select * from Table_3";
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
            this.Hide();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Equ ID cannot be empty!");
                }


                string InsertQuery = "insert into Table_3 (Equ_id,Name,sort,price,Quantity)  values ( '" + eqid + "', '" + name + "', '" + sort + "', '" + price + "', '" + Quantity + "')";

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
