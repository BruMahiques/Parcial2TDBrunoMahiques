using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Collections;
using System.Data;

namespace DAL
{
    public class DALAutos
    {
        public void EspacioGaraje(int Act, string descripcion)

        {
            Hashtable Parametros = new Hashtable();

            Parametros.Add("@Descripcion", descripcion);
            Parametros.Add("@Valor", Act);
            

            Acceso AccesoDB = new Acceso();
            AccesoDB.Escribir("sp_InsertarEspacioGaraje", Parametros);
        }

        public int ObtenerEspacioGaraje()

        {
            Acceso AccesoDB = new Acceso();
            Hashtable Param = new Hashtable();
            DataSet Ds = new DataSet();

            Ds = AccesoDB.Leer("sp_ObtenerEspacioGaraje", null);

            int valor = 0;

            if (Ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow Item in Ds.Tables[0].Rows)
                {
                    valor = Convert.ToInt32(Item[0]);
                }
            }
            return valor;
        }
    }
}
