using Application.Commands.Engines.DeleteEngine;
using Domain.Models.Engines;
using FakeItEasy;
using Infrastructure.Repository.Engines.Interface;

namespace Test.EngineTests.CommandTests.DeleteEngineTest
{
    [TestFixture]
    internal class DeleteEngineTest
    {
        [Test]
        public async Task Delete_Engine_Test()
        {
            // Arrange 
            Guid engineId = Guid.NewGuid();

            var testRepository = A.Fake<IEngineRepository>();

            var command = new DeleteEngineCommand(engineId);

            var commandHandler = new DeleteEngineCommandHandler(testRepository);

            var engineWithRequiredMembers = new Engine
            {
                EngineId = engineId,
                EngineName = "ExampleEngineName",
                EngineFuel = "ExampleEngineFuel",
                HorsePower = 200
            };

            A.CallTo(() => testRepository.DeleteEngine(A<Guid>._)).Returns(engineWithRequiredMembers);

            // Act
            var result = await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.EngineId.Equals(engineId));
            Assert.That(result, Is.TypeOf<Engine>());
        }
    }
}