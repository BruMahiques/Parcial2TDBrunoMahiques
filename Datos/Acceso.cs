using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Datos
{
    public class Acceso
    {
        private SqlConnection Conexion;
        private SqlCommand ComandoSQL;
        private SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DVP7934\SQLEXPRESS;Initial Catalog=Parcial2MahiquesBrunoTD;Integrated Security=True");
        private SqlTransaction transaction;
        private SqlTransaction Transaction;
        private SqlCommand cmd;
        private string CadenaConexion = @"Data Source=DESKTOP-DVP7934\SQLEXPRESS;Initial Catalog=Parcial2MahiquesBrunoTD;Integrated Security=True";

        public void Abrir()
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=DESKTOP-DVP7934\SQLEXPRESS;Initial Catalog=Parcial2MahiquesBrunoTD;Integrated Security=True";
            con.Open();
        }

        public void Cerrar()
        {
            con.Close();
            con.Dispose();
            con = null;
            GC.Collect();
        }

        private SqlConnection AbrirConexion()

        {
            Conexion = new SqlConnection(CadenaConexion);
            Conexion.Open();
            return Conexion;
        }

        public DataSet Leer(string consulta, Hashtable Hdatos)
        {
            DataSet ds = new DataSet();
            cmd = new SqlCommand();

            cmd.Connection = con;
            cmd.CommandText = consulta;
            cmd.CommandType = CommandType.StoredProcedure;


            if (Hdatos != null)
            {
                foreach (string d in Hdatos.Keys)
                {
                    cmd.Parameters.AddWithValue(d, Hdatos[d]);
                }


            }
            SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
            Adapter.Fill(ds);

            return ds;

        }




        public bool Escribir(string Consulta, Hashtable Hdatos)
        {
            Abrir();

            try
            {
                transaction = con.BeginTransaction();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = Consulta;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = transaction;

                if (Hdatos != null)
                {
                    foreach (string d in Hdatos.Keys)
                    {
                        cmd.Parameters.AddWithValue(d, Hdatos[d]);
                    }
                }

                int a = cmd.ExecuteNonQuery();
                transaction.Commit();
                return true;


            }
            catch
            {


                transaction.Rollback();
                return false;
            }
            finally
            {
                Cerrar();
            }
        }
    }
}
