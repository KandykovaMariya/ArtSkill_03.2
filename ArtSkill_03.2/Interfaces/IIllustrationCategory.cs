
using ArtSkill_03._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSkill_03._2.Interfaces
{
    public interface IIllustrationCategory
    {
        IEnumerable<Category> categories { get; }
    }
}
