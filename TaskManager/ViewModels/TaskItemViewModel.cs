using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskManager.Models;

namespace TaskManager.ViewModels;

public partial class TaskItemViewModel : ViewModel
{
    public TaskItemViewModel(TaskItem item) => Item = item;
    public event EventHandler ItemStatusChanged;

    [ObservableProperty]
    TaskItem item;
    public string StatusText => Item.Completed ? "Reactivate" : "Completed";

    [RelayCommand]
    void ToggleCompleted()
    {
        Item.Completed = !Item.Completed;
        ItemStatusChanged?.Invoke(this, new EventArgs());
    }
}
