// Copyright © DISA Global Solutions, Inc. All Rights Reserved.

namespace Actio.Common.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CreateActivity : IAuthenticatedCommand
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Category { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
