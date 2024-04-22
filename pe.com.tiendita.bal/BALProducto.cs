using pe.com.tiendita.bo;
using pe.com.tiendita.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.tiendita.bal
{
    public class BALProducto
    {
        DALProducto dal = new DALProducto();

        public List<BOProducto> MostrarProducto()
        {
            return dal.MostrarProducto();
        }

        public List<BOProducto> MostrarProductoTodo()
        {
            return dal.MostrarProductoTodo();
        }

        public bool RegistrarProducto(BOProducto bc)
        {
            return dal.RegistrarProducto(bc);
        }

        public bool ActualizarProducto(BOProducto bc)
        {
            return dal.ActualizarProducto(bc);
        }

        public bool EliminarProducto(BOProducto bc)
        {
            return dal.EliminarProducto(bc);
        }
    }
}