using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre es requerido")]
        [MaxLength(length: 50)]
        public string Nombre { get; set; }
        [MaxLength(length: 100)]
        public string Descripcion { get; set; }
        public int? RestriccionEdad { get; set; }
        [Required(ErrorMessage = "Compañia es requerida")]
        public string Compania { get; set; }
        [Required(ErrorMessage = "Precio es requerido")]
        public decimal Precio { get; set; }
    }
}
