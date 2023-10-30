using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUDcore.Models
{
    public class ContactoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "El campo Correo es obligatorio")]
        public string? Correo { get; set; }

    }
}
