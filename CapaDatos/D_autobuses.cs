using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidad;
using System.Data;

namespace CapaDatos
{
    public class D_autobuses
    {
       
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public DataTable desplegarChoferes()
        {
            SqlDataReader leerFilas;
            DataTable tabla = new DataTable();
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_BUSCARCHOFER", conexion);
            cmd.Parameters.AddWithValue("@BUSCAR", "");
            cmd.CommandType = CommandType.StoredProcedure;
            leerFilas = cmd.ExecuteReader();
            tabla.Load(leerFilas);
            leerFilas.Close();
            conexion.Close();
            return tabla;


        }

        public DataTable ListarAutobusesYchoferes(string like)
        {
            SqlDataReader leerFilas;
            DataTable tabla = new DataTable();
            conexion.Open();
            SqlCommand cmd = new SqlCommand("LISTARAUTOBUSES", conexion);
            cmd.Parameters.AddWithValue("@like", like);
            cmd.CommandType = CommandType.StoredProcedure;
            leerFilas = cmd.ExecuteReader();
            tabla.Load(leerFilas);
            leerFilas.Close();
            conexion.Close();
            return tabla;


        }




        public List<E_autobuses> ListarChoferes(string buscar)
        {
            SqlDataReader leerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCARAUTOBUS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            leerFilas = cmd.ExecuteReader();
            List<E_autobuses> Listar = new List<E_autobuses>();
            while (leerFilas.Read())
            {
                Listar.Add(new E_autobuses
                {
                    ID = leerFilas.GetInt32(0),
                    IDCHOFER = leerFilas.GetInt32(1),
                    MARCA = leerFilas.GetString(2),
                    MODELO = leerFilas.GetString(3),
                    PLACA = leerFilas.GetString(4),
                    COLOR = leerFilas.GetString(5),
                    ANO = leerFilas.GetString(6)


                });


            }
            conexion.Close();
            leerFilas.Close();
            return Listar;


        }



        public void insertarChofer(E_autobuses chofer)
        {
            SqlCommand cmd = new SqlCommand("SP_GUARDARAUTOBUS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@IDCHOFER", chofer.IDCHOFER);
            cmd.Parameters.AddWithValue("@MARCA", chofer.MARCA);
            cmd.Parameters.AddWithValue("@MODELO", chofer.MODELO);
            cmd.Parameters.AddWithValue("@PLACA", chofer.PLACA);
            cmd.Parameters.AddWithValue("@COLOR", chofer.COLOR);
            cmd.Parameters.AddWithValue("@ANO", chofer.ANO);
            cmd.ExecuteNonQuery();
            conexion.Close();

        }

        public void EditarChofer(E_autobuses chofer)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARAUTOBUS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@ID", chofer.ID);
            cmd.Parameters.AddWithValue("@IDCHOFER", chofer.IDCHOFER);
            cmd.Parameters.AddWithValue("@MARCA", chofer.MARCA);
            cmd.Parameters.AddWithValue("@MODELO", chofer.MODELO);
            cmd.Parameters.AddWithValue("@PLACA", chofer.PLACA);
            cmd.Parameters.AddWithValue("@COLOR", chofer.COLOR);
            cmd.Parameters.AddWithValue("@ANO", chofer.ANO);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarChofer(E_autobuses chofer)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARAUTOBUS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@ID", chofer.ID);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}

