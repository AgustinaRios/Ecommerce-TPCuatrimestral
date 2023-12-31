﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CategoriaNegocio
    {

        public List<Categoria> listar(bool Activo = true)
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (Activo)
                {
                    datos.setearConsulta("Select Id,Descripcion,activo from CATEGORIA where activo=1  ");

                }
                else
                {
                    datos.setearConsulta("Select Id,Descripcion,activo from CATEGORIA");
                }
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Activo = (bool)datos.Lector["Activo"];
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public int agregar(Categoria nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "INSERT INTO Categoria (Descripcion) VALUES (@Descripcion); SELECT SCOPE_IDENTITY(); ";
                datos.setearConsulta(consulta);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);

                datos.comando.Connection = datos.conexion; // Asignar la conexión al objeto SqlCommand

                datos.conexion.Open(); // Abre la conexión a la base de datos

                int idcategoria = Convert.ToInt32(datos.comando.ExecuteScalar());

                // Asignar el ID generado al objeto Artista
                nuevo.Id = idcategoria;

                return idcategoria;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void BajaLogica(int Id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE CATEGORIA set Activo = 0 where Id= @id");
                datos.setearParametro("@id", Id);

                datos.ejectutarAccion();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al dar de baja la categoria.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
        public Categoria ObtenerPorId(int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select Id,Descripcion from CATEGORIA where Id=" + Id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.Id = Id;
                    categoria.Descripcion = datos.Lector.GetString(1);

                    return categoria;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void AltaLogica(int Id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE CATEGORIA set Activo = 1 where Id= @id");
                datos.setearParametro("@id", Id);

                datos.ejectutarAccion();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta la categoria.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
        public void modificar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedimiento("sp_modificarCategoria");
                datos.setearParametro("@Id", categoria.Id);
                datos.setearParametro("@Descripcion", categoria.Descripcion);

                datos.ejectutarAccion();


            }

            catch (Exception ex)
            {
                throw new Exception("Error al modificar la categoria.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }


        }

    }
}
