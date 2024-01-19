using API.Controllers.UsersController;
using Application.Queries.Users.GetAll;
using Domain.Models.Users;
using FakeItEasy;
using Infrastructure.Repository.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Test.UserTests.QueryTests
{
    [TestFixture]
    internal class GetAllUsersTests
    {
        [Test]
        public async Task Get_All_Users_Should_Return_Ok_Response()
        {
            //Arrange

            var fakeMediator = A.Fake<IMediator>();

            var controller = new UsersController(fakeMediator);

            //Act
            var result = await controller.GetAllUsers();

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task Get_All_Users_Should_Return_List_Of_Users()
        {
            //Arrange

            var testRepository = A.Fake<IUserRepository>();

            var query = new GetAllUsersQuery();

            var queryHandler = new GetAllUsersQueryHandler(testRepository);

            A.CallTo(() => testRepository.GetAllUsers()).Returns(new List<User> { new User { UserId = Guid.NewGuid(), Email = "test@test.com", Password = "Lösenord", Username = "test1" }, new User { UserId = Guid.NewGuid(), Email = "test1@test.com", Password = "Lösenord", Username = "test2" }, new User { UserId = Guid.NewGuid(), Email = "3@test.com", Password = "Lösenord", Username = "test3" } });

            //Act

            var result = await queryHandler.Handle(query, CancellationToken.None);

            //Assert

            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result, Is.TypeOf<List<User>>());
        }
    }
}
