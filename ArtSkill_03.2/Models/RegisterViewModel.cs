        using System.ComponentModel.DataAnnotations;


namespace ArtSkill_03._2.Models
{
    public class RegisterViewModel
    {
            [Required(ErrorMessage = "Не указан Email")]
        [Display(Name = "Электроная почта")]
        public string Email { get; set; }

            [Required(ErrorMessage ="Имя не указано")]
        [Display(Name = "Логин")]
        public string userName { get; set; }

            [Required(ErrorMessage = "Не указан пароль")]
            [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string userPassword { get; set; }

            [DataType(DataType.Password)]
        [Display(Name = "Повторите пароль")]
        [Compare("userPassword", ErrorMessage = "Пароль введен неверно")]
            public string ConfirmPassword { get; set; }
        
    }
}
