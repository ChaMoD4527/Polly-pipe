using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Polly_Pipe
{
    public partial class Form5 : Form
    {
        private static string myConn = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        string insId, InsType, StartDate , endDate, Address, srch;
        public Form5()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                string DeleteQuery = "Delete from Table_4 where ins_id=@ins_id";
                int rows;
                using (SqlConnection con = new SqlConnection(myConn))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(DeleteQuery, con))
                    {
                        com.Parameters.AddWithValue("@ins_id", insId);
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                if (textBox2.Text == "")
                {
                    MessageBox.Show("Ins ID cannot be empty!");
                }

                int rows;
                // insId, InsType, StartDate , endDate, Address
                string UpdateQuery = "Update Table_4 set Ins_Type=@Ins_Type, Start_date=@Start_date, end_date=@end_date,Address=@Address where ins_id=@ins_id";
                using (SqlConnection con = new SqlConnection(myConn))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(UpdateQuery, con))
                    {
                        com.Parameters.AddWithValue("@ins_id", insId);
                        com.Parameters.AddWithValue("@Ins_Type", InsType);
                        com.Parameters.AddWithValue("@Start_date", StartDate);
                        com.Parameters.AddWithValue("@end_date", endDate);
                        com.Parameters.AddWithValue("@Address", Address);
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

        private void button7_Click(object sender, EventArgs e)
        {
            srch = searchTxt.Text;
            DataTable datatable = new DataTable();
            string SearchQuery = "select * from Table_4 where ins_id=@ins_id";
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(SearchQuery, con))
                {
                    com.Parameters.AddWithValue("@ins_id", srch);
                    //com.Parameters.AddWithValue("@Srch", srch);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                        dataGridView1.DataSource = datatable;
                    }
                }

            }
        }

        private void LoaGridView()
        {
            try
            {
                LoadData();
                string Getdata = "select * from Table_4";
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
        private void LoadData()
        {
            insId = textBox2.Text;
            InsType = textBox3.Text;
            StartDate = textBox4.Text;
            endDate = textBox5.Text;
            Address = textBox6.Text;
        }

        private void ClearControls()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
        private void LoadGridView()
        {
            try
            {
                LoadData();
                string Getdata = "select * from Table_4";
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
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                string InsertQuery = "insert into Table_4 (ins_id,Ins_Type,Start_date,end_date,Address)  values ( '" + insId + "', '" + InsType + "', '" + StartDate + "', '" + endDate + "', '" + Address + "')";

                int rows;
                using (SqlConnection con = new SqlConnection(myConn))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(InsertQuery, con))
                    {

                        rows = com.ExecuteNonQuery();
                    }

                   // LoaGridView();
                    ClearControls();
                }
                if (rows > 0)
                {
                    MessageBox.Show("Insert Successfull!", "insert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (SqlException)
            {
                MessageBox.Show("This Installation is ID Exists.Provide different Installation ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //  con.Close();
            }
        }
    }
}
