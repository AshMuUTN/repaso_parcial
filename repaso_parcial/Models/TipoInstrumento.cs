using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace repaso_parcial.Models
{
    public class TipoInstrumento
    {
        public int Id { get; set; }
        [Required]
        public string Tipo { get; set; }
    }
}