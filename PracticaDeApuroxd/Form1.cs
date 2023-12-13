using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace PracticaDeApuroxd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Conexion SQL
            Conexion.Conectar();
            MessageBox.Show("esto es una prueba de github");

            dataGridView1.DataSource = llenar_grid();
        }

        public DataTable llenar_grid()
        {
            //Llamar a la tabla de SQL
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from ALUMNO";
            SqlCommand cmd = new SqlCommand(consulta,Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Insertar Valores a la tabla ALUMNO
            Conexion.Conectar();
            string insertar = "INSERT INTO ALUMNO (CODIGO,NOMBRES,APELLIDOS,DIRECCION)VALUES(@CODIGO,@NOMBRES,@APELLIDOS,@DIRECCION)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conectar());
            cmd1.Parameters.AddWithValue("@CODIGO",txtCodigo.Text);
            cmd1.Parameters.AddWithValue("@NOMBRES",txtNombre.Text);
            cmd1.Parameters.AddWithValue("@APELLIDOS",txtApellido.Text);
            cmd1.Parameters.AddWithValue("@DIRECCION",txtDireccion.Text);
            
            cmd1.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron agregados con exito");

            //llena el grid 
            dataGridView1.DataSource = llenar_grid();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //LLamo los datos hacia el caja de txt para poder hacer una modificacion
            try
            {
                txtCodigo.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtDireccion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //APLICAMOS LAS MODIFICACIONES
            Conexion.Conectar();
            string actualizar = "UPDATE ALUMNO SET CODIGO=@CODIGO, NOMBRES=@NOMBRES, APELLIDOS=@APELLIDOS, DIRECCION=@DIRECCION";
            SqlCommand cmd2 = new SqlCommand(actualizar,Conexion.Conectar());
            cmd2.Parameters.AddWithValue("@CODIGO", txtCodigo.Text);
            cmd2.Parameters.AddWithValue("@NOMBRES", txtNombre.Text);
            cmd2.Parameters.AddWithValue("@APELLIDOS", txtApellido.Text);
            cmd2.Parameters.AddWithValue("@DIRECCION", txtDireccion.Text);

            cmd2.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron actualizados con exito");

            dataGridView1.DataSource = llenar_grid();
        }
    }
}
