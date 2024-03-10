using Microsoft.Extensions.Logging;
using TaskManager.Repositories;
using TaskManager.ViewModels;
using TaskManager.Views;

namespace TaskManager;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Register Services
        builder.Services.AddSingleton<ITaskItemRepository, TaskItemRepository>();

        // Register ViewModels
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<ItemViewModel>();

        // Register Views
        builder.Services.AddTransient<MainView>();
        builder.Services.AddTransient<ItemView>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
