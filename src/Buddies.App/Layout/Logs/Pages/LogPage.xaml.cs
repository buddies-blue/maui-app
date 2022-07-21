using Buddies.Logs.Abstractions;

namespace Buddies.App.Layout.Logs.Pages;

public partial class LogPage : ContentPage
{
	private static readonly BindableProperty SectionsProperty = BindableProperty.Create(nameof(Sections), typeof(IEnumerable<LogSection>), typeof(LogPage), defaultBindingMode: BindingMode.OneTime);
	private static readonly BindableProperty LogProperty = BindableProperty.Create(nameof(Log), typeof(Log), typeof(LogPage), defaultBindingMode: BindingMode.OneTime);

	public LogPage()
	{
		InitializeComponent();
		InitializeSections();
	}

	public IEnumerable<LogSection> Sections
	{
		get => (IEnumerable<LogSection>)GetValue(SectionsProperty);
		set => SetValue(SectionsProperty, value);
	}

	public Log Log
	{
		get => (Log)GetValue(LogProperty);
		set => SetValue(LogProperty, value);
	}

	private void InitializeSections()
	{
		Sections = Enum.GetValues(typeof(LogSection)).Cast<LogSection>().ToArray();
	}
}