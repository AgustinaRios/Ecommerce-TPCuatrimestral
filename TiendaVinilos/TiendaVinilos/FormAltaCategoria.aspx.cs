using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
namespace TiendaVinilos
{
    public partial class FormAltaCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Categoria categoria = new Categoria();
            CategoriaNegocio negocio = new CategoriaNegocio();
            try
            {
                LblNombre.Text = "Alta Categoria";

                if (!IsPostBack)
                {
                    string Id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";

                    if (Id != "")

                    {
                        int IdCategoria = int.Parse(Id);
                        categoria = negocio.ObtenerPorId(IdCategoria);

                        TxtDescripcion.Text = categoria.Descripcion.ToString();
                        LblNombre.Text = "Modificar Categoria";

                    }


                }

            }


            catch (Exception ex)
            {
                throw ex;
            }




        }

        bool ValidarVacios()
        {
            TxtDescripcion.BorderColor = Color.White;
            bool vacios = false;
            if (TxtDescripcion.Text == "")
            {
                TxtDescripcion.BorderColor = Color.Red;
                LblMensaje.Text = "Complete el campo...";
                LblMensaje.Visible = true;
                vacios = true;
            }



            return vacios;
        }
        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria nuevo = new Categoria();
                Categoria modificar = new Categoria();
                CategoriaNegocio negocio = new CategoriaNegocio();

                string Id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";

                if (Id != "")

                {
                    int IdCategoria = int.Parse(Id);
                    modificar = negocio.ObtenerPorId(IdCategoria);
                    modificar.Descripcion = TxtDescripcion.Text;
                    negocio.modificar(modificar);
                    LblMensaje.Text = "Categoria modificada exitosamente";
                    LblMensaje.Visible = true;
                    Response.Redirect("Categorias.aspx", false);

                }
                else
                {
                    if (ValidarVacios() == false)
                    {
                        nuevo.Descripcion = TxtDescripcion.Text;
                        negocio.agregar(nuevo);
                        LblMensaje.Text = "Categoría agregada exitosamente";
                        LblMensaje.Visible = true;

                        string paginaAnterior = Session["PaginaAnterior"] as string;
                        if (!string.IsNullOrEmpty(paginaAnterior))
                        {
                            Response.Redirect(paginaAnterior, false);
                        }
                    }
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
            string paginaAnterior = Session["PaginaAnterior"] as string;
            if (!string.IsNullOrEmpty(paginaAnterior))
                Response.Redirect(paginaAnterior, false);
            else
                Response.Redirect("Categorias.aspx", false);
        }
    }
}