using Buddies.Logs.Abstractions.Entities;
using Buddies.Logs.Abstractions.Enums;
using System.Collections.Immutable;

namespace Buddies.Logs.Abstractions.Sections;

public record class GeneralLog : SectionLog
{
	public GeneralLog(Log log)
		: base(log)
	{

	}

	public DiveSite? Site { get; set; }

	public IImmutableList<DiveBuddy> Buddies { get; set; } = ImmutableList.Create<DiveBuddy>();

	public string? DiveCenter { get; set; }

	public double MaxDepth { get; set; }

	public TimeSpan BottomTime { get; set; }

	public DiveEntryType? EntryType { get; set; }
}
