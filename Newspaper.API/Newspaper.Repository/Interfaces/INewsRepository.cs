using System.Collections.Generic;
using System.Threading.Tasks;
using Newspaper.Repository.Entities;

namespace NewsPaper.Repository.Interfaces
{
    public interface INewsRepository
    {
        Task<NewsItem> GetByIdAsync(int id);
        Task<List<NewsItem>> ListAllAsync();
    }
}
