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
        public decimal Precio { get; set; }
        [RegularExpression(@"^-?[0-9][0-9,]+$",ErrorMessage ="Número inválido.")]
        [Required]
        public string PrecioString { get; set; }
        [Required]
        public int Tipo { get; set; }

        // public int Active { get; set; }
    }
}