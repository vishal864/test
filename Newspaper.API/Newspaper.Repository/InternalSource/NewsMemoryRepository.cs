using Newspaper.Repository.Entities;
using NewsPaper.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPaper.InternalSource.Repository
{
    public class NewsMemoryRepository : INewsRepository
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
                new NewsItem() {Id = 1, Title = "Political", Description = "Political Description1"},
                new NewsItem() {Id = 2, Title = "Political", Description = "Political Description2"},
                new NewsItem() {Id = 3, Title = "Political", Description = "Political Description3"},
                new NewsItem() {Id = 4, Title = "Political", Description = "Political Description4"},
                new NewsItem() {Id = 5, Title = "Political", Description = "Political Description5"},
                new NewsItem() {Id = 6, Title = "Sports", Description = "Sports Description1"},
                new NewsItem() {Id = 7, Title = "Sports", Description = "Sports Description2"},
                new NewsItem() {Id = 8, Title = "Sports", Description = "Sports Description3"},
                new NewsItem() {Id = 9, Title = "Sports", Description = "Sports Description4"},
                new NewsItem() {Id = 10, Title = "Sports", Description = "Sports Description5"},
                new NewsItem() {Id = 11, Title = "Travel", Description = "Travel Description1"},
                new NewsItem() {Id = 12, Title = "Travel", Description = "Travel Description2"},
                new NewsItem() {Id = 13, Title = "Travel", Description = "Travel Description3"},
                new NewsItem() {Id = 14, Title = "Travel", Description = "Travel Description4"},
                new NewsItem() {Id = 15, Title = "Travel", Description = "Travel Description5"},
                new NewsItem() {Id = 16, Title = "Advertisements", Description = "Advertisements Description1"},
                new NewsItem() {Id = 17, Title = "Advertisements", Description = "Advertisements Description2"},
                new NewsItem() {Id = 18, Title = "Advertisements", Description = "Advertisements Description3"},
                new NewsItem() {Id = 19, Title = "Advertisements", Description = "Advertisements Description4"},
                new NewsItem() {Id = 20, Title = "Advertisements", Description = "Advertisements Description5"},
            };

            return newsItems;
        }

    }
}
