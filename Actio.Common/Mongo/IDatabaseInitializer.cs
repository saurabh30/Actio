
namespace Actio.Common.Mongo
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDatabaseInitializer
    {
        Task InitializeAsync();
    }
}
