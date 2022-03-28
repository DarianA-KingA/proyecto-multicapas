using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CapaEntidad
{
    public class E_Categoria
    {
        private int _IdCategoria;
        private string _CodigoCategoria;
        private string _Nombre;
        private string _Descripcion;

        public int IdCategoria { get => _IdCategoria; set => _IdCategoria = value; } 
        public string CodigoCategoria { get => _CodigoCategoria; set => _CodigoCategoria = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
    }
}