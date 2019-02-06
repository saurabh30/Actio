
namespace Actio.Common.Auth
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class JsonWebToken
    {
        public string Token { get; set; }

        public long Expires { get; set; }
    }
}
