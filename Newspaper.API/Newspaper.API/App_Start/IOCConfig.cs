using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Newspaper.Service.Interfaces;
using Newspaper.Service.Service;
using NewsPaper.InternalSource.Repository;
using NewsPaper.Repository.Interfaces;

namespace Newspaper.API.App_Start
{
    public class IOCConfig
    {
        //Autofac configuration
        public static void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<PoliticalNewsMemoryRepository>().As<INewsRepository>().InstancePerRequest();
            builder.RegisterType<AdvertisementsNewsMemoryRepository>().As<INewsRepository>().InstancePerRequest();
            builder.RegisterType<TravelNewsMemoryRepository>().As<INewsRepository>().InstancePerRequest();
            builder.RegisterType<SportsNewsMemoryRepository>().As<INewsRepository>().InstancePerRequest();
            builder.RegisterType<NewsMemoryRepository>().As<INewsRepository>().InstancePerRequest();
            builder.RegisterType<NewsService>().As<INewsService>().InstancePerRequest();
            builder.RegisterType<IMapper>().AsSelf().InstancePerRequest();

            IContainer container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}