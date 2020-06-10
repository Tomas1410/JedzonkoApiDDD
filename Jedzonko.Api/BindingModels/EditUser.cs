using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jedzonko.Api.BindingModels
{
    public class EditUser
    {
        [Display(Name = "Username")]
        public string NazwaUzytkownika { get; set; }

        [Display(Name = "Imie")]
        public string Imie { get; set; }

        [Display(Name = "Nazwisko")]
        public string Nazwisko { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }



        public class EditUserValidator : AbstractValidator<EditUser>
        {
            public EditUserValidator()
            {
                RuleFor(x => x.NazwaUzytkownika).NotNull();
                RuleFor(x => x.Imie).NotNull();
                RuleFor(x => x.Nazwisko).NotNull();
                RuleFor(x => x.Email).NotNull();

            }
        }
    }
}
