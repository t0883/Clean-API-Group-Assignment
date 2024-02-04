using Application.Commands.Tires.AddTire;
using Application.Dtos;
using Domain.Models.Brands;
using Domain.Models.Tires;
using FakeItEasy;
using Infrastructure.Repository.Tires;

namespace Test.TireTests.CommandTests
{
    [TestFixture]
    internal class AddTireTests
    {
        [Test]
        public async Task Add_Tire_To_Database_Should_Return_Unit()
        {
            // Arrange
            var tireToCreate = new Tire
            {
                TireModel = "testModel",
                Brand = new Brand { BrandName = "testBrand" },
                TireSize = "testSize",
                TireTreadDepth = 6.0m
            };

            var tireDto = new TireDto
            {
                TireModel = tireToCreate.TireModel,
                Brand = tireToCreate.Brand,
                TireSize = tireToCreate.TireSize,
                TireTreadDepth = tireToCreate.TireTreadDepth
            };

            var testRepository = A.Fake<ITireRepository>();
            var command = new AddTireCommand(tireDto);
            var commandHandler = new AddTireCommandHandler(testRepository);

            A.CallTo(() => testRepository.AddTire(A<Tire>._)).Returns(Task.FromResult(tireToCreate));

            // Act
            var result = await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.TypeOf<Tire>());
        }
    }
}
