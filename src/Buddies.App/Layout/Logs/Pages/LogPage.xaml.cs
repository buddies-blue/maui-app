namespace Buddies.App.Layout.Logs.Pages;

public partial class LogPage : ContentPage
{

	private static readonly BindableProperty SectionsProperty = BindableProperty.Create(nameof(Sections), typeof(IEnumerable<LogSection>), typeof(LogPage), defaultBindingMode: BindingMode.OneTime);

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

	private void InitializeSections()
	{
		Sections = Enum.GetValues(typeof(LogSection)).Cast<LogSection>().ToArray();
	}
}