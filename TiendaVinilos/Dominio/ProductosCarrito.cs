using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ProductosCarrito
    {
        public List<Item> lista { set; get; }
        //Usamos esta funcion para cargar en total la suma de todos los precios de los item (precio* cant)
        public decimal totalCarrito(ProductosCarrito carrito)
        {
            decimal total = 0;
            foreach (Item item in carrito.lista)
            {

                total += Convert.ToDecimal(item.Producto.Precio * item.Cantidad);
            }
            return total;
        }
    }
}
