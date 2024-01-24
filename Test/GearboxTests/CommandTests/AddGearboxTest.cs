using FakeItEasy;
using Application.Dtos;
using Domain.Models.Brands;
using Domain.Models.Gearboxes;
using Infrastructure.Repository.Gearboxes;
using Application.Commands.Gearboxes.AddGearbox;

namespace Test.GearboxTests.CommandTests
{
    [TestFixture]
    internal class AddGearboxTest
    {
        [Test]
        public async Task Add_Gearbox_To_Database_Should_Return_A_Gearbox_With_Id_test()
        {
            // Arrange
            var testGearboxRepository = A.Fake<IGearboxRepository>();

            BrandDto brandDto = new BrandDto { BrandName = "testBrand" };

            Gearbox gearboxToCreate = new Gearbox
            {
                GearboxId = Guid.NewGuid(),
                GearboxModel = "test",
                SixGears = true,
                Brand = new Brand { BrandName = brandDto.BrandName }
            };

            var gearboxDto = new GearboxDto
            {
                GearboxModel = "test",
                SixGears = true,
                Brand = new Brand { BrandName = brandDto.BrandName }
            };

            var command = new AddGearboxCommand(gearboxDto);

            A.CallTo(() => testGearboxRepository.AddGearbox(A<Gearbox>._))
                .Returns(gearboxToCreate);

            var handler = new AddGearboxCommandHandler(testGearboxRepository);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.GearboxId, Is.EqualTo(gearboxToCreate.GearboxId));
            Assert.That(result.GearboxModel, Is.EqualTo(gearboxToCreate.GearboxModel));
            Assert.That(result.SixGears, Is.EqualTo(gearboxToCreate.SixGears));
        }
    }
}
