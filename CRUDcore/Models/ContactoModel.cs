using System.ComponentModel.DataAnnotations;

namespace CRUDcore.Models
{
    public class ContactoModel
    {
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Required]
        public string? Telefono { get; set; }

        [Required]
        public string? Correo { get; set; }

    }
}
