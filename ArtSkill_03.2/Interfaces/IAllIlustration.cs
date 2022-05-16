using ArtSkill_03._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSkill_03._2.Interfaces
{
    public interface IAllIlustration
    {
        IEnumerable<IllustrationModel> illustrationModels { get; set; }
        IEnumerable<IllustrationModel> getIllustrationModels { get; set; }
        IllustrationModel getobjectIllustration(int Id);

    }
}
