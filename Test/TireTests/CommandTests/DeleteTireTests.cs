using Application.Commands.Tires.DeleteTire;
using FakeItEasy;
using Infrastructure.Repository.Tires;
using MediatR;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test.TireTests.CommandTests
{
    [TestFixture]
    internal class DeleteTireTests
    {
        [Test]
        public async Task Delete_Tire_By_Id_Should_Return_Unit()
        {
            // Arrange
            var tireIdToDelete = Guid.NewGuid();
            var testRepository = A.Fake<ITireRepository>();
            var command = new DeleteTireByIdCommand(tireIdToDelete);
            var commandHandler = new DeleteTireByIdCommandHandler(testRepository);

            // Act
            var result = await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(Unit.Value));
            A.CallTo(() => testRepository.DeleteTireById(tireIdToDelete)).MustHaveHappenedOnceExactly();
        }
    }
}
