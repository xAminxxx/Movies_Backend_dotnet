using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Langue
    {
        [Key]
        public int LangueID { get; set; }

        [Required(ErrorMessage = "Le nom de la langue est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le nom de la langue ne peut pas dépasser 100 caractères.")]
        [MinLength(1, ErrorMessage = "Le nom de la langue doit avoir au moins un caractère.")]
        public string Nom { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
