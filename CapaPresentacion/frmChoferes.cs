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
    public partial class frmChoferes : Form
    {
        private string ID;
        private bool Editarse = false;
        E_choferes objEntidad = new E_choferes();
        N_choferes objNegocios = new N_choferes();
        public frmChoferes()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmChoferes_Load(object sender, EventArgs e)
        {
            MostrarTabla("");
            tablaChoferes.ClearSelection();
        }
        public void MostrarTabla(string buscar)
        {
            N_choferes objNegocio = new N_choferes();
            tablaChoferes.DataSource = objNegocio.ListarCategoria(buscar);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextbox5_OnTextChange(object sender, EventArgs e)
        {
            MostrarTabla(bunifuTextbox5.text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarCaja();
        }

        public void limpiarCaja()
        {
            txtName.text = "";
            txtApellido.text = "";
            txtCedula.text = "";
            txtFecha.text = "";
            txtName.Focus();
            Editarse = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editarse == false)
            {
                try
                {
                    objEntidad.NOMBRE = txtName.text;
                    objEntidad.APELLIDO = txtApellido.text;
                    objEntidad.CEDULA = txtCedula.text;
                    objEntidad.FECHA_NACIMIENTO = Convert.ToDateTime(txtFecha.text);

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
                    objEntidad.ID = Convert.ToInt32(ID);
                    objEntidad.NOMBRE = txtName.text;
                    objEntidad.APELLIDO = txtApellido.text;
                    objEntidad.CEDULA = txtCedula.text;
                    objEntidad.FECHA_NACIMIENTO = Convert.ToDateTime(txtFecha.text);

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tablaChoferes.SelectedRows.Count > 0)
            {
                objEntidad.ID = Convert.ToInt32(tablaChoferes.CurrentRow.Cells[0].Value.ToString());
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
            if (tablaChoferes.SelectedRows.Count > 0)
            {
                Editarse = true;
                ID = tablaChoferes.CurrentRow.Cells[0].Value.ToString();
                txtName.text = tablaChoferes.CurrentRow.Cells[1].Value.ToString();
                txtApellido.text = tablaChoferes.CurrentRow.Cells[2].Value.ToString();
                txtCedula.text = tablaChoferes.CurrentRow.Cells[3].Value.ToString();
                txtFecha.text = tablaChoferes.CurrentRow.Cells[4].Value.ToString();

            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar");
            }
        }
    }
}
