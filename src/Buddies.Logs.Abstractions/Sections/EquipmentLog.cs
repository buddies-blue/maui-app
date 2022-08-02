﻿using Buddies.Logs.Abstractions.Enums;

namespace Buddies.Logs.Abstractions.Sections;

public record class EquipmentLog : SectionLog
{
	public EquipmentLog(Log log)
		: base(log)
	{

	}

	public ExposureSuitType? SuitType { get; set; }

	public byte SuitThickness { get; set; }

	public double Weight { get; set; }

	public WeightBuoyancyType? Buoyancy { get; set; }

	public CylinderType? CylinderType { get; set; }

	public byte CylinderSize { get; set; }

	public GasMixtureType? GasMixture { get; set; }

	public byte? OxygenPercentage { get; set; }

	public byte? NitrogenPercentage { get; set; }

	public byte? HeliumPercentage { get; set; }

	public byte? HydrogenPercentage { get; set; }

	public ushort StartingPressure { get; set; }

	public ushort EndingPressure { get; set; }
}
