using ArtSkill_03._2.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtSkill_03._2.Models
{
    [NotMapped]
    public class UserModels: IdentityUser
    {       
            public override string Id { get; set; }
            public  string Name { get; set; }
            public override string Email { get; set; }
            public string Password { get; set; }

            //public List<IllustrationModel> ilustrations { get; set; }

    }
}
