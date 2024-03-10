using TaskManager.Repositories;

namespace TaskManager.ViewModels;

public class ItemViewModel : ViewModel
{
    private readonly ITaskItemRepository _taskItemRepository;

    public ItemViewModel(ITaskItemRepository taskItemRepository)
    {
        _taskItemRepository = taskItemRepository;
    }
}
