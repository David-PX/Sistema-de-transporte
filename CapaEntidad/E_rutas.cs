using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class E_rutas
    {
        private int _ID;
        private string _CODIGORUTA;
        private int _IDAUTOBUS;
        private string _NOMBRE;

        public int ID { get => _ID; set => _ID = value; }
        public string CODIGORUTA { get => _CODIGORUTA; set => _CODIGORUTA = value; }
        public int IDAUTOBUS { get => _IDAUTOBUS; set => _IDAUTOBUS = value; }
        public string NOMBRE { get => _NOMBRE; set => _NOMBRE = value; }
      
    }
}
