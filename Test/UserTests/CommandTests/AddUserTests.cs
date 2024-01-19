using API.Controllers.UsersController;
using Application.Commands.Users.AddUser;
using Application.Dtos;
using Domain.Models.Users;
using FakeItEasy;
using Infrastructure.Repository.Users;
using Microsoft.AspNetCore.Mvc;

namespace Test.UserTests.CommandTests
{
    [TestFixture]
    internal class AddUserTests
    {
        [Test]
        public async Task Add_User_Should_Return_Ok_Response()
        {
            //Arrange

            UserDto userDto = new UserDto { Username = "test", Email = "test@test.com", Password = "Lösenord" };

            var fakeMediator = A.Fake<MediatR.IMediator>();

            //var mediator = new IMediator<IMediator>();

            var controller = new UsersController(fakeMediator);

            //Act

            var result = await controller.AddUser(userDto);

            //Assert

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task Add_User_Should_Return_User_With_Username_test()
        {
            //Arrange

            UserDto userDto = new UserDto { Username = "test", Email = "test@test.com", Password = "Lösenord" };

            var fakeRepository = A.Fake<IUserRepository>();

            var command = new AddUserCommand(userDto);

            var commandHandler = new AddUserCommandHandler(fakeRepository);

            A.CallTo(() => fakeRepository.AddUser(A<User>._)).Returns(new User { UserId = Guid.NewGuid(), Username = userDto.Username, Email = userDto.Email, Password = userDto.Password });

            //Act

            var result = await commandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Username.Equals("test"));
            Assert.That(result, Is.TypeOf<User>());

        }
    }
}
