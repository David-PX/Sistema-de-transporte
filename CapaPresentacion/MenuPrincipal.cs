using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            

        }
        public void PantallaOk()
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void central_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            PantallaOk();
        }

        private void salir_Click(object sender, EventArgs e)
        {
            const string message =
        "Estas seguro que deseas cerrar el formulario";
            const string caption = "Cerrar Formulario";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmViajes());
        }

        private void sidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private Form formActivado = null;

        private void AbrirFormulario(Form formHijo)
        {
            if (formActivado != null)
                formActivado.Close();
            formActivado = formHijo;
            formHijo.TopLevel = false;
            formHijo.Dock = DockStyle.Fill;
            central.Controls.Add(formHijo);
            central.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();


            
        }

        private void btnChoferes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmChoferes());
        }

        private void btnAutobuses_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmAutobuses());
        }

        private void btnRutas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmRutas());
        }
    }
}
