using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskManager.Models;
using TaskManager.Repositories;

namespace TaskManager.ViewModels;

public partial class ItemViewModel : ViewModel
{
    private readonly ITaskItemRepository _taskItemRepository;

    [ObservableProperty]
    TaskItem item;

    public ItemViewModel(ITaskItemRepository taskItemRepository)
    {
        _taskItemRepository = taskItemRepository;
        Item = new TaskItem() { Due = DateTime.Now.AddHours(1) };
    }

    [RelayCommand]
    public async Task SaveAsync()
    {
        await _taskItemRepository.AddOrUpdateAsync(Item);
        await Navigation.PopAsync();
    }
}
