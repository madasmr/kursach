using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using wise_nut.Data.EF;
using wise_nut;

namespace wise_nut.Data.EF
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddEfRepositories(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<StoreDbContext>(
				options =>
				{
					options.UseSqlServer(connectionString);
				},
				ServiceLifetime.Transient
			);

			services.AddScoped<Dictionary<Type, StoreDbContext>>();
			services.AddSingleton<DbContextFactory>();
			services.AddSingleton<IProductRepository, ProductRepository>();
			services.AddSingleton<IOrderRepository, OrderRepository>();
			return services;
		}
	}
}