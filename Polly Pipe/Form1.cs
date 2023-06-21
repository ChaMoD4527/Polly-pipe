using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Polly_Pipe
{
    public partial class Form1 : Form
    {
        private static string myConn = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }
        string username = "Admin";
        string password = "123";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text=="")
                {
                    textBox1.Text = "Enter Username";
                    return;
                }
                textBox1.ForeColor = Color.White;
                label4.Visible = false;
            }
            catch { }
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "")
                {
                    textBox2.Text = "Enter Password";
                    return;
                }
            }
            catch { }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.SelectAll();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.NavajoWhite;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == username && textBox2.Text == password)
            {
                DialogResult m2;
                m2 = MessageBox.Show("Login Successfull", "Access Valid", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                if (m2.ToString() == "OK")
                {
                    Form7 f7 = new Form7();
                    f7.Show();
                    this.Hide();
                }
            }
            else
            {
                DialogResult m3;
                m3 = MessageBox.Show("Invalid Login credintials,please check Username and Password", "Invalid Details",
                    MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (m3.ToString() == "Retry")
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }

        
}
