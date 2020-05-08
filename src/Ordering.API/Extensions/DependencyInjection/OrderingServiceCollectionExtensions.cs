using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
                // Since the query service should not be able to persist any changes we will configure the instance of the DbContext
                // that is being used to have Change Tracking disabled.  Since no changes are being tracked if a Save operation is performed
                // on the DbContext nothing will be persisted.
                OrderingContext orderingContext = sp.GetRequiredService<OrderingContext>();
                orderingContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                
                return new OrdersQueryService(orderingContext);
            });

            return services;
        }
    }
}
