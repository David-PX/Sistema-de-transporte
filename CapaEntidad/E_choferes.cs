using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class E_choferes
    {
        private int _ID;
        private string _NOMBRE;
        private string _APELLIDO;
        private string _CEDULA;
        private DateTime _FECHA_NACIMIENTO;

        public int ID { get => _ID; set => _ID = value; }
        public string NOMBRE { get => _NOMBRE; set => _NOMBRE = value; }
        public string APELLIDO { get => _APELLIDO; set => _APELLIDO = value; }
        public string CEDULA { get => _CEDULA; set => _CEDULA = value; }
        public DateTime FECHA_NACIMIENTO { get => _FECHA_NACIMIENTO; set => _FECHA_NACIMIENTO = value; }
    }
}
