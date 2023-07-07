using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pedido
    {

        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public List<Album> Albums { get; set; }
        public int IdFormaEntrega { get; set; }

        public string FormaEntrega { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public int IdFormaPago { get; set; }

        public string FormaPago { get; set; }
        public decimal Total { get; set; }
        public int IdEstado { get; set; }

        public string Estado { get; set; }

        public DateTime FechaCreacion { get; set; }

    }
}
