using Application.Queries.Brands.GetAll;
using Domain.Models.Brands;
using FakeItEasy;
using Infrastructure.Repository.Brands;

namespace Test.BrandTests.QueryTest
{
    [TestFixture]
    internal class GetAllBrandsTests
    {
        [Test]
        public async Task Get_List_Of_Brands_Should_Return_List_Of_Brands()
        {

            //Arrange
            var testRepository = A.Fake<IBrandRepository>();

            var query = new GetAllBrandsQuery();

            var queryHandler = new GetAllBrandsQueryHandler(testRepository);

            A.CallTo(() => testRepository.GetAllBrands()).Returns(new List<Brand> { new Brand { BrandId = Guid.NewGuid(), BrandName = "test1" }, new Brand { BrandId = Guid.NewGuid(), BrandName = "test2" }, new Brand { BrandId = Guid.NewGuid(), BrandName = "test3" } });

            //Act

            var result = await queryHandler.Handle(query, CancellationToken.None);

            //Assert

            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result, Is.TypeOf<List<Brand>>());
        }
    }
}
