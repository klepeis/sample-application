using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Domain.AggregatesModel;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Repositories;

namespace Ordering.API.Extensions.DependencyInjection
{
    public static class OrderingServiceCollectionExtensions
    {
        public static IServiceCollection RegisterOrdering(this IServiceCollection services)
        {
            services.AddDbContext<OrderingContext>(options =>
            {
                string connectionStr = "";
                options.UseSqlServer(connectionStr);
            });

            services.AddScoped<IOrderRepository, OrderRepository>();

            //TODO: Should this be a singleton?
            services.AddSingleton<OrdersApplicationService>((sp) =>
            {
                IOrderRepository orderRepository = sp.GetRequiredService<IOrderRepository>();
                return new OrdersApplicationService(orderRepository);
            });

            return services;
        }
    }
}
