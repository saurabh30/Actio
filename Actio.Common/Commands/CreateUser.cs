﻿namespace Actio.Common.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CreateUser : ICommand
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }
    }
}
