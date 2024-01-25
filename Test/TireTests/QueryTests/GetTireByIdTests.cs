using Application.Queries.Tires.GetById;
using Domain.Models.Brands;
using Domain.Models.Tires;
using FakeItEasy;
using Infrastructure.Repository.Tires;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Test.TireTests.QueryTests
{
    [TestFixture]
    internal class GetTireByIdTest
    {
        [Test]
        public async Task Get_Tire_By_Id_Should_Return_A_Tire()
        {
            // Arrange
            Guid testTireId = Guid.NewGuid();
            var testTire = new Tire
            {
                TireId = testTireId,
                TireModel = "TestModel",
                Brand = new Brand { BrandName = "TestBrand" },
                TireSize = "TestSize",
                TireTreadDepth = 10.5m
            };

            var testRepository = A.Fake<ITireRepository>();
            A.CallTo(() => testRepository.GetTireById(testTireId)).Returns(testTire);

            var query = new GetTireByIdQuery(testTireId);
            var queryHandler = new GetTireByIdQueryHandler(testRepository);

            // Act
            var result = await queryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<Tire>(result);
            Assert.That(result.TireId, Is.EqualTo(testTireId));
        }
    }
}
