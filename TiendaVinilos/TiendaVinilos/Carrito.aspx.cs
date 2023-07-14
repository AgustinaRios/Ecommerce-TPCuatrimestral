using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Microsoft.Ajax.Utilities;
using Negocio;
namespace TiendaVinilos
{
    public partial class Carrito : System.Web.UI.Page
    {

        public ProductosCarrito carrito = new ProductosCarrito();
        Album producto = new Album();
        Item item = new Item();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

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
                // el repetidor va a mostrar este lista que se carga de 2 maneras.
                // 1) viene desde el menu, muestra la lista como esta.
                //2) viene desde el menu pero previo se clickeo una o mas veces el boton carrito de cualquier album entonces carga una nuevo item a la lista y luego la muestra.
                repetidorCarrito.DataSource = carrito.lista;
                repetidorCarrito.DataBind();

                lblTotal.Text = carrito.totalCarrito(carrito).ToString();

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }

        }

        protected void BtnComprar_Click(object sender, EventArgs e)
        {
            Session.Add("VienedeCarrito", 1);
            if (!Seguridad.sesionActiva(Session["usuario"]))
            { 
                Response.Redirect("Login.aspx", false);
                
            }
            else
            {
                if (carrito.lista.Count == 0)
                {
                    // Mostrar un mensaje indicando que el carrito está vacío
                    Label2.Visible = true;
                    Label2.Text = "No tiene productos seleccionados";
                    BtnComprar.Visible = false;
                }
                else
                {
                    
                      Response.Redirect("FormularioCompra.aspx", false);
                    
                    
                }

            }

        }

        protected void lblTotal_Load(object sender, EventArgs e)
        {

        }

        protected void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var cantidad = ((TextBox)sender).Text;

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                var cantidadTextBox = ((Button)sender).Parent.FindControl("txtCantidad") as TextBox;
                var cantidad = cantidadTextBox.Text;
                if (!string.IsNullOrEmpty(cantidad))
                {
                    var argument = ((Button)sender).CommandArgument;
                    carrito = (ProductosCarrito)Session["carrito"];
                    Item item1 = carrito.lista.Find(x => x.Producto.Id.ToString() == argument);
                    item1.Cantidad = int.Parse(cantidad);
                    Session["carrito"] = carrito;
                    repetidorCarrito.DataSource = carrito.lista;
                    repetidorCarrito.DataBind();
                    lblTotal.Text = carrito.totalCarrito(carrito).ToString();
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var argument = ((Button)sender).CommandArgument;
                carrito = (ProductosCarrito)Session["carrito"];
                Item item1 = carrito.lista.Find(x => x.Producto.Id.ToString() == argument);
                carrito.lista.Remove(item1);
                Session["carrito"] = carrito;

                repetidorCarrito.DataSource = carrito.lista;
                repetidorCarrito.DataBind();
                lblTotal.Text = carrito.totalCarrito(carrito).ToString();

                // Actualizar el valor de "ItemCount" en la sesión
                int itemCount = carrito.lista.Sum(x => x.Cantidad);
                Session["ItemCount"] = itemCount.ToString();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}