using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TiendaVinilos
{
    public partial class FormModificarEstadoCompra : System.Web.UI.Page
    {
        PedidoNegocio negocio = new PedidoNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    List<EstadoPedido> listaEstado = new List<EstadoPedido>();
                    EstadoPedidoNegocio negocioEstEntrega = new EstadoPedidoNegocio();
                    List<EstadoPedido> filtrada = new List<EstadoPedido>();
                    EstadoPedido estPedido = new EstadoPedido();
                    Pedido pedido = new Pedido();


                    listaEstado = negocioEstEntrega.listar();

                    ddlEstadoPedido.DataSource = listaEstado;
                    ddlEstadoPedido.DataTextField = "Descripcion";
                    ddlEstadoPedido.DataValueField = "Id";

                    ddlEstadoPedido.DataBind();

                    string Id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";

                    if (Id != "")

                    {
                        Pedido seleccionado = new Pedido();
                        seleccionado.Id = int.Parse(Id);
                        int idbuscado = seleccionado.Id;
                        seleccionado = negocio.BuscarPorId(idbuscado);

                        EstadoPedido estSeleccionado = new EstadoPedido();

                        filtrada = listaEstado.FindAll(x => x.Descripcion == seleccionado.Estado.ToString());
                        estSeleccionado.Id = filtrada[0].Id;
                        estSeleccionado.Descripcion = seleccionado.Estado.ToString();


                        ddlEstadoPedido.SelectedValue = estSeleccionado.Id.ToString();
                        ddlEstadoPedido.SelectedValue = seleccionado.IdEstado.ToString();
                        ddlEstadoPedido.SelectedIndex = estSeleccionado.Id;


                    }

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);

            }


        }
        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                string Id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";

                if (Id != "")

                {
                    Pedido seleccionado = new Pedido();
                    seleccionado.Id = int.Parse(Id);
                    int idbuscado = seleccionado.Id;
                    seleccionado = negocio.BuscarPorId(idbuscado);
                    seleccionado.IdEstado = int.Parse(ddlEstadoPedido.SelectedValue);
                    negocio.modificar(seleccionado);
                    LblMensaje.Text = "Pedido modificado exitosamente";
                    LblMensaje.Visible = true;

                    Usuario usuario = new Usuario();
                    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                    int IdUsuario = seleccionado.IdUsuario;
                    usuario=usuarioNegocio.ObtenerUsuarioPorId(IdUsuario);
                    
                    EmailService emailService = new EmailService();
                    if (seleccionado.IdEstado == 2)
                    {
                        if (seleccionado.IdFormaEntrega == 1)
                            emailService.EnviarCorreo(usuario.Email, "Tienda de Vinilos!", "Hola!, nos comunicamos para avisarte que tu compra ya esta Listo!En breve estará llegando al Domicilio indicado al momento de la compra. Muchas gracias por comprar en Tienda de Vinilos!");
                        else
                            emailService.EnviarCorreo(usuario.Email, "Tienda de Vinilos!","Hola!, nos comunicamos para avisarte que tu compra ya esta Listo! Podes pasar por el local a retirarlo. Muchas gracias por comprar en Tienda de Vinilos! ");

                    }
                    else
                    {
                        emailService.EnviarCorreo(usuario.Email, "Ya se hizo entrega de la compra! Te invitamos a visitar nuestra web y puedas ver todas las novedades", "Muchas gracias por comprar en Tienda de Vinilos! ");

                    }

                    

                    Response.Redirect("ComprasUsuarios.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("error.aspx", false);

            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {


            Response.Redirect("ComprasUsuarios.aspx", false);

        }
    }
}