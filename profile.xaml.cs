using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
namespace propertyApp;

public partial class profile : ContentPage
{
    private databaseHelper _databaseHelper;
    public profile()
    {
        InitializeComponent();

        _databaseHelper = new databaseHelper(FileSystem.AppDataDirectory + "/users.db3");
    }
    private async void backButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void LogOut_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new continuePage());
    }

    private async void sellhome_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new sellmyHome());
    }

    private async void list_Clicked(object sender, EventArgs e)
    {   
        await Navigation.PushAsync(new listing());
    }
}