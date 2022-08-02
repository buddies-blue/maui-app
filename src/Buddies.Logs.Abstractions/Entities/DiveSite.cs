namespace Buddies.Logs.Abstractions.Entities;

public record class DiveSite
{
	public DiveSite(string name)
	{
		Name = name;
	}

	public string Name { get; set; }

	public (double Longitude, double Latidude) Coordinates { get; set; }
}
