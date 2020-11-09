using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
using System.Windows.Forms;
using System.Data;

namespace CapaNegocios
{
    public class N_autobuses
    {
        D_autobuses objDato = new D_autobuses();
        E_choferes chofer = new E_choferes();
        public List<E_autobuses> ListarCategoria(string buscar)
        {
            return objDato.ListarChoferes(buscar);
        }

        public void ListarChoferesYautobuses(string like, DataGridView data)
        {
            data.DataSource = objDato.ListarAutobusesYchoferes(like);
            
        }
        public void InsertandoCategoria(E_autobuses choferes)
        {
            objDato.insertarChofer(choferes);
        }
        public void EditandoCategoria(E_autobuses choferes)
        {
            objDato.EditarChofer(choferes);

        }
        public void EliminandoCategoria(E_autobuses choferes)
        {
            objDato.EliminarChofer(choferes);
        }


        public void listarChoferesEnCmb(ComboBox comboBox) 
        {
            comboBox.DataSource = objDato.desplegarChoferes();
            
            comboBox.DisplayMember = "NOMBRE";
            comboBox.ValueMember = "ID";


        }



    }
}
