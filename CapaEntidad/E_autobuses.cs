using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class E_autobuses
    {

        private int _ID;
        private int _IDCHOFER;
        private string _MARCA;
        private string _MODELO;
        private string _PLACA;
        private string _COLOR;
        private string _ANO;

        public int ID { get => _ID; set => _ID = value; }
        public int IDCHOFER { get => _IDCHOFER; set => _IDCHOFER = value; }
        public string MARCA { get => _MARCA; set => _MARCA = value; }
        public string MODELO { get => _MODELO; set => _MODELO = value; }
        public string PLACA { get => _PLACA; set => _PLACA = value; }
        public string COLOR { get => _COLOR; set => _COLOR = value; }
        public string ANO { get => _ANO; set => _ANO = value; }
    }
}
