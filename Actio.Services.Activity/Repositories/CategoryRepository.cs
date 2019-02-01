﻿using Actio.Services.Activity.Domain.Models;
using Actio.Services.Activity.Domain.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
namespace Actio.Services.Activity.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoDatabase _database;

        public CategoryRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async  Task AddAsync(Category category)
           => await Collection.InsertOneAsync(category);

        public async  Task<IEnumerable<Category>> BrowseAsync()
            => await Collection
                .AsQueryable()
                .ToListAsync();

        public async Task<Category> GetAsync(string name)
               => await Collection
                    .AsQueryable()
                    .FirstOrDefaultAsync(x => x.Name == name.ToLowerInvariant());

        private IMongoCollection<Category> Collection
            => _database.GetCollection<Category>("Categories");
    }
}
