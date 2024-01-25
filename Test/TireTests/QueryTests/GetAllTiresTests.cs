using Application.Queries.Tires.GetAll;
using Domain.Models.Brands;
using Domain.Models.Tires;
using FakeItEasy;
using Infrastructure.Repository.Tires;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Test.TireTests.QueryTests
{
    [TestFixture]
    internal class GetAllTiresTest
    {
        [Test]
        public async Task Get_All_Tires_Should_Return_List_Of_Tires()
        {
            // Arrange
            var testTires = new List<Tire>
            {
                new Tire { TireId = Guid.NewGuid(), TireModel = "TestModel1", Brand = new Brand { BrandName = "TestBrand1" }, TireSize = "TestSize1", TireTreadDepth = 10.5m },
                new Tire { TireId = Guid.NewGuid(), TireModel = "TestModel2", Brand = new Brand { BrandName = "TestBrand2" }, TireSize = "TestSize2", TireTreadDepth = 11.5m },

            };

            var testRepository = A.Fake<ITireRepository>();
            A.CallTo(() => testRepository.GetAllTires()).Returns(testTires);

            var query = new GetAllTiresQuery();
            var queryHandler = new GetAllTiresQueryHandler(testRepository);

            // Act
            var result = await queryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<Tire>>(result);
            Assert.That(result.Count, Is.EqualTo(testTires.Count));
        }
    }
}
