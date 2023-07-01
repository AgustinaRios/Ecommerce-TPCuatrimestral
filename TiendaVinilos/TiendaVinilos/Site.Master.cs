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
    public partial class SiteMaster : MasterPage
    {

        public ProductosCarrito carrito = new ProductosCarrito();
        Album producto = new Album();
        AlbumNegocio negocio= new AlbumNegocio();   
        Item item = new Item();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page is Listar||Page is ListarUsuarios)
            {
                if (!Seguridad.esAdmin(Session["usuario"]))
                    Response.Redirect("Login.aspx", false);
            }
            if (Page is MiPerfil)
            {
                if (!Seguridad.sesionActiva(Session["usuario"]))
                    Response.Redirect("Login.aspx", false);
            }
            try
            {

                if (!IsPostBack)
                {
                    
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

        public void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Inicio.aspx", false);
        }
    }
}