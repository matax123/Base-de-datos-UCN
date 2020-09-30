using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1;

namespace taller2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//agrega un estudiante a un paralelo
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
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
                    cmd.Parameters.AddWithValue("@valor2", textBox2.Text);
                    cmd.Parameters.AddWithValue("@valor3", textBox3.Text);
                    cmd.Parameters.AddWithValue("@valor4", DateTime.Now);

                    cmd.ExecuteNonQuery();
                    conex.close();

                    MessageBox.Show("Se ingresaron los datos.");
                }
                catch
                {
                    MessageBox.Show("Hubo un error (no hay estudiante con ese rut o no existe ese paralelo). Intente nuevamente.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("No pueden haber registros vacíos.");
            }
            else
            {
                try
                {
                    ConexMySQL conex = new ConexMySQL();
                    conex.open();
                    DataTable dt = new DataTable();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT rut FROM estudiante WHERE rut="+textBox6.Text, conex.getConexion());
                    dataAdapter.Fill(dt);
                    string input = dt.Rows[0][0].ToString();
                    conex.close();

                    if(input != textBox6.Text)
                    {
                        MessageBox.Show("Hubo un error (el estudiante no existe). Intente nuevamente.");
                        return;
                    }

                    conex = new ConexMySQL();
                    conex.open();
                    dt = new DataTable();
                    dataAdapter = new MySqlDataAdapter("SELECT id, Cursocódigo FROM paralelo WHERE id=" + textBox4.Text + "AND Cursocódigo="+textBox5.Text, conex.getConexion());
                    dataAdapter.Fill(dt);
                    input = dt.Rows[0][0].ToString();
                    string input2 = dt.Rows[0][1].ToString();
                    conex.close();

                    if (input != textBox4.Text || input2 != textBox5.Text)
                    {
                        MessageBox.Show("Hubo un error (ese paralelo no existe). Intente nuevamente.");
                        return;
                    }

                    string query = "UPDATE paralelo SET rutCoordinador=@valor1 WHERE id=@valor2 AND Cursocódigo=@valor3";

                    conex = new ConexMySQL();
                    conex.open();
                    MySqlCommand cmd = new MySqlCommand(query, conex.getConexion());

                    cmd.Parameters.AddWithValue("@valor1", textBox6.Text);
                    cmd.Parameters.AddWithValue("@valor2", textBox4.Text);
                    cmd.Parameters.AddWithValue("@valor3", textBox5.Text);

                    cmd.ExecuteNonQuery();
                    conex.close();

                    MessageBox.Show("Se ingresó el dato.");
                }
                catch
                {
                    MessageBox.Show("Hubo un error (no existe ese paralelo o no hay estudiante con ese rut). Intente nuevamente.");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "")
            {
                MessageBox.Show("No pueden haber registros vacíos.");
            }
            else
            {
                try
                {
                    string query = "INSERT INTO paralelo(id,Cursocódigo,ProfesorRut,bono)VALUES(@valor1,@valor2,@valor3,@valor4)";

                    ConexMySQL conex = new ConexMySQL();
                    conex.open();
                    MySqlCommand cmd = new MySqlCommand(query, conex.getConexion());

                    cmd.Parameters.AddWithValue("@valor1", textBox7.Text);
                    cmd.Parameters.AddWithValue("@valor2", textBox8.Text);
                    cmd.Parameters.AddWithValue("@valor3", textBox9.Text);
                    cmd.Parameters.AddWithValue("@valor4", textBox10.Text);
                    cmd.Parameters.AddWithValue("@valor5", null);

                    cmd.ExecuteNonQuery();
                    conex.close();

                    MessageBox.Show("Se ingresaron los datos.");
                    Form4 f4 = new Form4(textBox7.Text,textBox8.Text);
                    f4.Show();
                }
                catch
                {
                    MessageBox.Show("Hubo un error (no hay un curso curso con ese código o no hay un profesor con ese rut). Intente nuevamente.");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "")
            {
                MessageBox.Show("No pueden haber registros vacíos.");
            }
            else
            {
                try
                {
                    string query = "INSERT INTO estudiante(rut,nombre,fechaIngreso,fechaNacimiento) VALUES(@valor1,@valor2,@valor3,@valor4)";

                    ConexMySQL conex = new ConexMySQL();
                    conex.open();
                    MySqlCommand cmd = new MySqlCommand(query, conex.getConexion());

                    cmd.Parameters.AddWithValue("@valor1", textBox11.Text);
                    cmd.Parameters.AddWithValue("@valor2", textBox12.Text);
                    cmd.Parameters.AddWithValue("@valor3", DateTime.Now);
                    cmd.Parameters.AddWithValue("@valor4", textBox13.Text);

                    cmd.ExecuteNonQuery();
                    conex.close();

                    MessageBox.Show("Se ingresaron los datos.");
                }
                catch
                {
                    MessageBox.Show("Hubo un error (el estudiante ya existe). Intente nuevamente.");
                }
            }
        }
    }
}
