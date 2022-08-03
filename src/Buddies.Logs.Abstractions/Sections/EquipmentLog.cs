using Buddies.Logs.Abstractions.Entities;
using Buddies.Logs.Abstractions.Enums;

namespace Buddies.Logs.Abstractions.Sections;

public record class EquipmentLog : SectionLog
{
	public EquipmentLog(Log log)
		: base(log)
	{

	}

	public DiveSuit? Suit { get; set; }

	public double Weight { get; set; }

	public WeightBuoyancyType? Buoyancy { get; set; }

	public DiveCylinder? Cylinder { get; set; }

	public DiveGasMixture? GasMixture { get; set; }

	public ushort StartingPressure { get; set; }

	public ushort EndingPressure { get; set; }

	public ushort GasConsumption => (ushort)(StartingPressure - EndingPressure);
}
