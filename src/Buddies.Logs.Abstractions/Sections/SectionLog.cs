namespace Buddies.Logs.Abstractions.Sections;

public abstract class SectionLog
{
	public SectionLog(Log log)
	{
		Log = log;
	}

	public Log Log { get; }
}
