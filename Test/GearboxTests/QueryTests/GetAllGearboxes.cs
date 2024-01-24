using Application.Queries.Gearboxes.GetAll;
using Domain.Models.Brands;
using Domain.Models.Gearboxes;
using FakeItEasy;
using Infrastructure.Repository.Gearboxes;

namespace Test.GearboxTests.QueryTests
{
    [TestFixture]
    internal class GetAllGearboxes
    {
        [Test]
        public async Task Get_List_Of_Gearboxes_Should_Return_List_Of_Gearboxes()
        {

            // Arrange
            var testGearboxRepository = A.Fake<IGearboxRepository>();

            var query = new GetAllGearboxesQuery();

            var queryHandler = new GetAllGearboxesQueryHandler(testGearboxRepository);

            // Skapa Brand-objekt för varje Gearbox, så du kan få med kopplade brands
            var testBrand1 = new Brand { BrandName = "testBrand1" };
            var testBrand2 = new Brand { BrandName = "testBrand2" };
            var testBrand3 = new Brand { BrandName = "testBrand3" };

            A.CallTo(() => testGearboxRepository.GetAllGearboxes()).Returns(new List<Gearbox>
            {
                new Gearbox { GearboxId = Guid.NewGuid(), SixGears = true, GearboxModel = "Automat", Brand = testBrand1 },
                new Gearbox { GearboxId = Guid.NewGuid(), SixGears = false, GearboxModel = "Manuell", Brand = testBrand2 },
                new Gearbox { GearboxId = Guid.NewGuid(), SixGears = true, GearboxModel = "Manuell", Brand = testBrand3 }
            });

            // Act
            var result = await queryHandler.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result, Is.TypeOf<List<Gearbox>>());
        }
    }
}
