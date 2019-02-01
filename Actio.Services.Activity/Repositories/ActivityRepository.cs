using Actio.Services.Activity.Domain.Models;
using Actio.Services.Activity.Domain.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
namespace Actio.Services.Activity.Repositories
{

    public class ActivityRepository : IActivityRepository
    {
        private readonly IMongoDatabase _database;

        public ActivityRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task AddAsync(Domain.Models.Activity activity)
           => await Collection.InsertOneAsync(activity);

        public async Task<IEnumerable<Domain.Models.Activity>> BrowseAsync()
            => await Collection
                .AsQueryable()
                .ToListAsync();

        public async Task<Domain.Models.Activity> GetAsync(Guid id)
               => await Collection
                    .AsQueryable()
                    .FirstOrDefaultAsync(x => x.Id == id);

        private IMongoCollection<Domain.Models.Activity> Collection
            => _database.GetCollection<Domain.Models.Activity>("Activities");
    }
}
