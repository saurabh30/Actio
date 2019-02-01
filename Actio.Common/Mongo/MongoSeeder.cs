﻿
namespace Actio.Common.Mongo
{
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MongoSeeder : IDatabaseSeeder
    {
        protected readonly IMongoDatabase _database;

        public MongoSeeder(IMongoDatabase database)
        {
            _database = database;
        }
        public async Task SeedAsync()
        {
                var collectionCursor = await _database.ListCollectionsAsync();
                var collections = await collectionCursor.ToListAsync();
                if (collections.Any())
                {
                    return;
                }
                await CustomSeedAsync();
        }

        protected virtual async Task CustomSeedAsync()
        {
            await Task.CompletedTask;
        }
    }
}
