using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polly_Pipe
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            {
                Form2 f2 = new Form2();
                f2.Show();
                this.Hide();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            {
                Form3 f3 = new Form3();
                f3.Show();
                this.Hide();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                Form4 f4 = new Form4();
                f4.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                Form5 f5 = new Form5();
                f5.Show();
                this.Hide();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            {
                Form6 f6 = new Form6();
                f6.Show();
                this.Hide();
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
    }
}
