
namespace propertyApp;

public partial class signUpPage : ContentPage
{
    private databaseHelper _databasehelper;
	public signUpPage()
	{
		InitializeComponent();

        _databasehelper = new databaseHelper(FileSystem.AppDataDirectory + "/users.db3");             
    }
    private async void backButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
    private async void logIn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new logInPage());
    }

    private async void termsandServices_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new termsAndServices());
    }

    private async void signUpbutton_Clicked(object sender, EventArgs e)
    {
        if (!termsCheckBox.IsChecked) 
        {
            await DisplayAlert("Error", "You need to agree to the terms and Services", "Ok");
            return;
        }
        var user = new userAccounts
        {
            FullName = fullnameEntry.Text,
            PhoneNumber = phoneNumEntry.Text,
            Email = emailEntry.Text,
            Password = passwordEntry.Text
        };
        _databasehelper.AddUser(user);


        await DisplayAlert("Success", "User signed up successfully", "Ok");
        await Navigation.PushAsync(new logInPage());
    }
}