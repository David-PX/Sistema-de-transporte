using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocios
{
    public class N_choferes
    {
        D_choferes objDato = new D_choferes();
        public List<E_choferes> ListarCategoria(string buscar)
        {
            return objDato.ListarChoferes(buscar);
        }

        public void InsertandoCategoria(E_choferes choferes)
        {
            objDato.insertarChofer(choferes);
        }
        public void EditandoCategoria(E_choferes choferes)
        {
            objDato.EditarChofer(choferes);

        }
        public void EliminandoCategoria(E_choferes choferes)
        {
            objDato.EliminarChofer(choferes);
        }

    }
}
