using Application.Dtos;
using Application.Queries.Gearboxes.GetById;
using Domain.Models.Brands;
using Domain.Models.Gearboxes;
using FakeItEasy;
using Infrastructure.Repository.Gearboxes;

namespace Test.GearboxTests.QueryTests
{
    [TestFixture]
    internal class GetGearboxByIdTest
    {
        [Test]
        public async Task Get_Gearbox_By_Id_Should_Return_A_Gearbox_With_Id_test()
        {
            //Arrange
            BrandDto brandDto = new BrandDto { BrandName = "testBrand" };

            Guid gearboxId = Guid.NewGuid();

            var testGearboxRepository = A.Fake<IGearboxRepository>();

            var command = new GetGearboxByIdQuery(gearboxId);

            var commandhandler = new GetGearboxByIdQueryHandler(testGearboxRepository);

            A.CallTo(() => testGearboxRepository.GetGearboxById(A<Guid>._)).Returns(new Gearbox { GearboxId = gearboxId, GearboxModel = "Automat", SixGears = true, Brand = new Brand { BrandName = brandDto.BrandName } });

            //Act
            var result = await commandhandler.Handle(command, CancellationToken.None);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(brandDto.BrandName.Equals(result.Brand.BrandName));
            Assert.That(gearboxId, Is.EqualTo(result.GearboxId));
            Assert.That(result, Is.TypeOf<Gearbox>());
        }
    }
}
