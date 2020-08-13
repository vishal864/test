using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newspaper.Model;
using Newspaper.Service.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using Newspaper.Repository.Entities;
using Newspaper.Service.Service;
using NewsPaper.InternalSource.Repository;

namespace Newspaper.API.Controllers
{   
    public class NewsController : ApiController
    {
        private readonly INewsService _newsService;
        private IMapper _mapper;
        //we can use the Log4Net for logging exception in API Method

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;

            //Initialize Automapper
            initializeAutoMapper();
        }

        private void initializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NewsItem, NewsItemDto>();
            });

            _mapper = config.CreateMapper();
        }

        [HttpGet]
        [Route("api/{news}/{category}")]
        //http://localhost:53636/api/news/Travel 
        //http://localhost:53636/api/news/Travel?pageSize=5 //Travel can be replaced with Political/Sports/Advertisement

        public async Task<IHttpActionResult> GetAll(string category, int pageSize = 8)
        {
            var result = await _newsService.ListAllAsync(category);
            var resultDto = _mapper.Map<List<NewsItemDto>>(result.Take(pageSize));
            return Ok(resultDto);
        }

        [HttpGet]
        [Route("api/{news}/{category}/{id}")]
        //http://localhost:53636/api/news/Travel/2

        public async Task<IHttpActionResult> Get(string category, int id)
        {
            var result = await _newsService.GetByIdAsync(id, category);
            var resultDto = _mapper.Map<NewsItemDto>(result);
            return Ok(resultDto);
        }

        [HttpGet]
        [Route("api/{news}")]
        //http://localhost:53636/api/news

        public async Task<IHttpActionResult> GetResult()
        {
            // Parallel call for multiple serives to improve performance. It will return the task.
            var firstCallResultTask = _newsService.ListAllAsync();
            var secondCallResultTask = _newsService.ListAllAsync();
            var thirdCallResultTask = _newsService.ListAllAsync();

            // Wait to complete execution for all services
            await Task.WhenAll(firstCallResultTask, secondCallResultTask, thirdCallResultTask);

            // Get results. await will return the actual results.
            var result = await firstCallResultTask;
            result.AddRange(await secondCallResultTask);
            result.AddRange(await thirdCallResultTask);

            // Convert entity into DTOs
            var resultDto = _mapper.Map<List<NewsItemDto>>(result);
            return Ok(resultDto);
        }
    }
}
