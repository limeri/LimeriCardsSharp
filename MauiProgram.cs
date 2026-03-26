using Serilog;
using LimeriCardsSharp.Controllers;
using LimeriCardsSharp.Models;
using Microsoft.Extensions.Logging;

namespace LimeriCardsSharp
{
    /// <summary>
    /// MAUI application configuration and dependency injection setup.
    /// Configures services, logging, and initializes the MAUI application.
    /// </summary>
    public static class MauiProgram
    {
        /// <summary>
        /// Creates and configures the MAUI application.
        /// Sets up dependency injection, logging, fonts, and services.
        /// </summary>
        /// <returns>A configured MauiApp instance ready to run.</returns>
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    // Add application fonts
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .Services
                // Configure logging
                .AddLogging(configure =>
                {
                    configure.AddDebug();
                    configure.SetMinimumLevel(LogLevel.Debug);
                })
                // Register singleton services for dependency injection
                .AddSingleton<MainPage>()
                .AddSingleton<DeckController>()
                .AddSingleton<GameController>()
                .AddSingleton<ViewFactory>();

            return builder.Build();
        }
    }
}
