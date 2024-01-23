using Application.Commands.Engines.QuerieEngine.GetAll;
using Application.Commands.Engines.Queries.GetAll;
using Domain.Models.Engines;
using FakeItEasy;
using Infrastructure.Repository.Engines.Interface;

namespace Test.EngineTests.QueryTests
{
    [TestFixture]
    internal class GetAllEnginesTests
    {
        [Test]
        public async Task Get_All_Engine_Tests()
        {

            // Arrange
            var testRepository = A.Fake<IEngineRepository>();

            var query = new GetAllEngineQuery();

            var queryHandler = new GetAllEngineQueryHandler(testRepository);

            A.CallTo(() => testRepository.GetAllEngines()).Returns(new List<Engine> { new Engine { EngineId = Guid.NewGuid(), EngineName = "test1", EngineFuel = "Gasoline", HorsePower = 200 }, new Engine { EngineId = Guid.NewGuid(), EngineName = "test2", EngineFuel = "Disel", HorsePower = 300 }, new Engine { EngineId = Guid.NewGuid(), EngineName = "test3", EngineFuel = "electricity", HorsePower = 400 } });

            // Act

            var result = await queryHandler.Handle(query, CancellationToken.None);

            // Assert

            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result, Is.TypeOf<List<Engine>>());
        }
    }
}