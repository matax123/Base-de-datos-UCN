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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
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
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT rut FROM estudiante WHERE rut=" + textBox1.Text, conex.getConexion());
                    dataAdapter.Fill(dt);
                    string input = dt.Rows[0][0].ToString();
                    conex.close();
                    if (input == textBox1.Text)//si el estudiante con ese rut existe
                    {
                        conex = new ConexMySQL();
                        conex.open();
                        dt = new DataTable();
                        dataAdapter = new MySqlDataAdapter("SELECT Estudianterut FROM estudiante_paralelo WHERE Estudianterut="+textBox1.Text+"Paraleloid=" + textBox2.Text+" AND ParaleloCursocódigo="+textBox5.Text, conex.getConexion());
                        dataAdapter.Fill(dt);
                        input = dt.Rows[0][0].ToString();
                        conex.close();
                        if (input == textBox1.Text)//si el estudiante está inscrito en el paralelo actual
                        {
                            conex = new ConexMySQL();
                            conex.open();
                            dt = new DataTable();
                            dataAdapter = new MySqlDataAdapter("SELECT Estudianterut FROM estudiante_paralelo WHERE Estudianterut=" + textBox1.Text + "Paraleloid=" + textBox2.Text + " AND ParaleloCursocódigo=" + textBox5.Text, conex.getConexion());
                            dataAdapter.Fill(dt);
                            input = dt.Rows[0][0].ToString();
                            conex.close();
                            if (input == "")//si el estudiante no está inscrito en el paralelo nuevo
                            {
                                string query = "DELETE FROM estudiante_paralelo WHERE Estudianterut=@valor1 AND Paraleloid=@valor2 AND ParaleloCursocódigo=@valor3";

                                conex = new ConexMySQL();
                                conex.open();
                                MySqlCommand cmd = new MySqlCommand(query, conex.getConexion());

                                cmd.Parameters.AddWithValue("@valor1", textBox1.Text);
                                cmd.Parameters.AddWithValue("@valor2", textBox2.Text);
                                cmd.Parameters.AddWithValue("@valor3", textBox5.Text);

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
                                    cmd.Parameters.AddWithValue("@valor3", textBox5.Text);

                                    cmd.ExecuteNonQuery();
                                    conex.close();

                                }
                                //se agregará el estudiante al paralelo nuevo
                                query = "INSERT INTO estudiante_paralelo(Estudianterut,Paraleloid,ParaleloCursocódigo,fechaInscripcion)VALUES(@valor1,@valor2,@valor3,@valor4)";

                                conex = new ConexMySQL();
                                conex.open();
                                cmd = new MySqlCommand(query, conex.getConexion());

                                cmd.Parameters.AddWithValue("@valor1", textBox1.Text);
                                cmd.Parameters.AddWithValue("@valor2", textBox3.Text);
                                cmd.Parameters.AddWithValue("@valor3", textBox5.Text);
                                cmd.Parameters.AddWithValue("@valor4", DateTime.Now);

                                cmd.ExecuteNonQuery();
                                conex.close();
                                MessageBox.Show("Se cambiaron los datos.");
                            }
                            else
                            {
                                MessageBox.Show("El estudiante está inscrito en ese paralelo nuevo.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("El estudiante no está inscrito en ese paralelo actual.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay estudiante con ese rut.");
                    }
                }
                catch
                {
                    MessageBox.Show("Hubo un error (paralelo nuevo o paralelo actual no existen). Intente nuevamente.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
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
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT id, Cursocódigo FROM paralelo WHERE id=" + textBox5.Text + " AND Cursocódigo = " + textBox6.Text, conex.getConexion());
                    dataAdapter.Fill(dt);
                    string input = dt.Rows[0][0].ToString();
                    string input2 = dt.Rows[0][1].ToString();
                    conex.close();
                    if (input == textBox5.Text & input2 == textBox6.Text)
                    {
                        string query = "UPDATE paralelo SET Profesorrut=@valor1 WHERE id=@valor2 AND Cursocódigo=@valor3";

                        conex = new ConexMySQL();
                        conex.open();
                        MySqlCommand cmd = new MySqlCommand(query, conex.getConexion());

                        cmd.Parameters.AddWithValue("@valor1", textBox7.Text);
                        cmd.Parameters.AddWithValue("@valor2", textBox5.Text);
                        cmd.Parameters.AddWithValue("@valor3", textBox6.Text);

                        cmd.ExecuteNonQuery();
                        conex.close();
                        MessageBox.Show("Se cambiaron los datos.");
                    }
                }
                catch
                {
                    MessageBox.Show("Hubo un error (ese paralelo no existe o ese profesor no existe). Intente nuevamente.");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "")
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
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter("SELECT id, Cursocódigo FROM paralelo WHERE id=" + textBox8.Text + " AND Cursocódigo = " + textBox9.Text, conex.getConexion());
                    dataAdapter.Fill(dt);
                    string input = dt.Rows[0][0].ToString();
                    string input2 = dt.Rows[0][1].ToString();
                    conex.close();
                    if (input == textBox8.Text & input2 == textBox9.Text)
                    {
                        string query = "UPDATE paralelo SET bono=@valor1 WHERE id=@valor2 AND Cursocódigo=@valor3";

                        conex = new ConexMySQL();
                        conex.open();
                        MySqlCommand cmd = new MySqlCommand(query, conex.getConexion());

                        cmd.Parameters.AddWithValue("@valor1", textBox10.Text);
                        cmd.Parameters.AddWithValue("@valor2", textBox8.Text);
                        cmd.Parameters.AddWithValue("@valor3", textBox9.Text);

                        cmd.ExecuteNonQuery();
                        conex.close();
                        MessageBox.Show("Se cambiaron los datos.");
                    }
                }
                catch
                {
                    MessageBox.Show("Hubo un error (el paralelo no existe). Intente nuevamente.");
                }
            }
        }
    }
}
