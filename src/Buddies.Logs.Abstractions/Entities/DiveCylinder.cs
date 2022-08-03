using Buddies.Logs.Abstractions.Enums;

namespace Buddies.Logs.Abstractions.Entities
{
	public record class DiveCylinder
	{
		public CylinderType Type { get; set; }

		public byte Size { get; set; }
	}
}
