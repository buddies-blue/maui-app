namespace Buddies.Logs.Validators
{
	public interface IEntityValidator<TEntity>
	{
		bool Validate(TEntity entity, out IDictionary<string, string> messages);
	}
}
