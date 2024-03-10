using TaskManager.ViewModels;

namespace TaskManager.Views;

public partial class MainView : ContentPage
{
	public MainView(MainViewModel viewModel)
	{
		InitializeComponent();
		viewModel.Navigation = Navigation;
		BindingContext = viewModel;
	}
}