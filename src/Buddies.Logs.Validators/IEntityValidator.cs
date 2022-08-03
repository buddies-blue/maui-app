using System.Collections.Immutable;

namespace Buddies.Logs.Validators
{
	public interface IEntityValidator<TEntity>
	{
		bool Validate(TEntity entity, out IImmutableDictionary<string, IImmutableList<string>>? messages);
	}
}
