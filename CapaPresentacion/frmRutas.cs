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

    public partial class frmRutas : Form
    {
        private string idcategorias;
        private bool Editarse = false;
        E_rutas objEntidad = new E_rutas();
        N_rutas objNegocios = new N_rutas();
        public frmRutas()
        {
            InitializeComponent();
        }

        private void frmRutas_Load(object sender, EventArgs e)
        {
            MostrarTabla("");
            objNegocios.listarAutobusesEnCmb(comboBox1);
        }

        public void MostrarTabla(string buscar)
        {
            N_rutas objNegocio = new N_rutas();
            objNegocios.ListarRutasYautobuses(buscar, tablaRutas);
        }

        private void bunifuTextbox5_OnTextChange(object sender, EventArgs e)
        {
            MostrarTabla(bunifuTextbox5.text);
        }

        public void limpiarCaja()
        {
            txtNombre.text = "";
            Editarse = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editarse == false)
            {
                try
                {
                    objEntidad.IDAUTOBUS = Convert.ToInt32(comboBox1.SelectedValue);
                    objEntidad.NOMBRE = txtNombre.text;
                  

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
                    objEntidad.IDAUTOBUS = Convert.ToInt32(comboBox1.SelectedValue);
                    objEntidad.NOMBRE = txtNombre.text.ToString();
                   

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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarCaja();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tablaRutas.SelectedRows.Count > 0)
            {
                objEntidad.ID = Convert.ToInt32(tablaRutas.CurrentRow.Cells[0].Value.ToString());
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
            if (tablaRutas.SelectedRows.Count > 0)
            {
                Editarse = true;
                idcategorias = tablaRutas.CurrentRow.Cells[0].Value.ToString();
                comboBox1.Text = tablaRutas.CurrentRow.Cells[2].Value.ToString();
                txtNombre.text = tablaRutas.CurrentRow.Cells[3].Value.ToString();
              
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar");
            }
        }
    }
}
