using System.ComponentModel.DataAnnotations;

namespace ArtSkill_03._2.Domain.Entities
{
    public class TextField : EntityBase
    {
        [Required]
        public string CodeWord { get; set; }

        [Display(Name = "Название (заголовок)")]
        public override string Title { get; set; } = "Информационная строка";

        [Display(Name = "Описание")]
        public override string Text { get; set; } = "Содержание заполняется продавцом";

    }
}
