using System;
using System.Collections.Generic;
using System.Text;

namespace Jedzonko.Domain.DomainExceptions
{
    public class LackOfUserNameException :Exception
    {
        public LackOfUserNameException(string username):base(ExceptionMessage(username))
        {

        }
        private static string ExceptionMessage(string username)
        {
            return $"Lack of username. Username: {username.GetTypeCode()}.";
        }

    }
}
