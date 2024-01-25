using Application.Commands.Gearboxes.UpdateGearbox;
using Domain.Models.Brands;
using Domain.Models.Gearboxes;
using FakeItEasy;
using Infrastructure.Repository.Brands;
using Infrastructure.Repository.Gearboxes;

namespace Test.GearboxTests.CommandTests
{
    [TestFixture]
    internal class UpdateGearboxTest
    {
        [Test]
        public async Task Update_Gearbox_Should_Return_Gearbox_With_Id_test()
        {
            // Arrange
            Gearbox gearboxToUpdate = new Gearbox { GearboxId = Guid.NewGuid(), GearboxModel = "Manuell", SixGears = false, Brand = new Brand { BrandName = "testBrand" } };

            var testGearboxRepository = A.Fake<IGearboxRepository>();
            var testBrandRepository = A.Fake<IBrandRepository>();

            var command = new UpdateGearboxByIdCommand(gearboxToUpdate);
            var commandHandler = new UpdateGearboxByIdCommandHandler(testGearboxRepository, testBrandRepository);

            A.CallTo(() => testGearboxRepository.UpdateGearboxById(A<Gearbox>._)).Returns(gearboxToUpdate);

            // Act
            var result = await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.GearboxModel.Equals(gearboxToUpdate.GearboxModel));
            Assert.That(result.SixGears.Equals(gearboxToUpdate.SixGears));
            Assert.That(result.Brand.BrandName.Equals(gearboxToUpdate.Brand.BrandName));
            Assert.That(result, Is.TypeOf<Gearbox>());
        }
    }
}
