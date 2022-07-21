using Buddies.Logs.Abstractions;

namespace Buddies.App.Layout.Logs.Sections;

public partial class EquipmentLogSection : ContentView
{
	public static readonly BindableProperty LogProperty = BindableProperty.Create(nameof(Log), typeof(Log), typeof(EquipmentLogSection));

	public EquipmentLogSection()
	{
		InitializeComponent();
	}

	public Log Log
	{
		get => (Log)GetValue(LogProperty);
		set => SetValue(LogProperty, value);
	}
}