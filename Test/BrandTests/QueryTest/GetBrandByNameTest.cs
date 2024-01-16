using Application.Queries.Brands.GetByName;
using Domain.Models.Brands;
using FakeItEasy;
using Infrastructure.Repository.Brands;

namespace Test.BrandTests.QueryTest
{
    [TestFixture]
    internal class GetBrandByNameTest
    {
        [Test]
        public async Task Get_Brand_By_Name_Should_Return_A_Brand_With_Name_test()
        {
            //Arrange
            string brandName = "test";

            var testRepository = A.Fake<IBrandRepository>();

            var command = new GetBrandByNameQuery(brandName);

            var commandHandler = new GetBrandByNameQueryHandler(testRepository);

            A.CallTo(() => testRepository.GetBrandByName(A<string>._)).Returns(new Brand { BrandId = new Guid(), BrandName = brandName });

            //Act

            var result = await commandHandler.Handle(command, CancellationToken.None);

            //Assert

            Assert.IsNotNull(result);
            Assert.That(result.BrandName.Equals("test"));
            Assert.That(result, Is.TypeOf<Brand>());
        }
    }
}
