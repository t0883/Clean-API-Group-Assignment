using Application.Commands.Engines.QuerieEngine.GetByIdEngine;
using Domain.Models.Engines;
using FakeItEasy;
using Infrastructure.Repository.Engines.Interface;

namespace Test.EngineTests.QueryTests
{
    [TestFixture]
    internal class GetEngineByIdTest
    {
        [Test]
        public async Task Get_Engine_By_Id_Test()
        {
            // Arrange
            Guid engineId = Guid.NewGuid();

            var testRepository = A.Fake<IEngineRepository>();

            var command = new GetEngineByIdQuery(engineId);

            var commandHandler = new GetEngineByIdQueryHandler(testRepository);

            var expectedEngine = new Engine { EngineId = engineId, EngineFuel = "Gasoline", EngineName = "test", HorsePower = 300 };

            A.CallTo(() => testRepository.GetEngineById(A<Guid>._)).Returns(expectedEngine);

            // Act
            var result = await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.EngineId, Is.EqualTo(expectedEngine.EngineId));
            Assert.That(result, Is.TypeOf<Engine>());
        }
    }
}