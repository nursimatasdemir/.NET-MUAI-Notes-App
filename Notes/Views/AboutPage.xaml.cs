namespace Notes.Views;

public partial class AboutPage : ContentPage
{
	public const double MyFontSize = 22;
	public AboutPage()
	{
		InitializeComponent();
	}
}
public class GlobalFontSizeExtension : IMarkupExtension
{
	public object ProvideValue(IServiceProvider serviceProvider)
	{
		return AboutPage.MyFontSize;
	}
}