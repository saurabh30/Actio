﻿
namespace Actio.API.Tests.Unit.Controllers
{
    using Actio.API.Controllers;
    using FluentAssertions;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using Xunit;

    public class HomeControllerTests
    {
        [Fact]
        public void home_controller_get_should_return_string_content()
        {
            //Arrange 
            var controller = new HomeController();
            
            // Act
            var result = controller.Get();

            //Assert
            var contentResult = result as ContentResult;
            contentResult.Should().NotBeNull();
            contentResult.Content.Should().BeEquivalentTo("Hello from Actio API!!");


        }
    }
}
