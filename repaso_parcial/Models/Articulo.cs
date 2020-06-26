using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace repaso_parcial.Models
{
    public class Articulo
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public double Precio { get; set; }
        [Required]
        public int Tipo { get; set; }
    }
}