using Actio.Common.Exceptions;
using Actio.Services.Activity.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Services.Activity.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;

        private readonly ICategoryRepository _categoryRepository;
        public ActivityService(IActivityRepository activityRepository,
            ICategoryRepository categoryRepository)
        {
            _activityRepository = activityRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task AddAsync(Guid id, string category, Guid userId, string name, string description, DateTime createdAt)
        {
            var activityCategory = await _categoryRepository.GetAsync(name);
            if (activityCategory == null)
            {
                throw new ActioException("category_not_found",
                    $"Category:'{category} was not found.");
            }
            var activity = new Domain.Models.Activity(id, activityCategory, userId,name,description,createdAt);
            await _activityRepository.AddAsync(activity);
        }
    }
}
