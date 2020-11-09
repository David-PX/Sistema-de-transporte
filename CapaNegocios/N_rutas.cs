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
    public class N_rutas
    {
        D_rutas objDato = new D_rutas();
        public List<E_rutas> ListarCategoria(string buscar)
        {
            return objDato.ListarChoferes(buscar);
        }

        public void InsertandoCategoria(E_rutas choferes)
        {
            objDato.insertarChofer(choferes);
        }
        public void EditandoCategoria(E_rutas choferes)
        {
            objDato.EditarChofer(choferes);

        }
        public void EliminandoCategoria(E_rutas choferes)
        {
            objDato.EliminarChofer(choferes);
        }

        public void listarAutobusesEnCmb(ComboBox comboBox)
        {
            comboBox.DataSource = objDato.desplegarAutobuses();

            comboBox.DisplayMember = "PLACA";
            comboBox.ValueMember = "ID";


        }
        public void ListarRutasYautobuses(string like, DataGridView data)
        {
            data.DataSource = objDato.ListarRutasYchoferes(like);

        }


        public void ListarTodos(DataGridView data)
        {
           data.DataSource =  objDato.ListarTodo();
        }
    }
}
