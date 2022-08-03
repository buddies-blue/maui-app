using Buddies.Logs.Abstractions.Enums;

namespace Buddies.Logs.Abstractions.Entities
{
	public record class DiveGasMixture
	{
		public GasMixtureType GasMixtureType { get; set; } = GasMixtureType.Air;

		public byte Oxygen { get; set; }

		public byte Nitrogen { get; set; }

		public byte Helium { get; set; }

		public byte Hydrogen { get; set; }
	}
}
