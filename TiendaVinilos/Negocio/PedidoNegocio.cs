using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Negocio
{
    public class PedidoNegocio
    {

        public int insertarNuevo(Pedido pedido)
        {
            AccesoDatos datos = new AccesoDatos();

            try

            {
                datos.setearProcedimiento("InsertarNuevoPedido");
                datos.setearParametro("@IdUsuario", pedido.IdUsuario);
                datos.setearParametro("@IdFormaEntrega", pedido.IdFormaEntrega);
                datos.setearParametro("@Direccion", pedido.Direccion);
                datos.setearParametro("@Localidad", pedido.Localidad);
                datos.setearParametro("@Provincia", pedido.Provincia);
                datos.setearParametro("@IdFormaPago", pedido.IdFormaPago);
                datos.setearParametro("@Total", pedido.Total);
                datos.setearParametro("@IdEstadoPedido", pedido.IdEstado);
             



                return datos.ejectutarAccionScalar();


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

        public List<Pedido> Listar(int id)
        {
            List<Pedido> lista = new List<Pedido>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearParametro("@ID", id);
                datos.setearConsulta("select IdFormaEntrega,Direccion,Localidad,Provincia,IdFormaPago,Total,IdEstadoPedido,FechaCreacion from PEDIDOS where IdUsuario=@ID");
                datos.ejecutarLectura();
               
                while (datos.Lector.Read())
                {

                    
                    Pedido aux = new Pedido();
       
                    aux.IdFormaEntrega = (int)datos.Lector["IdFormaEntrega"];
                    aux.Direccion= (string)datos.Lector["Direccion"];
                    aux.Localidad = (string)datos.Lector["Localidad"];
                    aux.Provincia = (string)datos.Lector["Provincia"];
                    aux.IdFormaPago = (int)datos.Lector["IdFormaPago"];
                    aux.Total = (decimal)datos.Lector["Total"];
                    aux.IdEstado = (int)datos.Lector["IdEstadoPedido"];
                    aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];
                    


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
    }
}
