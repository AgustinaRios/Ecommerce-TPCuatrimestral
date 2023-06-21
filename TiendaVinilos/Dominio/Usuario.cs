﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoUsuario
    {
        NORMAL = 1,
        ADMIN = 2
    }
    public class Usuario
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }

        public DatosPersonales Datos { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
