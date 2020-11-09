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
    public class D_choferes
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);


       
        public List<E_choferes> ListarChoferes(string buscar)
        {
            SqlDataReader leerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCARCHOFER", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            leerFilas = cmd.ExecuteReader();
            List<E_choferes> Listar = new List<E_choferes>();
            while (leerFilas.Read())
            {
                Listar.Add(new E_choferes
                {
                    ID = leerFilas.GetInt32(0),
                    NOMBRE = leerFilas.GetString(1),
                    APELLIDO = leerFilas.GetString(2),
                    CEDULA = leerFilas.GetString(3),
                    FECHA_NACIMIENTO = leerFilas.GetDateTime(4)

                }) ;


            }
            conexion.Close();
            leerFilas.Close();
            return Listar;


        }



        public void insertarChofer(E_choferes chofer)
        {
            SqlCommand cmd = new SqlCommand("SP_GUARDARCHOFER", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@NOMBRE", chofer.NOMBRE);
            cmd.Parameters.AddWithValue("@APELLIDO", chofer.APELLIDO);
            cmd.Parameters.AddWithValue("@CEDULA", chofer.CEDULA);
            cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", chofer.FECHA_NACIMIENTO);
            cmd.ExecuteNonQuery();
            conexion.Close();

        }

        public void EditarChofer(E_choferes chofer)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARCHOFER", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@ID", chofer.ID);
            cmd.Parameters.AddWithValue("@NOMBRE", chofer.NOMBRE);
            cmd.Parameters.AddWithValue("@APELLIDO", chofer.APELLIDO);
            cmd.Parameters.AddWithValue("@CEDULA", chofer.CEDULA);
            cmd.Parameters.AddWithValue("@FECHA_NACIMIENTO", chofer.FECHA_NACIMIENTO);
            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarChofer(E_choferes chofer)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARCHOFER", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@ID", chofer.ID);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
