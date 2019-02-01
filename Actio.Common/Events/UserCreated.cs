
namespace Actio.Common.Events
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UserCreated : IEvent
    {
        public string Email { get;}

        public string Name { get;}

        //for serializer
        protected UserCreated()
        {
        }

        public UserCreated(string email, string name)
        {
            Email = email;
            Name = name;
        }
    }
}
