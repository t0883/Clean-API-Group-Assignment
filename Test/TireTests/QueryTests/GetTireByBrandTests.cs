using Application.Queries.Tires.GetByBrand;
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
    internal class GetTireByBrandTest
    {
        [Test]
        public async Task Get_Tire_By_Brand_Should_Return_List_Of_Tires()
        {
            // Arrange
            string testBrandName = "TestBrand";
            var testTires = new List<Tire>
            {
                new Tire { TireId = Guid.NewGuid(), TireModel = "TestModel1", Brand = new Brand { BrandName = testBrandName }, TireSize = "TestSize1", TireTreadDepth = 10.5m },
                new Tire { TireId = Guid.NewGuid(), TireModel = "TestModel2", Brand = new Brand { BrandName = testBrandName }, TireSize = "TestSize2", TireTreadDepth = 11.5m },
                // Add more test tires for the same brand or different brands as needed
            };

            var testRepository = A.Fake<ITireRepository>();
            A.CallTo(() => testRepository.GetTireByBrand(testBrandName)).Returns(testTires);

            var query = new GetTireByBrandQuery(testBrandName);
            var queryHandler = new GetTireByBrandQueryHandler(testRepository);

            // Act
            var result = await queryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<Tire>>(result);
            Assert.That(result.Count, Is.EqualTo(testTires.Count)); // Ensure the returned list has the same count as the test data
            foreach (var tire in result)
            {
                Assert.That(tire.Brand.BrandName, Is.EqualTo(testBrandName));
            }
        }
    }
}
