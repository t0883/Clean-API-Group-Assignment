using Application.Commands.Engines.UpdateEngine;
using Domain.Models.Engines;
using FakeItEasy;
using Infrastructure.Repository.Engines.Interface;

namespace Test.EngineTests.CommandTests.UpdateEngineTest
{
    [TestFixture]
    internal class UpdateEngineTests
    {
        [Test]
        public async Task Update_Engine_Test()
        {

            // Arrange

            Engine engineToUpdate = new Engine { EngineId = Guid.NewGuid(), EngineName = "test", EngineFuel = "Gasoline", HorsePower = 200 };

            var testRepository = A.Fake<IEngineRepository>();

            var command = new UpdateEngineCommand(engineToUpdate);

            var commandHandler = new UpdateEngineCommandHandler(testRepository);

            A.CallTo(() => testRepository.UpdateEngine(A<Engine>._)).Returns(engineToUpdate);

            // Act

            var result = await commandHandler.Handle(command, CancellationToken.None);

            // Assert

            Assert.IsNotNull(result);
            Assert.That(result.EngineName.Equals(engineToUpdate.EngineName));
            Assert.That(result.EngineFuel.Equals(engineToUpdate.EngineFuel));
            Assert.That(result.HorsePower.Equals(engineToUpdate.HorsePower));
            Assert.That(result, Is.TypeOf<Engine>());
        }
    }
}