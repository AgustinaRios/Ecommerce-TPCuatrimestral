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

       // public bool delivery = false;

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    Usuario usuario = new Usuario();
                    usuario = (Usuario)Session["usuario"];

                    int id = usuario.ID;

                    TxtDireccion.Text = usuario.Direccion;
                    TxtLocalidad.Text = usuario.Localidad;
                    TxtProvincia.Text = usuario.Provincia;


                    listaFormaEntrega = negocioFormEntrega.listar();
                    listaFormaEntrega.Insert(0, new FormaEntrega { Id = -1, Descripcion = "" });
                    ddlFormaEntrega.DataSource = listaFormaEntrega;
                    ddlFormaEntrega.DataTextField = "Descripcion";
                    ddlFormaEntrega.DataValueField = "Id";
                    ddlFormaEntrega.DataBind();

                    ddlFormaEntrega.SelectedIndex = -1;
                    //if (ddlFormaEntrega.SelectedIndex == 1)
                    //    delivery = true;


                    listaFormaPago = negocioFormPago.listar();
                    listaFormaPago.Insert(0, new FormaPago { Id = -1, Descripcion = "" });
                    ddlFormaPago.DataSource = listaFormaPago;
                    ddlFormaPago.DataTextField = "Descripcion";
                    ddlFormaPago.DataValueField = "Id";
                    ddlFormaPago.DataBind();

                    ddlFormaPago.SelectedIndex = -1;






                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}