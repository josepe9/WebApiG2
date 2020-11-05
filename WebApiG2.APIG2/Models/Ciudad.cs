using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiG2.APIG2.Models
{
    public class Ciudad
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string Nombre { get; set; }

        public int DeptoId { get; set; }

        public Depto Depto { get; set; }

        public ICollection<Persona> Personas { get; set; }
    }
}
