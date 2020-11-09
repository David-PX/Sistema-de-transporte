using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CapaEntidad;

namespace CapaDatos
{
    public class D_rutas
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public DataTable ListarTodo()
        {
            SqlDataReader leerFilas;
            DataTable tabla = new DataTable();
            conexion.Open();
            SqlCommand cmd = new SqlCommand("TRAERTODOS", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            leerFilas = cmd.ExecuteReader();
            tabla.Load(leerFilas);
            leerFilas.Close();
            conexion.Close();
            return tabla;
        }
        public DataTable desplegarAutobuses()
        {
            SqlDataReader leerFilas;
            DataTable tabla = new DataTable();
            conexion.Open();
            SqlCommand cmd = new SqlCommand("SP_BUSCARAUTOBUS", conexion);
            cmd.Parameters.AddWithValue("@BUSCAR", "");
            cmd.CommandType = CommandType.StoredProcedure;
            leerFilas = cmd.ExecuteReader();
            tabla.Load(leerFilas);
            leerFilas.Close();
            conexion.Close();
            return tabla;


        }
        public DataTable ListarRutasYchoferes(string like)
        {
            SqlDataReader leerFilas;
            DataTable tabla = new DataTable();
            conexion.Open();
            SqlCommand cmd = new SqlCommand("LISTARAUTOBUSESYRUTAS", conexion);
            cmd.Parameters.AddWithValue("@like", like);
            cmd.CommandType = CommandType.StoredProcedure;
            leerFilas = cmd.ExecuteReader();
            tabla.Load(leerFilas);
            leerFilas.Close();
            conexion.Close();
            return tabla;


        }
        public List<E_rutas> ListarChoferes(string buscar)
        {
            SqlDataReader leerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCARRUTA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            leerFilas = cmd.ExecuteReader();
            List<E_rutas> Listar = new List<E_rutas>();
            while (leerFilas.Read())
            {
                Listar.Add(new E_rutas
                {
                    ID = leerFilas.GetInt32(0),
                    CODIGORUTA = leerFilas.GetString(1),
                    IDAUTOBUS = leerFilas.GetInt32(2),
                   NOMBRE = leerFilas.GetString(3),
                   


                });


            }
            conexion.Close();
            leerFilas.Close();
            return Listar;


        }



        public void insertarChofer(E_rutas chofer)
        {
            SqlCommand cmd = new SqlCommand("SP_GUARDARRUTA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
        
            cmd.Parameters.AddWithValue("@IDAUTOBUS", chofer.IDAUTOBUS);
            cmd.Parameters.AddWithValue("@NOMBRE", chofer.NOMBRE);
           
            cmd.ExecuteNonQuery();
            conexion.Close();

        }

        public void EditarChofer(E_rutas chofer)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARRUTA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@ID", chofer.ID);
           
            cmd.Parameters.AddWithValue("@IDAUTOBUS", chofer.IDAUTOBUS);
            cmd.Parameters.AddWithValue("@NOMBRE", chofer.NOMBRE);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarChofer(E_rutas chofer)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARRUTA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@ID", chofer.ID);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
