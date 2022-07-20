using Buddies.Logs.Abstractions.Sections;

namespace Buddies.Logs.Abstractions;

public class Log
{
	public Log()
	{
		General = new GeneralLog(this);
		Conditions = new ConditionsLog(this);
		Equipment = new EquipmentLog(this);
		Experience = new ExperienceLog(this);
	}

	public GeneralLog General { get; init; }

	public ConditionsLog Conditions { get; init; }

	public EquipmentLog Equipment { get; init; }

	public ExperienceLog Experience { get; init; }
}
