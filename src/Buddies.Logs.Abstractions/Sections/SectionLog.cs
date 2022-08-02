namespace Buddies.Logs.Abstractions.Sections;

public abstract record class SectionLog
{
	public SectionLog(Log log)
	{
		Log = log;
	}

	public Log Log { get; }
}
