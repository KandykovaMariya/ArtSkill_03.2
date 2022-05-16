using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using   System.Linq;
using System.Threading.Tasks;

namespace ArtSkill_03._2.Models
{
    public class Category
    {
       
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Desc { get; set; }
        public List<IllustrationModel> ilustrations { get; set; }
    }
}
