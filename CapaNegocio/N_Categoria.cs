using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaAccesoDatos;

namespace CapaNegocio
{
    public class N_Categoria
    {
        D_Categoria objDato = new D_Categoria();
        public List<E_Categoria> listarCategoria(string buscar)
        {
            return objDato.ListaCategorias(buscar);
        }
        public void create(E_Categoria categoria)
        {
            objDato.InsertarCategoria(categoria);
        }
        public void update(E_Categoria categoria)
        {
            objDato.EditarCategoria(categoria);
        }
        public void delete(E_Categoria categoria)
        {
            objDato.EliminarCategoria(categoria);
        }
    }
}