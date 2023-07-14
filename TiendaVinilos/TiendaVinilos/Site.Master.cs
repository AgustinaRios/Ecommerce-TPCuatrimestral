using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;


namespace TiendaVinilos
{
    public partial class SiteMaster : MasterPage
    {

        public ProductosCarrito carrito = new ProductosCarrito();
        Album producto = new Album();
        GeneroNegocio generonegocio = new GeneroNegocio();
        CategoriaNegocio negocioCategoria = new CategoriaNegocio();
        Item item = new Item();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!(Page is Inicio || Page is AlbumFiltrado || Page is Carrito
                 || Page is Detalle || Page is MiPerfil || Page is MisCompras
                 || Page is Login || Page is error || Page is Contact || Page is Domicilio
                 || Page is RegistrarCuenta || Page is FormularioCompra || Page is ConfirmacionCompra 
                 || Page is AlbumsxGenero|| Page is AlbumsxCategoria))
            {
                if (!Seguridad.esAdmin(Session["usuario"]))
                {
                    Session.Add("error", "No tiene permisos para ingresar a esta pantalla");
                    Response.Redirect("error.aspx");

                }
            }
            if (Page is MiPerfil || Page is MisCompras)
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                    Response.Redirect("Login.aspx", false);
            }
            try
            {

                if (!IsPostBack)
                {


                    List<Genero> listaGenero = generonegocio.listar();
                    List<Categoria> listaCategoria = negocioCategoria.listar();

                    // Agregar un elemento adicional al inicio de la lista
                    listaGenero.Insert(0, new Genero { Id = -1, Descripcion = "" });
                    listaCategoria.Insert(0, new Categoria { Id = -1, Descripcion = "" });

                    Session["listaGenero"] = listaGenero;
                    ddlGenero.DataSource = listaGenero;
                    ddlGenero.DataTextField = "Descripcion";
                    ddlGenero.DataValueField = "ID";
                    ddlGenero.DataBind();

                    Session["listaCategoria"] = listaCategoria;
                    ddlCategoria.DataSource = listaCategoria;
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "ID";
                    ddlCategoria.DataBind();

                    // Establecer el elemento predeterminado
                    ddlGenero.SelectedIndex = -1;
                    ddlCategoria.SelectedIndex = -1;

                    ////cuando se carga x 1era vez el menu entra aca y carga a la session un 0( el carrito esta vacio)
                    if (Session["ItemCount"] == null)
                    {
                        Session["ItemCount"] = 0;
                    }
                }

                //cuando se carga x 1era vez el menu entra aca y carga a la session un 0( el carrito esta vacio)
                string id = Convert.ToString(Session["idArtCarrito"]);
                carrito = (ProductosCarrito)Session["carrito"];// aca asigno a la lista llamada "carrito" la session para trabajar mas adelante ,
                if (carrito == null) carrito = new ProductosCarrito();// cuando carrito que es  una lista no este creada ,aca se va a crear por primera vez.
                if (carrito.lista == null) carrito.lista = new List<Item>();// cuando la lista este vacia vamos a crear un item para que no pinche por ser nula.

                if (id != "")
                {
                    Item item = carrito.lista.Find(x => x.Producto.Id.ToString() == id);//a item le cargo el  item de la lista carrito siempre que coincida con el id que me traigo x session
                    if (item == null)// entra cuando es un nuevo item en la lista
                    {
                        List<Album> listado = (List<Album>)Session["Listaalbum"];
                        producto = listado.Find(x => x.Id.ToString() == id);
                        item = new Item(); // Crear una nueva instancia de Item para luego agregar un nuevo registro a la lista "carrito" 
                        item.SubTotal = Convert.ToDecimal(producto.Precio);
                        item.Producto = producto;
                        item.Cantidad = 1;
                        carrito.lista.Add(item);
                        //en estas 7 lineas cargo una lista con  session "Listaalbum" para crear un nuevo item a la "listacarrito" 
                    }
                    else
                    {
                        //Aca entra si el item ya existe en la lista y solo se le agrega mas cantidades del mismo producto.
                        item.Cantidad++;
                        Session["carrito"] = carrito;//Esto es lo mismo que decir Session.add("carrito",carrito).
                    }
                    Session["idArtCarrito"] = ""; // Reiniciar el ID de artículo en la sesión
                    Session["carrito"] = carrito;//Esto es lo mismo que decir Session.add("carrito",carrito).
                }
                string a = Convert.ToString(Session["items"]); // puede estar vacia o nula o puede tner siempre un "1" asignado en btncarrito en  la pag inicio.
                if (string.IsNullOrEmpty(a))
                {
                    Session["a"] = 0; // entra cuando la session "items" viene vacia (nunca se dio clck en btncarrito.
                }
                else//entra cuando se clickeo al menos una vez en algun btnCarrito por lo items viene con un valor"1".
                {
                    int c = Convert.ToInt32(Session["items"]);
                    int d = Convert.ToInt32(Session["a"]);// en "d" se guarda la session "a" , "a" va a tner acumulado la cantidad de click en los BtnCarritos.
                    int cantItems = c + d; // se le suma 1 click a "d" y se lo guarda en "cantItems"


                    if (c > 0)// "c" va a ser mayor cuando se halla hecho un click al menos en algun BtnCarrito.
                    {
                        if (Session["ItemCount"] != null)// el menu del site.master se cargo una primera vez ya. 
                        {
                            int itemCount;
                            if (int.TryParse(Session["ItemCount"].ToString(), out itemCount))
                            {
                                itemCount += c;//sumo 1
                                Session["ItemCount"] = itemCount;//a  "ItemCount" le asigno lo que tenga  itemCount .
                            }
                            else
                            {
                                // Manejo del error de conversión
                            }
                        }
                        else
                        {
                            Session["ItemCount"] = c;// se le asigna 0. entro desde el menu sin click en algun Btncarrito.
                        }
                        Session["items"] = 0;//lo pongo en 0 si siempre me suma de a 1,
                    }
                    // ItemCount son los items cargados en el carrito 
                    LblItems.Text = Session["ItemCount"].ToString();
                    Session["a"] = cantItems;//a la session le asigno lo que tenga cantItems.

                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                throw;
            }
        }
        protected void ddlGenero_SelectedIndexChanged(object sender, EventArgs e)
        {

            int id = int.Parse(ddlGenero.SelectedValue);
            if (id > 0)
            {
                Response.Redirect("AlbumsxGenero.aspx?IdGenero=" + id, false);
            }

        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(ddlCategoria.SelectedValue);
            if (id > 0)
            {
                Response.Redirect("AlbumsxCategoria.aspx?IdCategoria=" + id, false);
            }
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {

            Session.Remove("listaFiltrada");
            Session.Remove("ListarUsuarios");
            Session.Remove("listaArtista");
            Session.Remove("listaCompras");

            List<Album> listaFiltrada = new List<Album>();
            AlbumNegocio negocio = new AlbumNegocio();
            string buscar = txtFiltro.Text;


            if (buscar != "")
            {
                listaFiltrada = negocio.listaFiltrada(buscar);
            }
            else
            {
                listaFiltrada = negocio.listar();
            }

            // Guardar la lista actualizada en la sesión
            Session["listaFiltrada"] = listaFiltrada;

            if (Page is Listar)
            {
                Response.Redirect("Listar.aspx", false);
            }
            else if (Page is ListarUsuarios)
            {
                List<Usuario> listaUsuarios = new List<Usuario>();
                UsuarioNegocio negocioUsuario = new UsuarioNegocio();
                listaUsuarios = negocioUsuario.listar(buscar);
                Session["ListarUsuarios"] = listaUsuarios;
                Response.Redirect("ListarUsuarios.aspx", false);
            }
            else if (Page is Artistas)
            {
                List<Artista> listaArtista = new List<Artista>();
                ArtistaNegocio artistaNegocio = new ArtistaNegocio();
                listaArtista = artistaNegocio.listar(buscar);
                Session["listaArtista"] = listaArtista;
                Response.Redirect("Artistas.aspx", false);
            }
            else if (Page is ComprasUsuarios) // "ComprasUsuarios.aspx"
            {
                string filtroBusqueda = txtFiltro.Text.Trim();
                Session["listaCompras"] = null; // Limpia la sesión anterior si la hubiera
                Response.Redirect("ComprasUsuarios.aspx?buscar=" + filtroBusqueda, false);
            }
            else
            {
                // Redireccionar a la página de inicio
                Response.Redirect("AlbumFiltrado.aspx", false);
            }
        }



        public void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Inicio.aspx", false);
        }
    }
}