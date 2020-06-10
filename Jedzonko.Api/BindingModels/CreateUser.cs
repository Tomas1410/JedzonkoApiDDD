using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jedzonko.Api.BindingModels
{
    public class CreateUser
    {
        [Required]
        [Display(Name = "nazwaUzytkownika")]

        public string NazwaUzytkownika { get; set; }
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "email")]
        public string Email { get; set; }




    }
}
