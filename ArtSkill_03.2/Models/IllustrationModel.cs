using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtSkill_03._2.Models
{
    public class IllustrationModel
    {
        [Required]
        public Guid Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        [StringLength(150, MinimumLength = 5)]
        [Required]
        public string shortDesc { get; set; }
        [StringLength(500, MinimumLength = 5)]
        [Required]
        public string longDesc { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]

        [Required]
        public virtual Category Category { get; set; }

        public virtual UserModels UserModel { get; set; }
        public virtual string imgProduct { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

    }
}

        
 