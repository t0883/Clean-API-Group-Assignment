using Application.Commands.Users.UpdateUser;
using Application.Dtos;
using Domain.Models.Users;
using FakeItEasy;
using Infrastructure.Repository.Users;
namespace Test.UserTests.CommandTests
{
    [TestFixture]
    internal class UpdateUserTests
    {
        [Test]
        public async Task Update_User_Should_Return_User_With_Username_test()
        {

            //Arrange
            UserDto userDto = new UserDto { Email = "test@test.com", Password = "password", Username = "Test" };

            var fakeRepository = A.Fake<IUserRepository>();

            var command = new UpdateUserCommand(userDto);

            var commandHandler = new UpdateUserCommandHandler(fakeRepository);

            A.CallTo(() => fakeRepository.UpdateUser(A<User>._)).Returns(new User { Email = "test@test.com", Password = "password", Username = "test", UserId = Guid.NewGuid() });

            //Act

            var result = await commandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Username.Equals("test"));
            Assert.That(result.GetType(), Is.EqualTo(typeof(User)));
        }
    }
}
