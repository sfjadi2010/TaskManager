using TaskManager.Repositories;

namespace TaskManager.ViewModels;

public class MainViewModel : ViewModel
{
    private readonly ITaskItemRepository _taskItemRepository;

    public MainViewModel(ITaskItemRepository taskItemRepository)
    {
        _taskItemRepository = taskItemRepository;
        Task.Run(async () => await LoadDataAsync());
    }

    private async Task LoadDataAsync()
    {

    }
}
