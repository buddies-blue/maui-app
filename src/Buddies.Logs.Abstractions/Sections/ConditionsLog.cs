using Buddies.Logs.Abstractions.Enums;

namespace Buddies.Logs.Abstractions.Sections;

public record class ConditionsLog : SectionLog
{
	public ConditionsLog(Log log)
		: base(log)
	{

	}

	public WeatherType? Weather { get; set; }

	public double? AirTemperature { get; set; }

	public double? SurfaceTemperature { get; set; }

	public double? BottomTemperature { get; set; }

	public WaterTypes? WaterType { get; set; }

	public WaterBodyType? WaterBodyType { get; set; }

	public VisibilityType? Visibility { get; set; }
}
