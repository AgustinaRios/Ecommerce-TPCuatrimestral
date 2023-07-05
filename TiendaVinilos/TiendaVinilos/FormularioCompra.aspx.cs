using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TiendaVinilos
{
    public partial class FormularioCompra : System.Web.UI.Page
    {
        FormaPagoNegocio negocioFormPago = new FormaPagoNegocio();
        List<FormaPago> listaFormaPago = new List<FormaPago>();

        FormaEntregaNegocio negocioFormEntrega = new FormaEntregaNegocio();
        List<FormaEntrega> listaFormaEntrega = new List<FormaEntrega> { };


        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {

                    listaFormaEntrega = negocioFormEntrega.listar();
                    listaFormaEntrega.Insert(0, new FormaEntrega { Id = -1, Descripcion = "Forma de Entrega" });
                    ddlFormaEntrega.DataSource = listaFormaEntrega;
                    ddlFormaEntrega.DataTextField = "Descripcion";
                    ddlFormaEntrega.DataValueField = "Id";
                    ddlFormaEntrega.DataBind();

                    ddlFormaEntrega.SelectedIndex = -1;

                    listaFormaPago = negocioFormPago.listar();
                    listaFormaPago.Insert(0, new FormaPago { Id = -1, Descripcion = "" });
                    ddlFormaPago.DataSource = listaFormaPago;
                    ddlFormaPago.DataTextField = "Descripcion";
                    ddlFormaPago.DataValueField = "Id";
                    ddlFormaPago.DataBind();

                    ddlFormaPago.SelectedIndex = -1;

                }
                if (ddlFormaEntrega.SelectedIndex == 1)
                {
                    Usuario usuario = new Usuario();
                    usuario = (Usuario)Session["usuario"];

                    int id = usuario.ID;

                    TxtDireccion.Text = usuario.Direccion;
                    TxtLocalidad.Text = usuario.Localidad;
                    TxtProvincia.Text = usuario.Provincia;

                }
                else
                {
                    if (ddlFormaEntrega.SelectedIndex == 2)
                    {
                        UsuarioNegocio adm = new UsuarioNegocio();
                        Usuario administrador = new Usuario();
                        administrador = (Usuario)adm.BuscarAdmin();
                        TxtDireccion.Text = administrador.Direccion;
                        TxtLocalidad.Text = administrador.Localidad;
                        TxtProvincia.Text = administrador.Provincia;
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito.aspx", false);
        }
        protected void BtnAceptar_Click(object sender, EventArgs e)
        {

            UsuarioNegocio negocio = new UsuarioNegocio();
            Pedido pedido = new Pedido();
            PedidoNegocio pedidoNegocio = new PedidoNegocio();
           
            ProductosCarrito carrito = (ProductosCarrito)Session["carrito"];


            Usuario usuario = (Usuario)Session["usuario"];
            pedido.IdUsuario = usuario.ID;
            pedido.IdFormaEntrega = ddlFormaEntrega.SelectedIndex;
            pedido.Direccion = TxtDireccion.Text;
            pedido.Localidad = TxtLocalidad.Text;
            pedido.Provincia = TxtProvincia.Text;
            pedido.IdFormaPago = ddlFormaPago.SelectedIndex;
            pedido.Total = carrito.totalCarrito(carrito);
            
            pedido.IdEstado = 1;

            pedido.Id = pedidoNegocio.insertarNuevo(pedido);
            Session.Add("Pedido", pedido);

            ///el mail mejor ponerlo en el formualario de confirmacion de compra
            /// emailService.EnviarCorreo(usuario.Email, "Gracias por tu compra!", "Te estaremos avisando el avance de la compra!");


           

            Response.Redirect("ConfirmacionCompra.aspx", false);
        }
    }
}