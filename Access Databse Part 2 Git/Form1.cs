using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Access_Databse_Part_2_Git
{
    public partial class Form1 : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\joela\OneDrive\Documentos\Access Databse Part 2 Git\DbPersona.accdb");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeComponent();
        }
        void LlenarGrid()
        {
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("select * from TablaPersona by Id", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("Insert into TablaPersona(Nombre, Edad)values('" + textBox2.Text + "'," + textBox3.Text + ")", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Registro exitosamente guardado.");
            //Limpiar texto
            LimpiarTexto();
            LlenarGrid();
        }
        void LimpiarTexto()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("update TablePersona set Nombre='+" + textBox2.Text + "', Edad=" + textBox3.Text + " where Id=" + textBox1.Text + " ", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Registro actualizado.");
            LimpiarTexto();
            LlenarGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("delete from TablePersona where Id=" + textBox1.Text + " ", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Registro eliminado.");
            LimpiarTexto();
            LlenarGrid();
        }
    }
}
