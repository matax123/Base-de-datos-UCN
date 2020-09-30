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
    public partial class Form7 : Form
    {
        ConexMySQL conex;
        DataTable dt;
        MySqlDataAdapter dataAdapter;
        string input;
        public Form7()
        {
            InitializeComponent();
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
                    conex = new ConexMySQL();
                    conex.open();
                    dt = new DataTable();
                    dataAdapter = new MySqlDataAdapter("SELECT * FROM curso c, estudiante e, estudiante_paralelo ep WHERE e.rut = "+textBox1.Text+" AND e.rut = ep.Estudianterut AND ep.ParaleloCursocódigo = c.código", conex.getConexion());
                    dataAdapter.Fill(dt);
                    input = dt.Rows[0][0].ToString();
                    dataAdapter = new MySqlDataAdapter("SELECT COUNT(*) FROM curso c, estudiante e, estudiante_paralelo ep WHERE e.rut = " + textBox1.Text + " AND e.rut = ep.Estudianterut AND ep.ParaleloCursocódigo = c.código", conex.getConexion());
                    dataAdapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conex.close();
                }
                catch
                {
                    MessageBox.Show("Hubo un error (no hay estudiante con ese rut o no tiene cursos tomados). Intente nuevamente.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("No pueden haber registros vacíos.");
            }
            else
            {
                try
                {
                    conex = new ConexMySQL();
                    conex.open();
                    dt = new DataTable();
                    dataAdapter = new MySqlDataAdapter("SELECT * FROM paralelo p, estudiante e, estudiante_paralelo ep WHERE p.id = "+textBox2.Text+" AND p.Cursocódigo = "+textBox3.Text+" AND e.rut = ep.Estudianterut AND p.id = ep.Paraleloid AND p.Cursocódigo = ep.ParaleloCursocódigo", conex.getConexion());
                    dataAdapter.Fill(dt);
                    input = dt.Rows[0][0].ToString();
                    dataAdapter = new MySqlDataAdapter("SELECT COUNT(*) FROM paralelo p, estudiante e, estudiante_paralelo ep WHERE p.id = " + textBox2.Text + " AND p.Cursocódigo = " + textBox3.Text + " AND e.rut = ep.Estudianterut AND p.id = ep.Paraleloid AND p.Cursocódigo = ep.ParaleloCursocódigo", conex.getConexion());
                    dataAdapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conex.close();
                }
                catch
                {
                    MessageBox.Show("Hubo un error (ese paralelo no existe o no hay estudiantes en ese paralelo). Intente nuevamente.");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("No pueden haber registros vacíos.");
            }
            else
            {
                try
                {
                    conex = new ConexMySQL();
                    conex.open();
                    dt = new DataTable();
                    dataAdapter = new MySqlDataAdapter("SELECT * FROM paralelo p, profesor pr WHERE pr.rut = "+textBox4.Text+" AND pr.rut = p.Profesorrut", conex.getConexion());
                    dataAdapter.Fill(dt);
                    input = dt.Rows[0][0].ToString();
                    dataAdapter = new MySqlDataAdapter("SELECT COUNT(*) FROM paralelo p, profesor pr WHERE pr.rut = "+textBox4.Text+" AND pr.rut = p.Profesorrut", conex.getConexion());
                    dataAdapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conex.close();
                }
                catch
                {
                    MessageBox.Show("Hubo un error (no existe un profesor con ese rut o no tiene paralelos asignados). Intente nuevamente.");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                MessageBox.Show("No pueden haber registros vacíos.");
            }
            else
            {
                try
                {
                    conex = new ConexMySQL();
                    conex.open();
                    dt = new DataTable();
                    dataAdapter = new MySqlDataAdapter("SELECT * FROM curso c WHERE c.código = "+textBox5.Text, conex.getConexion());
                    dataAdapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conex.close();
                }
                catch
                {
                    MessageBox.Show("Hubo un error. Intente nuevamente.");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                MessageBox.Show("No pueden haber registros vacíos.");
            }
            else
            {
                try
                {
                    conex = new ConexMySQL();
                    conex.open();
                    dt = new DataTable();
                    dataAdapter = new MySqlDataAdapter("SELECT * FROM estudiante e WHERE e.rut = " + textBox6.Text, conex.getConexion());
                    dataAdapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conex.close();
                }
                catch
                {
                    MessageBox.Show("Hubo un error (no hay estudiante con ese rut). Intente nuevamente.");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                MessageBox.Show("No pueden haber registros vacíos.");
            }
            else
            {
                try
                {
                    conex = new ConexMySQL();
                    conex.open();
                    dt = new DataTable();
                    dataAdapter = new MySqlDataAdapter("SELECT * FROM profesor pr WHERE pr.rut = " + textBox7.Text, conex.getConexion());
                    dataAdapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conex.close();
                }
                catch
                {
                    MessageBox.Show("Hubo un error. Intente nuevamente.");
                }
            }
        }

        private void button7_Click(object sender, EventArgs e) {
            try
            {
                conex = new ConexMySQL();
                conex.open();
                dt = new DataTable();
                dataAdapter = new MySqlDataAdapter("SELECT * FROM estudiante e WHERE Timestampdiff(year, e.fechaNacimiento, now()) < 18", conex.getConexion());
                dataAdapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conex.close();
            }
            catch
            {
                MessageBox.Show("Hubo un error. Intente nuevamente.");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("No pueden haber registros vacíos.");
            }
            else
            {
                try
                {
                    conex = new ConexMySQL();
                    conex.open();
                    dt = new DataTable();
                    dataAdapter = new MySqlDataAdapter("SELECT COUNT(*) FROM estudiante_paralelo ep WHERE ep.Paraleloid ="+textBox8.Text+" AND ep.ParaleloCursocódigo ="+textBox9.Text+" AND((DATE_FORMAT(ep.fechaInscripcion, '%H:%i') BETWEEN '08:00' AND '12:30') OR (DATE_FORMAT(ep.fechaInscripcion, '%H:%i') BETWEEN '14:30' AND '18:30'))", conex.getConexion());
                    dataAdapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conex.close();
                }
                catch
                {
                    MessageBox.Show("Hubo un error. Intente nuevamente.");
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                conex = new ConexMySQL();
                conex.open();
                dt = new DataTable();
                dataAdapter = new MySqlDataAdapter("SELECT * FROM profesor pr1 WHERE Timestampdiff(year, pr1.fechaContratacion, now()) = (SELECT max(Timestampdiff(year, pr2.fechaContratacion, now())) FROM profesor pr2)", conex.getConexion());
                dataAdapter.Fill(dt);
                dataAdapter = new MySqlDataAdapter("SELECT * FROM profesor pr1 WHERE Timestampdiff(year, pr1.fechaContratacion, now()) = (SELECT max(Timestampdiff(year, pr2.fechaContratacion, now())) FROM profesor pr2)", conex.getConexion());
                dataAdapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conex.close();
            }
            catch
            {
                MessageBox.Show("Hubo un error (no hay profesores). Intente nuevamente.");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                conex = new ConexMySQL();
                conex.open();
                dt = new DataTable();
                dataAdapter = new MySqlDataAdapter("SELECT * FROM estudiante e WHERE DATE_FORMAT(e.fechaIngreso, '%Y') BETWEEN '0000' AND '2016'", conex.getConexion());
                dataAdapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conex.close();
            }
            catch
            {
                MessageBox.Show("Hubo un error (no hay ningún estudiante en algún paralelo). Intente nuevamente.");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                conex = new ConexMySQL();
                conex.open();
                dt = new DataTable();
                dataAdapter = new MySqlDataAdapter("SELECT y.cantEstudiantes, y.cursoCod, y.nombreCurso FROM (SELECT COUNT(*) cantEstudiantes, ep.ParaleloCursocódigo cursoCod, c.nombre nombreCurso FROM estudiante_paralelo ep, Curso c WHERE c.código = ep.ParaleloCursocódigo GROUP BY ep.ParaleloCursocódigo) y WHERE y.cantEstudiantes = (SELECT MAX(z.maxEstudiantes) FROM(select count(*) maxEstudiantes FROM Estudiante_Paralelo ep1, Curso c1 WHERE c1.código = ep1.ParaleloCursocódigo GROUP BY ep1.ParaleloCursocódigo) z ); ", conex.getConexion());
                dataAdapter.Fill(dt);
                dataAdapter = new MySqlDataAdapter("SELECT y.cantEstudiantes, y.cursoCod, y.nombreCurso FROM (SELECT COUNT(*) cantEstudiantes, ep.ParaleloCursocódigo cursoCod, c.nombre nombreCurso FROM estudiante_paralelo ep, Curso c WHERE c.código = ep.ParaleloCursocódigo GROUP BY ep.ParaleloCursocódigo) y WHERE y.cantEstudiantes = (SELECT MIN(z.maxEstudiantes) FROM(select count(*) maxEstudiantes FROM Estudiante_Paralelo ep1, Curso c1 WHERE c1.código = ep1.ParaleloCursocódigo GROUP BY ep1.ParaleloCursocódigo) z ); ", conex.getConexion());
                dataAdapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conex.close();
            }
            catch
            {
                MessageBox.Show("Hubo un error. Intente nuevamente.");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                MessageBox.Show("No pueden haber registros vacíos.");
            }
            else
            {
                try
                {
                    conex = new ConexMySQL();
                    conex.open();
                    dt = new DataTable();
                    dataAdapter = new MySqlDataAdapter("SELECT SUM(x.bono) FROM(SELECT p.rut, pa.bono FROM profesor AS p , paralelo AS pa WHERE p.rut = pa.Profesorrut) AS x WHERE x.rut = "+textBox10.Text, conex.getConexion());
                    dataAdapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conex.close();
                }
                catch
                {
                    MessageBox.Show("Hubo un error. Intente nuevamente.");
                }
            }
        }
    }
}
