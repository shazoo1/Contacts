using Contacts.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Contacts.Web.Models
{
    public class FullPersonInfoModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Это поле обязательно к заполнению")]
        [MaxLength(100, ErrorMessage ="Длина имени не должна превышать 100 символов")]
        public string FirstName { get; set; }

        [Display(Name = "Отчество")]
        [Required(ErrorMessage = "Это поле обязательно к заполнению")]
        [MaxLength(100, ErrorMessage = "Длина отчество не должна превышать 100 символов")]
        public string MiddleName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Это поле обязательно к заполнению")]
        [MaxLength(100, ErrorMessage = "Длина фамилии не должна превышать 100 символов")]
        public string LastName { get; set; }

        [Display(Name = "E-Mail")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите E-Mail")]
        [EmailAddress(ErrorMessage ="Введите верный E-Mail")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите номер телефона")]
        [Display(Name = "Номер телефона")]
        [Phone(ErrorMessage = "Номер телефона неверен")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Пол")]
        public Genders Gender { get; set; }

        [Display(Name = "ИНН")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Введите ИНН")]
        [StringLength(12, ErrorMessage = "ИНН должен содержать 10 или 12 цифр", MinimumLength = 10)]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Строка должна содержать только цифры")]
        public string Inn { get; set; }

        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Введите дату рождения")]
        public DateTime BirthDate { get; set; }
    }
}