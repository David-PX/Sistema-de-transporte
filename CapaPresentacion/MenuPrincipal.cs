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
    }
}
