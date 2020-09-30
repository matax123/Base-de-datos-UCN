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
    public partial class Form3 : Form
    {
        private MySqlDataAdapter adapt;
        public Form3()
        {
            InitializeComponent();
        }

        private void MostrarDatos(string tabla)
        {
            ConexMySQL conex = new ConexMySQL();
            conex.open();
            DataTable dt = new DataTable();
            adapt = new MySqlDataAdapter("SELECT * FROM " + tabla + ";", conex.getConexion());
            adapt.Fill(dt);
            DataGrid.DataSource = dt;
            conex.close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MostrarDatos("curso");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MostrarDatos("profesor");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MostrarDatos("estudiante");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MostrarDatos("paralelo");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MostrarDatos("estudiante_paralelo");
        }
    }
}
