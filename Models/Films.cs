using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Film
    {
        [Key]
        public int FilmID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nom { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public int Duree { get; set; }

        public string? Poster { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Foreign Key for Categories
        public int CategorieID { get; set; }
        [ForeignKey(nameof(CategorieID))]
        public virtual Category? Categories { get; set; }

        // Foreign Keys for Acteurs
        public int ActeurPID { get; set; }
        [ForeignKey(nameof(ActeurPID))]
        public virtual Acteur? ActeurP { get; set; }

        // Foreign Key for Editeurs
        public int EditeurID { get; set; }
        [ForeignKey(nameof(EditeurID))]
        public virtual Editeur? Editeur { get; set; }

        // Foreign Key for Langues
        public int LangueID { get; set; }
        [ForeignKey(nameof(LangueID))]
        public virtual Langue? Langues { get; set; }

        // Foreign Key for Realisateurs
        public int RealisateurID { get; set; }
        [ForeignKey(nameof(RealisateurID))]
        public virtual Realisateurs? Realisateur { get; set; }
    }
}
