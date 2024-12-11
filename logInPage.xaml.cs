
namespace propertyApp;

public partial class logInPage : ContentPage
{
    private databaseHelper _databaseHelper;
    public logInPage()
	{
		InitializeComponent();
        _databaseHelper = new databaseHelper(FileSystem.AppDataDirectory + "/users.db3");
    }

    private async void backButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }

    private async void signUpButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new signUpPage());
    }

    private async void logInButton_Clicked(object sender, EventArgs e)
    {

        var user = _databaseHelper.GetuserEmail(emailEntry.Text);

        if (user == null || user.Password != passwordEntry.Text)
        {
            await DisplayAlert("Error", "Invalid username or password", "Ok");
        }
        else
        {       
            await Navigation.PushAsync(new homePage());
        }
    }
}