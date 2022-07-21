using Buddies.Logs.Abstractions;
using System.Security.Cryptography;

namespace Buddies.App.Layout.Logs.Sections;

public partial class GeneralLogSection : ContentView
{
	public static readonly BindableProperty LogProperty = BindableProperty.Create(nameof(Log), typeof(Log), typeof(GeneralLogSection));

	public GeneralLogSection()
	{
		InitializeComponent();
	}

	public Log Log
	{
		get => (Log)GetValue(LogProperty);
		set => SetValue(LogProperty, value);
	}
}
