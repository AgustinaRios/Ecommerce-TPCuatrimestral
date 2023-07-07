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
                datos.setearConsulta("select  fe.id,fe.descripcion as formaentrega, p.Direccion, p.Localidad, p.Provincia,fp.id, fp.Descripcion as formapago, p.Total, ep.Id, ep.Descripcion as estadopedido, p.FechaCreacion from PEDIDOS p , FORMA_ENTREGA  fe, FORMA_PAGO  fp, ESTADO_PEDIDO  ep where p.IdFormaEntrega = fe.Id  and p.IdFormaPago = fp.Id   and p.IdEstadoPedido = ep.Id  and p.IdUsuario=@ID");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {


                    Pedido aux = new Pedido();
               
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("formaentrega"))))
                        aux.FormaEntrega = (string)datos.Lector["formaentrega"];
                        aux.Direccion = (string)datos.Lector["Direccion"];
                        aux.Localidad = (string)datos.Lector["Localidad"];
                        aux.Provincia = (string)datos.Lector["Provincia"];
                   
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("formapago"))))
                        aux.FormaPago = (string)datos.Lector["formapago"];
                        aux.Total = (decimal)datos.Lector["Total"];
                   
                    if (!(datos.Lector.IsDBNull(datos.lector.GetOrdinal("estadopedido"))))
                        aux.Estado = (string)datos.Lector["estadopedido"];
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
