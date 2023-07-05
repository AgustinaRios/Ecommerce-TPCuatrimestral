using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


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

       
    }
}
