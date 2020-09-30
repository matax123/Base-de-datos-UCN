using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1;

namespace taller2
{
    public partial class Form1 : Form //clase principal
    {
        private Boolean soyAdmin = false;
        Form8 f8 = new Form8();
        private MySqlDataAdapter adapt;
        public Form1()
        {
            InitializeComponent(); //abre la ventana
        }
        public void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            soyAdmin = f8.soyAdmin;
            f8.formAsignado = 2;
            if (soyAdmin)
            {
                Form2 f2 = new Form2();
                f2.Show();
            }
            else
            {
                f8.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            soyAdmin = f8.soyAdmin;
            f8.formAsignado = 5;
            if (soyAdmin)
            {
                Form5 f5 = new Form5();
                f5.Show();
            }
            else
            {
                f8.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            soyAdmin = f8.soyAdmin;
            f8.formAsignado = 6;
            if (soyAdmin)
            {
                Form6 f6 = new Form6();
                f6.Show();
            }
            else
            {
                f8.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.Show();
        }
    }
}
