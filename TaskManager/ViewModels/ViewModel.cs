using CommunityToolkit.Mvvm.ComponentModel;

namespace TaskManager.ViewModels;

[ObservableObject]
public abstract partial class ViewModel 
{
    public INavigation Navigation { get; set; } = null!;
}
