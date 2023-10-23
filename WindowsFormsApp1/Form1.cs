using Microsoft.Reporting.WinForms; // Para acceder a las clases relacionadas con el control ReportViewer.
using System;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private static int key = 0;
        private ClasePruebas clsPrueba = new ClasePruebas();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listar();
        }
        private void listar()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = clsPrueba.listar();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Tb_Prueba objregistro = new Tb_Prueba();
            objregistro.nombre = txtnombre.Text;
            objregistro.apellido = txtapellido.Text;
            objregistro.dni = txtdni.Text;
            clsPrueba.registrar(objregistro);
            limpiar();
            MessageBox.Show("registro realizado");
            listar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            txtnombre.Text = String.Empty;
            txtapellido.Text = String.Empty;
            txtdni.Text = String.Empty;
            key = 0;
        }

        private void obtener(int key)
        {
            Tb_Prueba objeto = clsPrueba.obtener(key);
            txtnombre.Text = objeto.nombre;
            txtapellido.Text = objeto.apellido;
            txtdni.Text = objeto.dni;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index == e.RowIndex)
                {
                    key = int.Parse(row.Cells[0].Value.ToString());
                    obtener(key);
                }
            }
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            if (key != 0)
            {
                Tb_Prueba objregistro = new Tb_Prueba();
                objregistro.idPrueba = key;
                objregistro.nombre = txtnombre.Text;
                objregistro.apellido = txtapellido.Text;
                objregistro.dni = txtdni.Text;
                clsPrueba.actualizar(objregistro);
                limpiar();
                MessageBox.Show("registro actualizado");
                listar();
            }

        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (key != 0)
            {
                clsPrueba.eliminar(key);
                limpiar();
                MessageBox.Show("registro eliminado");
                listar();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 rpt = new Form2();
            rpt.ShowDialog();
        }
    }
}
