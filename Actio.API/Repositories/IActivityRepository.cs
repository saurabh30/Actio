using Actio.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.API.Repositories
{
     public interface IActivityRepository
    {
        Task<Activity> GetAsync(Guid guid);

        Task AddAsync(Activity model);

        Task<IEnumerable<Activity>> BrowseAsync(Guid id);
    }
}
