using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using repaso_parcial.Models;

namespace repaso_parcial.BD_Conexion
{
    public class GestorBd
    {
        public void InsertarInstrumento(Articulo ar)
        {
            string consulta = "INSERT INTO articulos(nombre, tipo, stock, precio, descripcion) VALUES(@nombre, @tipo, @stock, @precio, @descripcion)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CadenaBD"].ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@nombre", ar.Nombre);
            cmd.Parameters.AddWithValue("@tipo", ar.Tipo);
            cmd.Parameters.AddWithValue("@stock", ar.Stock);
            cmd.Parameters.AddWithValue("@precio", ar.Precio);
            cmd.Parameters.AddWithValue("@descripcion", ar.Descripcion);

            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = consulta;
            cmd.ExecuteNonQuery();
        }


        
    }
}