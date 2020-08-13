using Newspaper.Repository.Entities;
using Newspaper.Service.Interfaces;
using Newspaper.Service.Service;
using NSubstitute;
using System.Threading.Tasks;
using NUnit.Framework;
using NewsPaper.Repository.Interfaces;

namespace Newspaper.UnitTests
{
    [TestFixture]
    public class NewsServiceTest
    {
        private readonly INewsService _newsServiceMock;
        private readonly INewsRepository _newsRepositoryMock;
        
        public NewsServiceTest()
        {
            _newsServiceMock = Substitute.For<INewsService>();
            _newsRepositoryMock = Substitute.For<INewsRepository>();
        }

       
        [Test]
        public void InvokesNewsRepositoryGetByIdAsync_Return_Not_Null_Result()
        {
            //Arrange
            _newsRepositoryMock.GetByIdAsync(Arg.Any<int>())
                .Returns(Task.FromResult<NewsItem>(new NewsItem()));

            var newsServiceMock = new NewsService(_newsRepositoryMock);

            //Act
            var result = newsServiceMock.GetByIdAsync(1);

            //Assert
            Assert.NotNull(result);
        }

        [Test]
        public void InvokesNewsRepositoryGetByIdAsync_Return_Null_Result()
        {
            //Arrange
            _newsRepositoryMock.GetByIdAsync(Arg.Any<int>())
                .Returns(Task.FromResult<NewsItem>(null));

            var newsServiceMock = new NewsService(_newsRepositoryMock);

            //Act
            var result = newsServiceMock.GetByIdAsync(50);

            //Assert
            Assert.Null(result.Result);
        }
    }
}
