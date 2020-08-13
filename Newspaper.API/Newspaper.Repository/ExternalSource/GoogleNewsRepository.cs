using NewsPaper.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newspaper.Repository.Entities;

namespace Newspaper.Repository.ExternalSource
{
    public class GoogleNewsRepository : INewsRepository
    {
        public async Task<NewsItem> GetByIdAsync(int id)
        {
            await Task.Delay(1000);
            return GetNewsFromExternalSource().FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<NewsItem>> ListAllAsync()
        {
            await Task.Delay(1000);
            return GetNewsFromExternalSource();
        }

        public List<NewsItem> GetNewsFromExternalSource()
        {
            //call to google api and get data -- implementation of external api goes here
            return new List<NewsItem>();
        }
    }
}
