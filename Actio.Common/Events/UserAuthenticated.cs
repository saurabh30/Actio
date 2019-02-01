
namespace Actio.Common.Events
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserAuthenticated : IEvent
    {
        public string Email { get;}

        //for serializer
        protected UserAuthenticated()
        {
        }

        public UserAuthenticated(string email)
        {
            Email = email;
        }

    }
}
