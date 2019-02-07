
namespace Actio.Services.Identity.Tests.Unit
{
    using Actio.Common.Auth;
    using Actio.Services.Identity.Domain.Models;
    using Actio.Services.Identity.Domain.Repositories;
    using Actio.Services.Identity.Domain.Services;
    using Actio.Services.Identity.Services;
    using FluentAssertions;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class UserServiceTest
    {
        [Fact]
        public async Task user_service_login_should_return_jwt()
        {
            var email = "email";
            var name = "test";
            var salt = "salt";
            var password = "secret";
            var hash = "hash";
            var token = "token";
            var userRepository = new Mock<IUserRepository>();
            var encryptor = new Mock<IEncrypter>();
            var jwtHandler = new Mock<IJwtHandler>();

            encryptor.Setup(x => x.GetSalt()).Returns(salt);
            encryptor.Setup(x => x.GetHash(password,salt)).Returns(hash);

            jwtHandler.Setup(x => x.Create(It.IsAny<Guid>())).Returns(new JsonWebToken()
            {
                Token = token
            });

            var user = new User(email, name);
            user.SetPassword(password, encryptor.Object);
            userRepository.Setup(x => x.GetAsync(email)).ReturnsAsync(user);

            var userService = new UserService(userRepository.Object, encryptor.Object, jwtHandler.Object);

            var jwt = await userService.LoginAsync(email, password);
            userRepository.Verify(x => x.GetAsync(email),Times.Once);
            jwtHandler.Verify(x => x.Create(It.IsAny<Guid>()), Times.Once);
            jwt.Should().NotBeNull();
            jwt.Token.Should().BeEquivalentTo(token);
        }
    }
}
