using FluentValidation;
using Jedzonko.IServices.Request;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Jedzonko.Api.Validation
{
    public class CreateUserValidator: AbstractValidator<CreateUser>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.UserName).NotNull();
            RuleFor(x => x.Email).NotNull().EmailAddress(); 
            RuleFor(x => x.Imie).NotNull();
            RuleFor(x => x.Nazwisko).NotNull();
            
        
        }

    }
}
