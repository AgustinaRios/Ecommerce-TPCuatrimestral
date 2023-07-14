using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Drawing;

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
                    listaFormaPago.Insert(0, new FormaPago { Id = -1, Descripcion = "Forma de Pago" });
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
                    Pedido domicilioentrega = (Pedido)Session["DomicilioEntrega"];
                    if (domicilioentrega != null)
                    {
                        LblDomicilio.Text = domicilioentrega.Direccion + ", " + domicilioentrega.Localidad + ", " + domicilioentrega.Provincia;
                        BtnModificar.Visible = true;

                    }
                    else
                    {
                        if (usuario.Direccion == "" || usuario.Localidad == "" || usuario.Provincia == "")
                        {
                            LblDomicilio.Text = "Debe ingresar un Domicilio de Entrega";
                            BtnModificar.Visible = true;
                        }
                        else
                        {

                            LblDomicilio.Text = usuario.Direccion + ", " + usuario.Localidad + ", " + usuario.Provincia;
                            BtnModificar.Visible = true;
                        }


                        Pedido domicilio = new Pedido();
                        domicilio.Direccion = usuario.Direccion;
                        domicilio.Localidad = usuario.Localidad;
                        domicilio.Provincia = usuario.Provincia;

                        Session.Add("Domicilio", domicilio);
                    }

                }
                else
                {
                    if (ddlFormaEntrega.SelectedIndex == 2)
                    {
                        BtnModificar.Visible = false;
                        UsuarioNegocio adm = new UsuarioNegocio();
                        Usuario administrador = new Usuario();
                        administrador = (Usuario)adm.BuscarAdmin();
                        Pedido domicilio = new Pedido();
                        domicilio.Direccion = administrador.Direccion;
                        domicilio.Localidad = administrador.Localidad;
                        domicilio.Provincia = administrador.Provincia;
                        LblDomicilio.Text = administrador.Direccion + ", " + administrador.Localidad + ", " + administrador.Provincia;
                        Session.Add("Domicilio", domicilio);
                        Session["DomicilioEntrega"] = null;
                    }
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        bool ValidarVaciosTarjeta()
        {
            TxtCodSeguridad.BorderColor = Color.White;
            TxtFechaVto.BorderColor = Color.White;
            TxtNroTarjeta.BorderColor = Color.White;

            bool vacios = false;

            if (TxtCodSeguridad.Text == "")
            {
                TxtCodSeguridad.BorderColor = Color.Red;
                vacios = true;
            }
            if (TxtFechaVto.Text == "")
            {

                TxtFechaVto.BorderColor = Color.Red;
                vacios = true;
            }
            if (TxtNroTarjeta.Text == "")
            {
                TxtNroTarjeta.BorderColor = Color.Red;
                vacios = true;
            }

            return vacios;
        }

        bool ValidarVaciosDll()
        {
            ddlFormaEntrega.BorderColor = Color.White;
            ddlFormaPago.BorderColor = Color.White;
            

            bool vacios = false;

            if (ddlFormaEntrega.SelectedIndex == 0)
            {
                ddlFormaEntrega.BorderColor = Color.Red;
                vacios = true;
            }
            if (ddlFormaPago.SelectedIndex == 0)
            {

                ddlFormaPago.BorderColor = Color.Red;
                vacios = true;
            }
          

            return vacios;
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
            Pedido domicilioentrega = (Pedido)Session["DomicilioEntrega"];//sera nulo si no decidio ir al formulario Domicilioentrega y cambiar los datos
            if (domicilioentrega != null)
            {

                pedido.Direccion = domicilioentrega.Direccion;
                pedido.Localidad = domicilioentrega.Localidad;
                pedido.Provincia = domicilioentrega.Provincia;
            }
            else
            {

                Pedido domicilio = (Pedido)Session["Domicilio"];
                if ( ValidarVaciosDll()==true )
                {
                    LblMensaje.Text = "Complete todos los campos";
                    LblMensaje.Visible = true;
                    return;

                }
                pedido.Direccion = domicilio.Direccion;
                pedido.Localidad = domicilio.Localidad;
                pedido.Provincia = domicilio.Provincia;
            }

            pedido.IdFormaPago = ddlFormaPago.SelectedIndex;
            if (pedido.IdFormaPago == 3)
            {
                if (ValidarVaciosTarjeta() == true)
                {
                    LblMensaje.Text = "Complete todos los campos";
                    LblMensaje.Visible = true;
                    return;
                }

                DateTime fechavto = DateTime.Parse(TxtFechaVto.Text);
                //// Se valida que la fecha no sea anterior a la del dia actual
                DateTime hoy = DateTime.Now;
                if (fechavto <= hoy)
                {
                    LblMensaje.Text = "Tarjeta de crédito vencida";
                    LblMensaje.Visible = true;
                    return;
                }
            }



            pedido.Total = carrito.totalCarrito(carrito);

            pedido.IdEstado = 1;

            pedido.Id = pedidoNegocio.insertarNuevo(pedido);
            insertarProductoPorPedido(pedido);
            Session.Add("Pedido", pedido);




            Session["Pedido"] = pedido;
            Session["carrito"] = carrito;
            Response.Redirect("ConfirmacionCompra.aspx", false);
        }

        public void insertarProductoPorPedido(Pedido pedido)
        {
            ProductosCarrito carrito = (ProductosCarrito)Session["carrito"];

            foreach (var producto in carrito.lista)
            {
                AccesoDatos datos = new AccesoDatos();

                try
                {
                    datos.setearProcedimiento("InsertarProductoPorPedido");
                    datos.setearParametro("@IdPedido", pedido.Id);

                    Album album = (Album)producto.Producto;
                    int idAlbum = album.Id;
                    int cantidad = producto.Cantidad;

                    datos.setearParametro("@IdAlbum", idAlbum);
                    datos.setearParametro("@Cantidad", cantidad);

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
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            Response.Redirect("DomicilioEntrega.aspx", false);
        }
    }
}