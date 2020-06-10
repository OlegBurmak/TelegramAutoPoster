using System.ComponentModel.DataAnnotations;

namespace TAPoster.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Не указан Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password  { get; set; }

        [Required(ErrorMessage = "Пароль не совпадает")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

    }
}