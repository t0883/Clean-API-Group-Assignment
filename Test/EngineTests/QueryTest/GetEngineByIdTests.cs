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
            //Arrange
            Guid engineId = Guid.NewGuid();

            var testRepository = A.Fake<IEngineRepository>();

            var query = new GetEngineByIdQuery(engineId);

            var queryHandler = new GetEngineByIdQueryHandler(testRepository);

            var expectedEngine = new Engine { EngineId = engineId, EngineFuel = "Gasoline", EngineName = "test", HorsePower = 300 };

            A.CallTo(() => testRepository.GetEngineById(A<Guid>._)).Returns(expectedEngine);

            //Act
            var result = await queryHandler.Handle(query, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedEngine.EngineId, result.EngineId);
            Assert.That(result, Is.TypeOf<Engine>());
        }
    }
}