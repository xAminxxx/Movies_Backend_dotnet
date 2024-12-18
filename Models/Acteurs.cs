using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Acteur
    {
        [Key]
        public int Id { get; set; } 

        [Required(ErrorMessage = "Nom de l'acteur est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le nom ne peut pas dépasser 50 caractères.")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Prénom de l'acteur est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le prénom ne peut pas dépasser 50 caractères.")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Nationalité de l'acteur est obligatoire.")]
        [StringLength(50, ErrorMessage = "La nationalité ne peut pas dépasser 50 caractères.")]
        public string Nationalite { get; set; }

        [Required(ErrorMessage = "Date de naissance de l'acteur est obligatoire.")]
        [DataType(DataType.Date, ErrorMessage = "Veuillez fournir une date valide.")]
        public DateTime DateNaissance { get; set; }

        [Required(ErrorMessage = "Photo de profil obligatoire.")]
        [StringLength(255, ErrorMessage = "Le chemin ou l'URL de la photo de profil ne peut pas dépasser 255 caractères.")]
        public string ProfilePicture { get; set; } 

        [Required(ErrorMessage = "Biographie obligatoire.")]
        [StringLength(2000, ErrorMessage = "La biographie ne peut pas dépasser 2000 caractères.")]
        public string Biography { get; set; } 
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now; 
    }
}
