using Application.Commands.Brands.DeleteBrand;
using Domain.Models.Brands;
using FakeItEasy;
using Infrastructure.Repository.Brands;

namespace Test.BrandTests.CommandTests
{
    [TestFixture]
    internal class DeleteBrandTest
    {
        [Test]
        public async Task Delete_Brand_Should_Return_Brand_Model()
        {
            //Arrange 

            string brandName = "test";

            var testRepository = A.Fake<IBrandRepository>();

            var command = new DeleteBrandByNameCommand(brandName);

            var commandHandler = new DeleteBrandByNameCommandHandler(testRepository);

            A.CallTo(() => testRepository.DeleteBrandByName(A<string>._)).Returns(new Brand { BrandId = new Guid(), BrandName = brandName });

            //Act

            var result = await commandHandler.Handle(command, CancellationToken.None);

            //Assert

            Assert.IsNotNull(result);
            Assert.That(result.BrandName.Equals(brandName));
            Assert.That(result, Is.TypeOf<Brand>());
        }
    }
}
