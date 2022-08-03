using Buddies.Logs.Abstractions.Entities;
using Buddies.Logs.Validators.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Buddies.Logs.Validators.Extensions
{
	public static class ValidatorExtensions
	{
		public static IServiceCollection AddValidator<TEntity, TImplementation>(this IServiceCollection services)
			where TImplementation : class, IEntityValidator<TEntity>
		{
			return services.AddSingleton<IEntityValidator<TEntity>, TImplementation>();
		}

		public static IServiceCollection AddValidators(this IServiceCollection services)
		{
			return services.AddValidator<DiveGasMixture, DiveGasMixtureValidator>();
		}
	}
}
