using pe.com.tiendita.bal;
using pe.com.tiendita.bo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace pe.com.tiendita.ws
{
    /// <summary>
    /// Descripción breve de TienditaWebServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class TienditaWebServices : System.Web.Services.WebService
    {
        BALCategoria balcat = new BALCategoria();
        BALProducto balpro = new BALProducto();

        [WebMethod]
        public List<BOCategoria> MostrarCategoria()
        {
            List<BOCategoria> categorias = balcat.MostrarCategoria().ToList();
            return categorias;
        }

        [WebMethod]
        public List<BOCategoria> MostrarCategoriaTodo()
        {
            List<BOCategoria> categorias = balcat.MostrarCategoriaTodo().ToList();
            return categorias;
        }

        [WebMethod]
        public bool RegistrarCategoria(BOCategoria bc)
        {
            return balcat.RegistrarCategoria(bc);
        }

        [WebMethod]
        public bool ActualizarCategoria(BOCategoria bc)
        {
            return balcat.ActualizarCategoria(bc);
        }

        [WebMethod]
        public bool EliminarCategoria(BOCategoria bc)
        {
            return balcat.EliminarCategoria(bc);
        }

        [WebMethod]
        public List<BOProducto> MostrarProducto()
        {
            List<BOProducto> productos = balpro.MostrarProducto().ToList();
            return productos;
        }

        [WebMethod]
        public List<BOProducto> MostrarProducoTodo()
        {
            List<BOProducto> productos = balpro.MostrarProductoTodo().ToList();
            return productos;
        }

        [WebMethod]
        public bool RegistrarProducto(BOProducto bc)
        {
            return balpro.RegistrarProducto(bc);
        }

        [WebMethod]
        public bool ActualizarProducto(BOProducto bc)
        {
            return balpro.ActualizarProducto(bc);
        }

        [WebMethod]
        public bool EliminarProducto(BOProducto bc)
        {
            return balpro.EliminarProducto(bc);
        }
    }
}