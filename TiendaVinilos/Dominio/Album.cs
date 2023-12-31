﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Album
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public Artista Artista { get; set; }
        public string FechaLanzamiento { get; set; }
        public string ImgTapa { get; set; }
        public string ImgContratapa { get; set; }

        public decimal Precio { get; set; }
        public Genero Genero { get; set; }
        public Categoria Categoria { get; set; }

        public bool Activo { get; set; }
    }
}
