using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Modes.Gcm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace taller2
{
    public partial class Form4 : Form
    {
        private string t1;
        private string t2;
        public Form4(string t1, string t2)
        {
            InitializeComponent();
            this.t1 = t1;
            this.t2 = t2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("No pueden haber registros vacíos.");
            }
            else
            {
                try
                {
                    string query = "INSERT INTO estudiante_paralelo(Estudianterut,Paraleloid,ParaleloCursocódigo,fechaInscripcion)VALUES(@valor1,@valor2,@valor3,@valor4)";

                    ConexMySQL conex = new ConexMySQL();
                    conex.open();
                    MySqlCommand cmd = new MySqlCommand(query, conex.getConexion());

                    cmd.Parameters.AddWithValue("@valor1", textBox1.Text);
                    cmd.Parameters.AddWithValue("@valor2", t1);
                    cmd.Parameters.AddWithValue("@valor3", t2);
                    cmd.Parameters.AddWithValue("@valor4", DateTime.Now);

                    cmd.ExecuteNonQuery();
                    conex.close();

                    MessageBox.Show("Se ingresaron los datos.");
                }
                catch
                {
                    MessageBox.Show("Hubo un error (el estudiante no existe). Intente nuevamente.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
