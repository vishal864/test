using Newspaper.Repository.Entities;
using NewsPaper.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPaper.InternalSource.Repository
{
    public class TravelNewsMemoryRepository : INewsRepository
    {
        public async Task<NewsItem> GetByIdAsync(int id)
        {
            await Task.Delay(1000);
            return GetNewsFromMemory().FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<NewsItem>> ListAllAsync()
        {
            await Task.Delay(1000);
            return GetNewsFromMemory();
        }

        public List<NewsItem> GetNewsFromMemory()
        {
            var newsItems = new List<NewsItem>() 
            {
                new NewsItem() {Id = 1, Title = "Travel", Description = "Travel Description1"},
                new NewsItem() {Id = 2, Title = "Travel", Description = "Travel Description2"},
                new NewsItem() {Id = 3, Title = "Travel", Description = "Travel Description3"},
                new NewsItem() {Id = 4, Title = "Travel", Description = "Travel Description4"},
                new NewsItem() {Id = 5, Title = "Travel", Description = "Travel Description5"}
            };

            return newsItems;
        }

    }
}
