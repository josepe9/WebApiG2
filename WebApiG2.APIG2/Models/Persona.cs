using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiG2.APIG2.Models
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Documento { get; set; }

        [Required]
        [StringLength(45)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(45)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        public int CiudadID { get; set; }

        [StringLength(45)]
        public string Email { get; set; }

        [StringLength(20)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime Fechanac { get; set; }

        public Ciudad Ciudad { get; set; }
    }
}
