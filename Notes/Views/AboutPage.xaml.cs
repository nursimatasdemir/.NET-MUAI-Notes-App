namespace Notes.Views;

public partial class AboutPage : ContentPage
{
	public const double MyFontSize = 22;
	public AboutPage()
	{
		InitializeComponent();
	}

	private async void LearnMore_Clicked(object sender, EventArgs e)
	{
		if (BindingContext is Models.About about)
		{
			await Launcher.Default.OpenAsync(about.MoreInfoUrl);
		}
	}
}
public class GlobalFontSizeExtension : IMarkupExtension
{
	public object ProvideValue(IServiceProvider serviceProvider)
	{
		return AboutPage.MyFontSize;
	}
}