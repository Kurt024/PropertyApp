
namespace propertyApp
{
	public partial class continuePage : ContentPage
	{
		public continuePage()
		{
			InitializeComponent();
		}

        private async void loginPhoneNumber_Clicked(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new loginPhoneNum());
        }

        private async void signUpButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new signUpPage());
        }

        private async void logIn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new logInPage());
        }
    }
}