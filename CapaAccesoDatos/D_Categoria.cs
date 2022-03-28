using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidad;
using System.Data;

namespace CapaAccesoDatos
{
    public class D_Categoria
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);
        public List<E_Categoria> ListaCategorias(string buscar)
        {
            SqlDataReader LeerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCARCATEGORIA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            LeerFilas = cmd.ExecuteReader();

            List<E_Categoria> Listar = new List<E_Categoria>();
            while (LeerFilas.Read())
            {
                Listar.Add(new E_Categoria
                {
                    IdCategoria = LeerFilas.GetInt32(0),
                    CodigoCategoria = LeerFilas.GetString(1),
                    Nombre = LeerFilas.GetString(2),
                    Descripcion = LeerFilas.GetString(3)
                });    
            }
            con.Close();
            LeerFilas.Close();
            return Listar; 
        }
        public void  InsertarCategoria(E_Categoria categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARCATEGORIA",con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@NOMBRE",categoria.Nombre);
            cmd.Parameters.AddWithValue("@DESCRIPCION",categoria.Descripcion);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void EditarCategoria(E_Categoria categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARCATEGORIA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@IDCATEGORIA",categoria.IdCategoria);
            cmd.Parameters.AddWithValue("@NOMBRE",categoria.Nombre);
            cmd.Parameters.AddWithValue("@DESCRIPCION",categoria.Descripcion);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void EliminarCategoria(E_Categoria categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARCATEGORIA",con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@IDCATEGORIA",categoria.IdCategoria);

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}