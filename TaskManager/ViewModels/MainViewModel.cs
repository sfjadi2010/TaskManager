using CommunityToolkit.Mvvm.Input;
using TaskManager.Repositories;
using TaskManager.Views;

namespace TaskManager.ViewModels;

public partial class MainViewModel : ViewModel
{
    private readonly ITaskItemRepository _taskItemRepository;
    private readonly IServiceProvider _serviceProvider;

    public MainViewModel(ITaskItemRepository taskItemRepository, IServiceProvider serviceProvider)
    {
        _taskItemRepository = taskItemRepository;
        _serviceProvider = serviceProvider;
        Task.Run(async () => await LoadDataAsync());
    }

    [RelayCommand]
    public async Task AddItemAsync() => await Navigation.PushAsync(_serviceProvider.GetRequiredService<ItemView>());

    private async Task LoadDataAsync()
    {

    }
}
