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
   
    

        public bool Login(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select id,email,pass,Administrador from USUARIOS where email=@email and pass=@pass");
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Pass);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    usuario.ID = (int)datos.lector["id"];
                    usuario.Admin = (bool)datos.lector["Administrador"];
                    // mensaje para verificar los valores
                    Console.WriteLine("Inicio de sesión exitoso. ID: " + usuario.ID + ", Admin: " + usuario.Admin);

                    return true; 
                }
                return false;
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
    
    }
}
