using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class UsuarioNegocio
    {
        public int insertarNuevo(Usuario nuevo)
        {
           AccesoDatos datos = new AccesoDatos();  
            
            try
            {
                datos.setearProcedimiento("InsertarNuevo");
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@Email", nuevo.Email);
                datos.setearParametro("@Pass", nuevo.Pass);
                return datos.ejectutarAccionScalar();

                
            }
            catch(Exception ex)
            {
                throw ex;

            }

            finally
            {
                datos.cerrarConexion();
            }
            
            
        }

        

        public Usuario Login(Usuario usuario)
        {

            Usuario aux = new Usuario();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select ID, Nombre, Apellido, Email, Pass,FechaCreacion, Administrador,Activo from USUARIOS  where email=@email and pass=@pass");

                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Pass);
                    datos.ejecutarLectura();
                if (datos.Lector.Read())
                {

                    aux.ID = (Int32)datos.Lector["Id"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Nombre"))))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Apellido"))))
                        aux.Apellido = (string)datos.Lector["Apellido"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Email"))))
                        aux.Email = (string)datos.Lector["Email"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Pass"))))
                        aux.Pass = (string)datos.Lector["Pass"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("FechaCreacion"))))
                        aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Administrador"))))
                        aux.Admin = (bool)datos.Lector["Administrador"];
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("Activo"))))
                        aux.Activo = (bool)datos.Lector["Activo"];

                    ///



                    // mensaje para verificar los valores
                    Console.WriteLine("Inicio de sesión exitoso. ID: " + aux.ID + ", Admin: " + aux.Admin);

                }
                    return aux;
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

        public void modificar(Usuario usuario )
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearConsulta("update USUARIOS set Nombre=@nombre, Apellido=@apellido, Email=@email where Id=@id");
                datos.setearParametro("@id", usuario.ID);
                datos.setearParametro("@nombre", usuario.Nombre);
                datos.setearParametro("@apellido", usuario.Apellido);
                datos.setearParametro("@email", usuario.Email);
               

                datos.ejectutarAccion();
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



        //listarUsuario
        public List<Usuario> listar()
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Id,Nombre,Apellido,Email,FechaCreacion,Administrador,Activo from USUARIOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.ID = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Email = (string)datos.Lector["Email"];
                    aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];
                    aux.Admin = (bool)datos.Lector["Administrador"];
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
        public int ExisteUsuarioPorEmail(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM USUARIOS WHERE Email = @Email");
                datos.setearParametro("@Email", usuario.Email);

                int count = (int)datos.ejectutarAccionScalar();

                return count;
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
                datos.setearConsulta("UPDATE USUARIOS set Activo = 0 where Id= @id");
                datos.setearParametro("@id", Id);

                datos.ejectutarAccion();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al dar desactivar al usuario.", ex);
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
                datos.setearConsulta("UPDATE USUARIOS set Activo = 1 where Id= @id");
                datos.setearParametro("@id", Id);

                datos.ejectutarAccion();
            }

            catch (Exception ex)
            {
                throw new Exception("Error al dar activar al usuario.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}
