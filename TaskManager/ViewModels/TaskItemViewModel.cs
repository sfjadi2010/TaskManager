using CommunityToolkit.Mvvm.ComponentModel;
using TaskManager.Models;

namespace TaskManager.ViewModels;

public partial class TaskItemViewModel : ViewModel
{
    

    public TaskItemViewModel(TaskItem item) => Item = item;
    public event EventHandler ItemStatusChanged;
    [ObservableProperty]
    TaskItem item;
    public string StatusText => Item.Completed ? "Reactivate" : "Completed";
}
