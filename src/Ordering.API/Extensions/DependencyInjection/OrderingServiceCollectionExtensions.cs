using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Order;
using Ordering.Domain.AggregatesModel.OrderAggregate;
using Ordering.Framework;
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
                //options.UseSqlServer(connectionStr);
            });

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork, EFCoreUnitOfWork>();

            //TODO: Should this be a singleton?
            services.AddScoped((sp) =>
            {
                IOrderRepository orderRepository = sp.GetRequiredService<IOrderRepository>();
                IUnitOfWork unitOfWork = sp.GetRequiredService<IUnitOfWork>();
                return new OrdersCommandService(orderRepository, unitOfWork);
            });

            //TODO: Should this be a singleton?
            services.AddScoped((sp) =>
            {
                OrderingContext orderingContext = sp.GetRequiredService<OrderingContext>();
                return new OrdersQueryService(orderingContext);
            });

            return services;
        }
    }
}
