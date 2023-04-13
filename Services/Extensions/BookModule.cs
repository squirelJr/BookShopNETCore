using Microsoft.Extensions.DependencyInjection;

using System.Reflection;


namespace Services.Extensions
{
 
        public static class BookModule
        {
            public static IServiceCollection AddBookModule(this IServiceCollection serviceCollection)
            {
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

                return serviceCollection;
            }


        }
  
}
