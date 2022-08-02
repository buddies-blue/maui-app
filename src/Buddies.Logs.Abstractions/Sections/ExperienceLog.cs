namespace Buddies.Logs.Abstractions.Sections;

public record class ExperienceLog : SectionLog
{
	public ExperienceLog(Log log)
		: base(log)
	{

	}

	public string? Notes { get; set; }

	public byte? Rating { get; set; }
}
