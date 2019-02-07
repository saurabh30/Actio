
namespace Actio.Services.Activities.Test.Unit.Services
{
    using Actio.Services.Activity.Domain.Models;
    using Actio.Services.Activity.Domain.Repositories;
    using Actio.Services.Activity.Services;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class ActivityServiceTest
    {
        [Fact]
        public async Task activity_service_add_async_should_succeed()
        {
            var category = "test";
            var activityRepository = new Mock<IActivityRepository>();
            var categoryRepository = new Mock<ICategoryRepository>();
            categoryRepository.Setup(x => x.GetAsync(category))
                .ReturnsAsync(new Category(category));

            var activityService = new ActivityService(activityRepository.Object, categoryRepository.Object);

            var id = Guid.NewGuid();

            await activityService.AddAsync(id, Guid.NewGuid(), category, "activity", "description", DateTime.UtcNow);
            categoryRepository.Verify(x => x.GetAsync(category), Times.Once);
            activityRepository.Verify(x => x.AddAsync(It.IsAny<Activity>()), Times.Once);
        }
    }
}
