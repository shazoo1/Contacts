using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Common.Enums
{
    public enum Genders
    {
        [Display(Name ="Не выбран")]
        NotGiven,
        [Display(Name ="Мужской")]
        Male,
        [Display(Name="Женский")]
        Female
    }
}
