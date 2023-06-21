using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Configuration;
using System.Data;

namespace Polly_Pipe
{
    public partial class Form6 : Form
    {
        private static string myConn = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        string payId, payDate, PayType, srch;
        public Form6()
        {
            InitializeComponent();
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
            Form7 f7 = new Form7();
            f7.Show();
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {//cash

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {//paypal

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {//Bank Trnsfer

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {//visa & Master

        }

        private void LoadData()
        {
            payId = textBox2.Text;
            payDate = paymentDtPicker.Value.ToShortDateString();

        }

        private void ClearControls()
        {
            textBox2.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            LoaGridView();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                CheckBoxHandle();
                int rows;
                string UpdateQuery = "Update Table_5 set Payment_Date=@Payment_Date, Payment_Type=@Payment_Type where Payment_ID=@Payment_ID";
                using (SqlConnection con = new SqlConnection(myConn))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(UpdateQuery, con))
                    {
                        com.Parameters.AddWithValue("@Payment_ID", payId);
                        com.Parameters.AddWithValue("@Payment_Date", payDate);
                        com.Parameters.AddWithValue("@Payment_Type", PayType);
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

        }

        private void Pay(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                srch = textBox4.Text;
                DataTable datatable = new DataTable();
                string SearchQuery = "select * from Table_5 where Payment_ID=@Payment_ID";
                using (SqlConnection con = new SqlConnection(myConn))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(SearchQuery, con))
                    {
                        com.Parameters.AddWithValue("@Payment_ID", srch);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                        {
                            adapter.Fill(datatable);
                            dataGridView1.DataSource = datatable;
                        }
                    }

                }
            }
            catch (SqlException)
            {
                MessageBox.Show("This Payment is ID Exists.Provide different Payment ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //  con.Close();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        CheckBox lastChecked; 
        private void checkBox1_Click(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && lastChecked != null) lastChecked.Checked = false;
            lastChecked = activeCheckBox.Checked ? activeCheckBox : null;

        }

        private void checkBox4_Click(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && lastChecked != null) lastChecked.Checked = false;
            lastChecked = activeCheckBox.Checked ? activeCheckBox : null;
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && lastChecked != null) lastChecked.Checked = false;
            lastChecked = activeCheckBox.Checked ? activeCheckBox : null;
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            if (activeCheckBox != lastChecked && lastChecked != null) lastChecked.Checked = false;
            lastChecked = activeCheckBox.Checked ? activeCheckBox : null;
        }

        private void paymentDtPicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                CheckBoxHandle();
                string InsertQuery = "insert into Table_5 (Payment_ID,Payment_Date,Payment_Type)  values ( '" + payId + "', '" + payDate + "', '" + PayType + "')";

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
                string Getdata = "select * from Table_5";
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
        private void CheckBoxHandle()
        {
          
            if (checkBox1.Checked == true)
            {
                PayType = "cash";
            }
            else if (checkBox4.Checked == true)
            {
                PayType = "paypal";
            }
            else if (checkBox2.Checked == true)
            {
                PayType = "Bank Trnsfer";
            }
            else if (checkBox3.Checked == true)
            {
                PayType = "visa & Master";
            }
            else
            {
                PayType = null;
            }
        }
    }
}
