using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TaskManager.Models;
using TaskManager.Repositories;
using TaskManager.Views;

namespace TaskManager.ViewModels;

public partial class MainViewModel : ViewModel
{
    private readonly ITaskItemRepository _taskItemRepository;
    private readonly IServiceProvider _serviceProvider;
    [ObservableProperty]
    ObservableCollection<TaskItemViewModel> items;
    public MainViewModel(ITaskItemRepository taskItemRepository, IServiceProvider serviceProvider)
    {
        taskItemRepository.OnItemAdded += (sender, item) => items.Add(CreateTaskItemViewModel(item));
        taskItemRepository.OnItemUpdated += (sender, item) => Task.Run(async() => await LoadDataAsync());

        _taskItemRepository = taskItemRepository;
        _serviceProvider = serviceProvider;
        Task.Run(async () => await LoadDataAsync());
    }

    [RelayCommand]
    public async Task AddItemAsync() => await Navigation.PushAsync(_serviceProvider.GetRequiredService<ItemView>());

    private async Task LoadDataAsync()
    {
        var items = await _taskItemRepository.GetItemsAsync();
        var itemViewModels = items.Select(item => CreateTaskItemViewModel(item));
        Items = new ObservableCollection<TaskItemViewModel>(itemViewModels);
    }

    private TaskItemViewModel CreateTaskItemViewModel(TaskItem item)
    {
        var taskItemViewModel = new TaskItemViewModel(item);
        taskItemViewModel.ItemStatusChanged += async (sender, e) => await LoadDataAsync();
        return taskItemViewModel;
    }

    private void ItemStatusChanged(object sender, EventArgs e)
    {

    }
}
