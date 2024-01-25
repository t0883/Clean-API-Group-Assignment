using Application.Commands.Users.DeleteUser;
using Application.Dtos;
using Domain.Models.Users;
using FakeItEasy;
using Infrastructure.Repository.Users;

namespace Test.UserTests.CommandTests
{

    [TestFixture]
    internal class DeleteUserTests
    {
        [Test]
        public async Task Should_Delete_User_With_Useremail_testattestdotcom()
        {
            //Arrange
            var fakeRepository = A.Fake<IUserRepository>();

            UserDto userDto = new UserDto { Email = "test@test.com", Password = "Lösenord", Username = "test" };

            var command = new DeleteUserCommand(userDto);

            var commandHandler = new DeleteUserCommandHandler(fakeRepository);

            A.CallTo(() => fakeRepository.DeleteUserByEmail(A<User>._)).Returns(new User { Email = "test@test.com", Password = "Lösenord", Username = "test", UserId = Guid.NewGuid() });

            //Act

            var result = await commandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.GetType(), Is.EqualTo(typeof(User)));
            Assert.That(result.Username.Equals("test"));
        }
    }
}
