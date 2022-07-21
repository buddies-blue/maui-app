using Buddies.Logs.Abstractions;

namespace Buddies.App.Layout.Logs.Sections;

public partial class ConditionsLogSection : ContentView
{
	public static readonly BindableProperty LogProperty = BindableProperty.Create(nameof(Log), typeof(Log), typeof(ConditionsLogSection));

	public ConditionsLogSection()
	{
		InitializeComponent();
	}

	public Log Log
	{
		get => (Log)GetValue(LogProperty);
		set => SetValue(LogProperty, value);
	}
}