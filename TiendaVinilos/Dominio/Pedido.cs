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
        public string Direccion { get; set; }
        public int IdFormaPago { get; set; }
        public decimal SubTotal { get; set; }
        public int IdEstado { get; set; }

        public DateTime FechaCreacion { get; set; }


    }
}
