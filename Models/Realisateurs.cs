using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Realisateurs
    {
        [Key]
        public int RealisateursID { get; set; }

        [Required(ErrorMessage = "Le nom du réalisateur est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères.")]
        [MinLength(1, ErrorMessage = "Le nom doit avoir au moins un caractère.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le prénom du réalisateur est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le prénom ne peut pas dépasser 100 caractères.")]
        [MinLength(1, ErrorMessage = "Le prénom doit avoir au moins un caractère.")]
        public string Prenom { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
