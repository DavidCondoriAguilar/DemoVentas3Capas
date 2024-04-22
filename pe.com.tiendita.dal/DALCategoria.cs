using pe.com.tiendita.bo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pe.com.tiendita.dal
{
    public class DALCategoria
    {
        Conexion objconexion = new Conexion();

        private SqlCommand cmdcat;
        private SqlDataReader drcat;
        int res = 0;

        public List<BOCategoria> MostrarCategoria()
        {
            List<BOCategoria> categorias = new List<BOCategoria>();
            try
            {
                cmdcat = new SqlCommand();
                cmdcat.CommandType = CommandType.StoredProcedure;
                cmdcat.CommandText = "SP_MostrarCategoria";
                cmdcat.Connection = objconexion.Conectar();
                drcat = cmdcat.ExecuteReader();
                while (drcat.Read())
                {
                    BOCategoria objgen = new BOCategoria();
                    objgen.codigo = Convert.ToInt32(drcat["codcat"].ToString());
                    objgen.nombre = drcat["nomcat"].ToString();
                    objgen.estado = Convert.ToBoolean(drcat["estcat"].ToString());
                    categorias.Add(objgen);
                }
                return categorias;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        public List<BOCategoria> MostrarCategoriaTodo()
        {
            List<BOCategoria> categorias = new List<BOCategoria>();
            try
            {
                cmdcat = new SqlCommand();
                cmdcat.CommandType = CommandType.StoredProcedure;
                cmdcat.CommandText = "SP_MostrarCategoriaTodo";
                cmdcat.Connection = objconexion.Conectar();
                drcat = cmdcat.ExecuteReader();
                while (drcat.Read())
                {
                    BOCategoria objgen = new BOCategoria();
                    objgen.codigo = Convert.ToInt32(drcat["codcat"].ToString());
                    objgen.nombre = drcat["nomcat"].ToString();
                    objgen.estado = Convert.ToBoolean(drcat["estcat"].ToString());
                    categorias.Add(objgen);
                }
                return categorias;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        public bool RegistrarCategoria(BOCategoria bc)
        {
            try
            {
                cmdcat = new SqlCommand();
                cmdcat.CommandType = CommandType.StoredProcedure;
                cmdcat.CommandText = "SP_RegistrarCategoria";
                cmdcat.Connection = objconexion.Conectar();

                cmdcat.Parameters.AddWithValue("@nombre", bc.nombre);
                cmdcat.Parameters.AddWithValue("@estado", bc.estado);

                res = cmdcat.ExecuteNonQuery();

                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        public bool ActualizarCategoria(BOCategoria bc)
        {
            try
            {
                cmdcat = new SqlCommand();
                cmdcat.CommandType = CommandType.StoredProcedure;
                cmdcat.CommandText = "SP_ActualizarCategoria";
                cmdcat.Connection = objconexion.Conectar();

                cmdcat.Parameters.AddWithValue("@codigo", bc.codigo);
                cmdcat.Parameters.AddWithValue("@nombre", bc.nombre);
                cmdcat.Parameters.AddWithValue("@estado", bc.estado);

                res = cmdcat.ExecuteNonQuery();

                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }

        public bool EliminarCategoria(BOCategoria bc)
        {
            try
            {
                cmdcat = new SqlCommand();
                cmdcat.CommandType = CommandType.StoredProcedure;
                cmdcat.CommandText = "SP_EliminarCategoria";
                cmdcat.Connection = objconexion.Conectar();

                cmdcat.Parameters.AddWithValue("@codigo", bc.codigo);

                res = cmdcat.ExecuteNonQuery();

                if (res == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            finally
            {
                objconexion.CerrarConexion();
            }
        }
    }
}