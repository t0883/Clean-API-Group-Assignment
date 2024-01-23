using Domain.Models.Engines;
using FakeItEasy;
using Infrastructure.Repository.Engines.Interface;
using Application.Commands.Engines.AddEngine;
using Application.Dtos;

namespace Test.EngineTests.CommandTest.AddEngineTests
{
    [TestFixture]
    internal class AddEngineTest
    {
        [Test]
        public async Task Add_Engine_Test()
        {
            //Arrange
            EngineDto engineDto = new EngineDto
            {
                EngineFuel = "Gasoline",
                HorsePower = 200,
                EngineName = "TestEngine"
            };

            var testRepository = A.Fake<IEngineRepository>();

            var command = new AddEngineCommand(engineDto);

            var commandHandler = new AddEngineCommandHandler(testRepository);

            A.CallTo(() => testRepository.AddEngine(A<Engine>._))
                .Returns(new Engine
                {
                    EngineId = Guid.NewGuid(),
                    EngineFuel = "Gasoline",
                    HorsePower = 200,
                    EngineName = "TestEngine"
                });

            //Act
            var result = await commandHandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(engineDto.EngineFuel, result.EngineFuel);
            Assert.AreEqual(engineDto.HorsePower, result.HorsePower);
            Assert.AreEqual(engineDto.EngineName, result.EngineName);
            Assert.That(result, Is.TypeOf<Engine>());
        }
    }
}