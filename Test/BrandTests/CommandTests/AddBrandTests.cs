using Application.Commands.Brands.AddBrand;
using Application.Dtos;
using Domain.Models.Brands;
using FakeItEasy;
using Infrastructure.Repository.Brands;

namespace Test.BrandTests.CommandTests
{
    [TestFixture]
    internal class AddBrandTests
    {
        [Test]
        public async Task Add_Brand_To_Database_Should_Return_A_Brand_With_Name_test()
        {
            //Arrange

            Brand brandToCreate = new Brand { BrandName = "test" };

            BrandDto brandDto = new BrandDto { BrandName = brandToCreate.BrandName };

            var testRepository = A.Fake<IBrandRepository>();

            var command = new AddBrandCommand(brandDto);

            var commandHandler = new AddBrandCommandHandler(testRepository);

            A.CallTo(() => testRepository.AddBrand(A<Brand>._)).Returns(new Brand { BrandId = Guid.NewGuid(), BrandName = "test" });

            //Act

            var result = await commandHandler.Handle(command, CancellationToken.None);

            //Assert

            Assert.IsNotNull(result);
            Assert.That(result.BrandName.Equals("test"));
            Assert.That(result, Is.TypeOf<Brand>());
        }
    }
}
