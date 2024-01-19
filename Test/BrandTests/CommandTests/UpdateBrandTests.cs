using Application.Commands.Brands.UpdateBrand;
using Domain.Models.Brands;
using FakeItEasy;
using Infrastructure.Repository.Brands;

namespace Test.BrandTests.CommandTests
{
    [TestFixture]
    internal class UpdateBrandTests
    {
        [Test]
        public async Task Update_Brand_Should_Return_Brand_With_Name_test()
        {

            //Arrange

            Brand brandToUpdate = new Brand { BrandId = Guid.NewGuid(), BrandName = "test" };

            var testRepository = A.Fake<IBrandRepository>();

            var command = new UpdateBrandByIdCommand(brandToUpdate);

            var commandHandler = new UpdateBrandByIdCommandHandler(testRepository);

            A.CallTo(() => testRepository.UpdateBrandById(A<Brand>._)).Returns(brandToUpdate);

            //Act

            var result = await commandHandler.Handle(command, CancellationToken.None);

            //Assert

            Assert.IsNotNull(result);
            Assert.That(result.BrandName.Equals(brandToUpdate.BrandName));
            Assert.That(result, Is.TypeOf<Brand>());
        }
    }
}
