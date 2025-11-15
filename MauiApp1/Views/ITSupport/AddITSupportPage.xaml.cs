using ClassLibrary.Models;
using MauiApp2.ViewModels;

using ITSupportModel = ClassLibrary.Models.ITSupport;

namespace MauiApp2.Views.ITSupport;

public partial class AddITSupportPage : ContentPage
{
	private ITSupportsViewModel _viewModel;
	public AddITSupportPage(ITSupportsViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;


        //SpecializationPicker from the .xaml saves athe enum values
        /*
        Enum.GetValues expects a Type as input.
        typeof(...) gives the enum type ( Library.ITSupport.Role)
        Enum.GetValues(Type enumType) returns an array of values, like:
        [Library.ITSupport.Role.Network,
         Library.ITSupport.Role.Software,
         Library.ITSupport.Role.Hardware,
         Library.ITSupport.Role.Security,
         Library.ITSupport.Role.HelpDesk]
        
        .Cast<Library.ITSupport.Role>()
         Converts each object in the array to the actual enum type (Library.ITSupport.Role)

        .ToList() Converts the IEnumerable<Library.ITSupport.Role> into a List<Library.ITSupport.Role>.
         */
        SpecializationPicker.ItemsSource = Enum.GetValues(typeof(ITSupportModel.Role))
                                       .Cast<ITSupportModel.Role>()
                                       .ToList();

    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
	{
        //no exception handling
        _viewModel.NewUserId = int.Parse(IdInput.Text);
        _viewModel.NewUserName = NameInput.Text;
        _viewModel.NewEmail = EmailInput.Text;
        _viewModel.NewIsActve = IsActiveSwitch.IsToggled;

        if (SpecializationPicker.SelectedItem != null)
        {
            _viewModel.NewSpecialization = (ITSupportModel.Role)SpecializationPicker.SelectedItem;
        }

        _viewModel.AddITSupport();

        await DisplayAlert("Success", $"IT Support {_viewModel.NewUserName} added!", "OK");
        await Navigation.PopAsync();
    }
}