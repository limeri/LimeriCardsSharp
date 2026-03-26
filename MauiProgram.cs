using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;

namespace LimeriCardsSharp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp() => MauiApp.CreateBuilder()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Bold.ttf", "OpenSansBold");
            })
            .Build();
    }
}