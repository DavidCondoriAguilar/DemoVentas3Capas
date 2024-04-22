using pe.com.tiendita.bo;
using pe.com.tiendita.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.tiendita.bal
{
    public class BALCategoria
    {
        DALCategoria dalcat = new DALCategoria();

        public List<BOCategoria> MostrarCategoria()
        {
            return dalcat.MostrarCategoria();
        }

        public List<BOCategoria> MostrarCategoriaTodo()
        {
            return dalcat.MostrarCategoriaTodo();
        }

        public bool RegistrarCategoria(BOCategoria bc)
        {
            return dalcat.RegistrarCategoria(bc);
        }

        public bool ActualizarCategoria(BOCategoria bc)
        {
            return dalcat.ActualizarCategoria(bc);
        }

        public bool EliminarCategoria(BOCategoria bc)
        {
            return dalcat.EliminarCategoria(bc);
        }
    }
}