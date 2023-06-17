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
    public partial class Formulario : System.Web.UI.Page
    {
        GeneroNegocio genero = new GeneroNegocio();
        List<Genero> listaGenero = new List<Genero>();
        CategoriaNegocio categoria = new CategoriaNegocio();
        List<Categoria> listaCategoria = new List<Categoria>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    listaGenero = genero.listar();
                    ddlGenero.DataSource = listaGenero;
                    ddlGenero.DataTextField = "Descripcion";
                    ddlGenero.DataValueField = "Id";
                    ddlGenero.DataBind();
                    listaCategoria = categoria.listar();
                    ddlCategoria.DataSource = listaCategoria;
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();

                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Album nuevo = new Album();
                nuevo.Titulo = TxtTitulo.Text;
                nuevo.Artista = new Artista();
                nuevo.Artista.Nombre = TxtArtista.Text;
                //nuevo.FechaLanzamiento = TxtFechaLanza.Text;
                nuevo.ImgTapa = TxtImgTapa.Text;
                nuevo.ImgContratapa = TxtImgContraTapa.Text;
               // nuevo.Precio = 
                nuevo.Genero = new Genero();
                nuevo.Genero.Id = int.Parse(ddlGenero.SelectedValue);
                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}