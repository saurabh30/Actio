// Copyright © DISA Global Solutions, Inc. All Rights Reserved.

namespace Actio.Common.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AuthenticateUser : ICommand
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
