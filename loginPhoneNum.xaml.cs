namespace propertyApp;

public partial class loginPhoneNum : ContentPage
{
    private databaseHelper _databaseHelper;
	public loginPhoneNum()
	{
        InitializeComponent();

        _databaseHelper = new databaseHelper(FileSystem.AppDataDirectory + "/users.db3");
	}

    private async void backButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }

    private async void logInButton_Clicked(object sender, EventArgs e)
    {
        var user = _databaseHelper.GetUserPhoneNum(phoneNumEntry.Text);
        if (user == null || user.Password != passwordEntry.Text)
        {
            await DisplayAlert("Error", "There is no account associated with this number", "Ok");
        }
        else
        {
            await Navigation.PushAsync(new homePage());
        }       
    }

    private async void signUpButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new signUpPage());
    }
}