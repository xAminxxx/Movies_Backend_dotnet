using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Editeur
    {
        [Key]
        public int EditeurID { get; set; }

        [Required(ErrorMessage = "Le nom de l'éditeur est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères.")]
        public string Nom { get; set; }

        [StringLength(255, ErrorMessage = "L'adresse de l'éditeur ne peut pas dépasser 255 caractères.")]
        public string? Adresse { get; set; }

        [StringLength(100, ErrorMessage = "L'email de l'éditeur ne peut pas dépasser 100 caractères.")]
        [EmailAddress(ErrorMessage = "Veuillez fournir un email valide.")]
        public string? Email { get; set; }

        [StringLength(50, ErrorMessage = "Le numéro de téléphone de l'éditeur ne peut pas dépasser 50 caractères.")]
        public string? Telephone { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
