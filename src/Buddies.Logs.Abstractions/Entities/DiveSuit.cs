using Buddies.Logs.Abstractions.Enums;

namespace Buddies.Logs.Abstractions.Entities
{
	public record class DiveSuit
	{
		public ExposureSuitType Type { get; set; }

		public byte Thickness { get; set; }
	}
}
