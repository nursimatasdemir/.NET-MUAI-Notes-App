using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace Notes.ViewModels;

internal class AboutViewModel
{
    public string Title => AppInfo.Name;
    public string Version => AppInfo.VersionString;
    public string MoreInfoUrl => "https://aka.ms/maui";
    public string Message => "This app is written in XAML and C# with .NET MUAI.";
    public ICommand ShowMoreInfoCommand { get; }
    public AboutViewModel()
    {
        //Komutlar kodu çağırabilen bağlanabilir aksiyonlar bu yüzden uygulama logicini buraya eklemek en mantıklısı
        ShowMoreInfoCommand = new AsyncRelayCommand(ShowMoreInfo);
    }
    async Task ShowMoreInfo() =>
        await Launcher.Default.OpenAsync(MoreInfoUrl);

}
