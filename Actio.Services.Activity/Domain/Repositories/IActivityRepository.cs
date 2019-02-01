using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Services.Activity.Domain.Repositories
{
    public interface IActivityRepository
    {
        Task<Models.Activity> GetAsync(Guid id);

        Task AddAsync(Models.Activity activity);
    }
}
