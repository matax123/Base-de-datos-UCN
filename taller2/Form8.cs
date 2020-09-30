using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taller2
{
    public partial class Form8 : Form
    {
        public Boolean soyAdmin = false;
        public int formAsignado = 0;
        public Form8()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin")
            {
                soyAdmin = true;
                MessageBox.Show("Ahora eres admin.");
                if(formAsignado == 2)
                {
                    Form2 f2 = new Form2();
                    f2.Show();
                }
                else if(formAsignado == 5)
                {
                    Form5 f5 = new Form5();
                    f5.Show();
                }
                else
                {
                    Form6 f6 = new Form6();
                    f6.Show();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
