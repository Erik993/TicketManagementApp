using MauiApp2.ViewModels;

namespace MauiApp2.Views.ITSupport;

public partial class ShowITSupportsPage : ContentPage
{
	private ITSupportsViewModel _viewModel;
	public ShowITSupportsPage(ITSupportsViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
        BindingContext = _viewModel;
    }


}