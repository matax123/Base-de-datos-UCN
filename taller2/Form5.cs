using MySql.Data.MySqlClient;
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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("No pueden haber registros vacíos.");
            }
            else
            {//se borrará al estudiante del paralelo
                try
                {
                    ConexMySQL conex = new ConexMySQL();
                    conex.open();
                    DataTable dt = new DataTable();
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT id, Cursocódigo FROM paralelo WHERE id=" + textBox4.Text + "AND Cursocódigo=" + textBox5.Text, conex.getConexion());
                    dataAdapter.Fill(dt);
                    string input = dt.Rows[0][0].ToString();
                    string input2 = dt.Rows[0][1].ToString();
                    conex.close();

                    if (input != textBox4.Text || input2 != textBox5.Text)
                    {
                        MessageBox.Show("Hubo un error (ese paralelo no existe). Intente nuevamente.");
                        return;
                    }

                    string query = "DELETE FROM estudiante_paralelo WHERE Estudianterut=@valor1 AND Paraleloid=@valor2 AND ParaleloCursocódigo=@valor3";

                    conex = new ConexMySQL();
                    conex.open();
                    MySqlCommand cmd = new MySqlCommand(query, conex.getConexion());

                    cmd.Parameters.AddWithValue("@valor1", textBox1.Text);
                    cmd.Parameters.AddWithValue("@valor2", textBox2.Text);
                    cmd.Parameters.AddWithValue("@valor3", textBox3.Text);

                    cmd.ExecuteNonQuery();
                    conex.close();

                    //se buscará el rutCoordinador del paralelo del que se borró el estudiante
                    conex = new ConexMySQL();
                    conex.open();
                    dt = new DataTable();
                    dataAdapter = new MySqlDataAdapter("SELECT rutCoordinador FROM paralelo WHERE id=" + textBox2.Text + " AND Cursocódigo=" + textBox3.Text + ";", conex.getConexion());
                    dataAdapter.Fill(dt);
                    input = dt.Rows[0][0].ToString();
                    conex.close();

                    if (input == textBox1.Text)//si el estudiante era el coordinador del curso, se borra su rutCoordinador de paralelo
                    {
                        query = "UPDATE paralelo SET rutCoordinador=@valor1 WHERE id=@valor2 AND Cursocódigo=@valor3";

                        conex = new ConexMySQL();
                        conex.open();
                        cmd = new MySqlCommand(query, conex.getConexion());

                        cmd.Parameters.AddWithValue("@valor1", null);
                        cmd.Parameters.AddWithValue("@valor2", textBox2.Text);
                        cmd.Parameters.AddWithValue("@valor3", textBox3.Text);

                        cmd.ExecuteNonQuery();
                        conex.close();

                    }
                    MessageBox.Show("Se borraron los datos.");
                }
                catch
                {
                    MessageBox.Show("Hubo un error (ese paralelo no existe o no hay estudiante con ese rut o el estudiante no está en ese paralelo). Intente nuevamente.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox5.Text == "")
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
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT id, Cursocódigo FROM paralelo WHERE id=" + textBox4.Text + "AND Cursocódigo=" + textBox5.Text, conex.getConexion());
                    dataAdapter.Fill(dt);
                    string input = dt.Rows[0][0].ToString();
                    string input2 = dt.Rows[0][1].ToString();
                    conex.close();

                    if (input != textBox4.Text || input2 != textBox5.Text)
                    {
                        MessageBox.Show("Hubo un error (ese paralelo no existe). Intente nuevamente.");
                        return;
                    }

                    string query = "DELETE FROM estudiante_paralelo WHERE Paraleloid=@valor1 AND ParaleloCursocódigo=@valor2";

                    conex = new ConexMySQL();
                    conex.open();
                    MySqlCommand cmd = new MySqlCommand(query, conex.getConexion());

                    cmd.Parameters.AddWithValue("@valor1", textBox4.Text);
                    cmd.Parameters.AddWithValue("@valor2", textBox5.Text);

                    cmd.ExecuteNonQuery();
                    conex.close();

                    query = "DELETE FROM paralelo WHERE id=@valor1 AND Cursocódigo=@valor2";

                    conex = new ConexMySQL();
                    conex.open();
                    cmd = new MySqlCommand(query, conex.getConexion());

                    cmd.Parameters.AddWithValue("@valor1", textBox4.Text);
                    cmd.Parameters.AddWithValue("@valor2", textBox5.Text);

                    cmd.ExecuteNonQuery();
                    conex.close();

                    MessageBox.Show("Se borraron los datos.");
                }
                catch
                {
                    MessageBox.Show("Hubo un error (el paralelo no existe). Intente nuevamente.");
                }
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
