
namespace Actio.API.Tests.Unit.Controllers
{
    using Actio.API.Controllers;
    using Actio.API.Repositories;
    using Actio.Common.Commands;
    using FluentAssertions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using RawRabbit;
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class ActivitiesControllerTest
    {
        [Fact]
        public async Task activities_controller_post_should_return_accepted()
        {
            var busClient = new Mock<IBusClient>();
            var activityRepository = new Mock<IActivityRepository>();
            var controller = new ActivitiesController(busClient.Object, activityRepository.Object);

            var userId = Guid.NewGuid();
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new System.Security.Claims.ClaimsPrincipal(new ClaimsIdentity(
                        new Claim[] { new Claim(ClaimTypes.Name, userId.ToString()) }
                        , "test"))
                }
            };

            var command = new CreateActivity
            {
                Id = new Guid(),
                UserId  = userId
            };

            var result = await controller.Post(command);

            var contentResult = result as AcceptedResult;
            contentResult.Should().NotBeNull();
            contentResult.Location.Should().BeEquivalentTo($"activities/{command.Id}");
        }
    }
}
