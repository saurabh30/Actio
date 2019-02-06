using Actio.API.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;

namespace Actio.API.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IMongoDatabase _database;

        public ActivityRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task AddAsync(Activity model)
                => await Collection.InsertOneAsync(model);

        public async Task<IEnumerable<Activity>> BrowseAsync(Guid id)
                => await Collection
                        .AsQueryable()
                         .Where(x => x.Id == id)
                        .ToListAsync();

        public async Task<Activity> GetAsync(Guid id)
               => await Collection
                    .AsQueryable()
                    .FirstOrDefaultAsync(x => x.Id == id);

        private IMongoCollection<Activity> Collection
            => _database.GetCollection<Activity>("Activities");
     }
}
