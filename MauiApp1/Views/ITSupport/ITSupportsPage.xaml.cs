using MauiApp2.ViewModels;
using Services;
using MauiApp2.Views;
using ClassLibrary.Models;
using ClassLibraryFactories;

using ITSupportModel = ClassLibrary.Models.ITSupport;


namespace MauiApp2.Views.ITSupport;


public partial class ITSupportsPage : ContentPage
{
	private ITSupportsViewModel _viewModel;
	private JsonFileManager _jsonFileManager = new();
	private ITSupportFactory _itSupportFactory = new();
    
    public ITSupportsPage(ITSupportsViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
    }
	
	private async void ShowITSupportsButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new ShowITSupportsPage(_viewModel));
	}

	
	private async void AddITSupportButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new AddITSupportPage(_viewModel));
	}

	public void SaveITSupportsToJsonClicked(object sender, EventArgs e)
	{
		_jsonFileManager.Save(_viewModel.ITSupports.ToList());
        DisplayAlert("Success", "Employees are saved to JSON file.", "OK");
    }

	public void LoadITSupportsFromJsonClicked(object sender, EventArgs e)
	{
		var loaded = _jsonFileManager.Load<ITSupportModel>();
		foreach (var item in loaded)
		{
			_viewModel.AddITSupport(item);
		}
        DisplayAlert("Success", "ItSupports loaded from JSON file.", "OK");
    }

	public void CreateTestITSupportClicked(object sender, EventArgs e)
	{
		var sup = _itSupportFactory.CreateItem(1);
		_viewModel.AddITSupport(sup);

        DisplayAlert("Success", "Test IT Support is created", "OK");
    }

	public void DeleteITSupportsClicked(object sender, EventArgs e)
	{
		_viewModel.Reset();
        DisplayAlert("Success", "ITSupports are deleted from memory", "OK");
    }


}