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
    public partial class frmViajes : Form
    {
        E_rutas objEntidad = new E_rutas();
        N_rutas objNegocios = new N_rutas();
        public frmViajes()
        {
            InitializeComponent();
        }

        private void frmViajes_Load(object sender, EventArgs e)
        {
            objNegocios.ListarTodos(tablaViajes);
        }
    }
}
