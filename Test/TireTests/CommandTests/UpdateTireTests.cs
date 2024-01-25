using Application.Commands.Tires.UpdateTire;
using Domain.Models.Brands;
using Domain.Models.Tires;
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
    internal class UpdateTireTest
    {
        [Test]
        public async Task Update_Tire_Should_Return_Unit()
        {
            // Arrange
            var tireToUpdate = new Tire
            {
                TireId = Guid.NewGuid(),
                TireModel = "testModel",
                Brand = new Brand { BrandName = "testBrand" },
                TireSize = "testSize",
                TireTreadDepth = 10.5m
            };

            var testRepository = A.Fake<ITireRepository>();
            var command = new UpdateTireByIdCommand(tireToUpdate);
            var commandHandler = new UpdateTireByIdCommandHandler(testRepository);

            // Act
            var result = await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(Unit.Value));
            A.CallTo(() => testRepository.UpdateTire(A<Tire>._)).MustHaveHappenedOnceExactly();
        }
    }
}
