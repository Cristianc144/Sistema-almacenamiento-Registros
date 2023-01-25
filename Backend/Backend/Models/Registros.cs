using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Registros
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nombres { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Apellidos { get; set; }

        [Required]
        [Column(TypeName = "varchar(3)")]
        public string Edad { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Titulo { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Ciudad { get; set; }
    }
}
