using Application.Commands.Gearboxes.DeleteGearbox;
using Domain.Models.Brands;
using Domain.Models.Gearboxes;
using FakeItEasy;
using Infrastructure.Repository.Gearboxes;

namespace Test.GearboxTests.CommandTests
{
    [TestFixture]
    internal class DeleteGearboxTest
    {
        [Test]
        public async Task Delete_Gearbox_Should_Return_Gearbox_Model()
        {

            // Arrange 
            Guid gearboxId = Guid.NewGuid();

            var testRepository = A.Fake<IGearboxRepository>();

            var command = new DeleteGearboxByIdCommand(gearboxId);

            var commandHandler = new DeleteGearboxByIdCommandHandler(testRepository);

            var gearboxWithRequiredMembers = new Gearbox
            {
                GearboxId = gearboxId,
                GearboxModel = "Automat",
                SixGears = true,
                Brand = new Brand { BrandName = "testBrand" }
            };

            A.CallTo(() => testRepository.DeleteGearbox(A<Guid>._)).Returns(gearboxWithRequiredMembers);

            // Act
            var result = await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.GearboxId.Equals(gearboxId));
            Assert.That(result, Is.TypeOf<Gearbox>());
        }
    }
}
