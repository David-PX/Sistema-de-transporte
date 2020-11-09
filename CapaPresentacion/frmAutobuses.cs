using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocios;

namespace CapaPresentacion
{
    public partial class frmAutobuses : Form
    {
        private string idcategorias;
        private bool Editarse = false;
        E_autobuses objEntidad = new E_autobuses();
        N_autobuses objNegocios = new N_autobuses();
        public frmAutobuses()
        {
            InitializeComponent();
        }

        private void frmAutobuses_Load(object sender, EventArgs e)
        {
            MostrarTabla("");
         
            objNegocios.listarChoferesEnCmb(comboBox1);
            
        }
        public void MostrarTabla(string buscar)
        {
            N_autobuses objNegocio = new N_autobuses();
          
             objNegocio.ListarChoferesYautobuses(buscar, tablaAutobuses);
        }

        private void bunifuTextbox5_OnTextChange(object sender, EventArgs e)
        {
            MostrarTabla(bunifuTextbox5.text);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editarse == false)
            {
                try
                {
                    objEntidad.IDCHOFER = Convert.ToInt32(comboBox1.SelectedValue);
                    objEntidad.MARCA = txtMarca.text;
                    objEntidad.MODELO = txtModelo.text;
                    objEntidad.PLACA = txtPlaca.text;
                    objEntidad.COLOR = txtColor.text;
                    objEntidad.ANO = txtAno.text;

                    objNegocios.InsertandoCategoria(objEntidad);

                    MessageBox.Show("Se guardo el registro");
                    MostrarTabla("");
                    limpiarCaja();
                }
                catch (Exception ez)
                {
                    MessageBox.Show("No se pudo guardar el registro" + ez);
                }
            }
            if (Editarse == true)
            {

                try
                {
                    objEntidad.ID = Convert.ToInt32(idcategorias);
                    objEntidad.IDCHOFER = Convert.ToInt32(comboBox1.SelectedValue);
                    objEntidad.MARCA = txtMarca.text;
                    objEntidad.MODELO = txtModelo.text;
                    objEntidad.PLACA = txtPlaca.text;
                    objEntidad.COLOR = txtColor.text;
                    objEntidad.ANO = txtAno.text;

                    objNegocios.EditandoCategoria(objEntidad);

                    MessageBox.Show("Se edito el registro");
                    MostrarTabla("");
                    limpiarCaja();
                    Editarse = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el registro" + ex);
                }

            }


        }
        private void limpiarCaja()
        {
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtPlaca.Text = "";
            txtColor.Text = "";
            txtAno.Text = "";
            txtMarca.Focus();
            Editarse = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarCaja();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tablaAutobuses.SelectedRows.Count > 0)
            {
                objEntidad.ID = Convert.ToInt32(tablaAutobuses.CurrentRow.Cells[0].Value.ToString());
                objNegocios.EliminandoCategoria(objEntidad);

                MessageBox.Show("Se elimino correctamente");
                MostrarTabla("");
                limpiarCaja();
            }
            else
            {
                MessageBox.Show("Seleccione la fila que quieres eliminar");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tablaAutobuses.SelectedRows.Count > 0)
            {
                Editarse = true;
                idcategorias = tablaAutobuses.CurrentRow.Cells[0].Value.ToString();
                comboBox1.Text = tablaAutobuses.CurrentRow.Cells[1].Value.ToString();
                txtMarca.text = tablaAutobuses.CurrentRow.Cells[2].Value.ToString();
                txtModelo.text = tablaAutobuses.CurrentRow.Cells[3].Value.ToString();
                txtPlaca.text = tablaAutobuses.CurrentRow.Cells[4].Value.ToString();
                txtColor.text = tablaAutobuses.CurrentRow.Cells[5].Value.ToString();
                txtAno.text = tablaAutobuses.CurrentRow.Cells[6].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar");
            }
        }
       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tablaAutobuses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
