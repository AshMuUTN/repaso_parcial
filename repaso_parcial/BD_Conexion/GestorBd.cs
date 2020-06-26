using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using repaso_parcial.Models;
using System.Web.UI.WebControls.WebParts;

namespace repaso_parcial.BD_Conexion
{
    public class GestorBd
    {
        public static bool InsertarInstrumento(Articulo ar)
        {
            bool resultado = false;
            string consulta = "INSERT INTO articulos(nombre, tipo, stock, precio, descripcion) VALUES(@nombre, @tipo, @stock, @precio, @descripcion)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CadenaBD"].ToString());
            try
            {
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
                resultado = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return resultado;
        }

        public static bool EditarInstrumento(Articulo ar)
        {
            bool resultado = false;
            string consulta = "UPDATE articulos set nombre = @nombre, tipo = @tipo, stock = @stock, precio = @precio, descripcion = @descripcion WHERE id = @id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CadenaBD"].ToString());
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", ar.Nombre);
                cmd.Parameters.AddWithValue("@tipo", ar.Tipo);
                cmd.Parameters.AddWithValue("@stock", ar.Stock);
                cmd.Parameters.AddWithValue("@precio", ar.Precio);
                cmd.Parameters.AddWithValue("@descripcion", ar.Descripcion);
                cmd.Parameters.AddWithValue("@id", ar.Id);

                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return resultado;
        }
        public static List<Articulo> ObtenerListaInstrumentos(string tipo)
        {
            List<Articulo> resultado = new List<Articulo>();
            string consulta = "SELECT * FROM articulos  WHERE active = 1";
            
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CadenaBD"].ToString());
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Clear();
                if (tipo.Length > 0)
                {
                    consulta = consulta + " AND tipo = (SELECT id FROM tipo_instrumento WHERE tipo = @tipo)";
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                }
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        Articulo aux = new Articulo();
                        aux.Id = int.Parse(dr["id"].ToString());
                        aux.Nombre = dr["nombre"].ToString();
                        aux.Descripcion = dr["descripcion"].ToString();
                        aux.Precio = decimal.Parse(dr["precio"].ToString());
                        aux.PrecioString = dr["precio"].ToString();
                        aux.Tipo = int.Parse(dr["tipo"].ToString());
                        aux.Stock = int.Parse(dr["stock"].ToString());
                        resultado.Add(aux);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return resultado;
        }

        public static bool BorrarInstrumento(int id)
        {
            bool resultado = false;
            string consulta = "UPDATE articulos SET active = 0 WHERE id = @id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CadenaBD"].ToString());
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;
                cmd.ExecuteNonQuery();
                resultado = true;
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return resultado;
        }

        public static Articulo SeleccionarInstrumento(int id)
        {
            Articulo resultado = new Articulo();
            string consulta = "SELECT * from articulos WHERE id = @id";
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CadenaBD"].ToString());
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;
                
                SqlDataReader dr = cmd.ExecuteReader();
                if(dr != null)
                {
                    dr.Read();
                    resultado.Id = int.Parse(dr["id"].ToString());
                    resultado.Nombre = dr["nombre"].ToString();
                    resultado.Descripcion = dr["descripcion"].ToString();
                    resultado.Precio = decimal.Parse(dr["precio"].ToString());
                    resultado.PrecioString = dr["precio"].ToString();
                    resultado.Tipo = int.Parse(dr["tipo"].ToString());
                    resultado.Stock = int.Parse(dr["stock"].ToString());
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return resultado;
        }

        public static List<TipoInstrumento> ObtenerListaTipos()
        {
            List<TipoInstrumento> resultado = new List<TipoInstrumento>();
            string consulta = "SELECT * FROM tipo_instrumento";
            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["CadenaBD"].ToString());
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Clear();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {
                        TipoInstrumento aux = new TipoInstrumento();
                        aux.Id = int.Parse(dr["id"].ToString());
                        aux.Tipo = dr["tipo"].ToString();
                        resultado.Add(aux);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return resultado;
        }

    }
}