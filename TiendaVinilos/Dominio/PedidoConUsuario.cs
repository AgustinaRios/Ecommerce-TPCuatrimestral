using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PedidoConUsuario
    {
        public Pedido Pedido { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }

    }

}
