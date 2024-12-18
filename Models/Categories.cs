using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Category
    {
        [Key]
        public int CategorieID { get; set; }

        [Required(ErrorMessage = "Le nom de la catégorie est obligatoire.")]
        [StringLength(50, ErrorMessage = "Le nom de la catégorie ne peut pas dépasser 50 caractères.")]
        [MinLength(1, ErrorMessage = "La catégorie doit avoir au moins un caractère.")]
        public string Nom { get; set; } // Following PascalCase for consistency
    }
}
