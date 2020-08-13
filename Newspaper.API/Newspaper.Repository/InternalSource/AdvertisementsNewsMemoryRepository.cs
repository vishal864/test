using NewsPaper.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newspaper.Repository.Entities;

namespace NewsPaper.InternalSource.Repository
{
    public class AdvertisementsNewsMemoryRepository : INewsRepository
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
                new NewsItem() {Id = 1, Title = "Advertisements", Description = "Advertisements Description 1"},
                new NewsItem() {Id = 2, Title = "Advertisements", Description = "Advertisements Description 2"},
                new NewsItem() {Id = 3, Title = "Advertisements", Description = "Advertisements Description 3"},
                new NewsItem() {Id = 4, Title = "Advertisements", Description = "Advertisements Description 4"},
                new NewsItem() {Id = 5, Title = "Advertisements", Description = "Advertisements Description 5"},
            };

            return newsItems;
        }

    }
}
