using FluentValidation;
using FluentValidation.AspNetCore;
using Jedzonko.IServices.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jedzonko.Api.Validation
{
    public class EditUserValidator:AbstractValidator<EditUser>
    {
        public EditUserValidator()
        {
            RuleFor(x => x.UserName).NotNull();
            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.Imie).NotNull();
            RuleFor(x => x.Nazwisko).NotNull();


            /*   public string UserName { get; set; }
            public string Email { get; set; }
            public string Imie { get; set; }
            public string Nazwisko { get; set; }*/
        }
    }
}
