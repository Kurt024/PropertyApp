namespace propertyApp;

public partial class myhome : ContentPage
{
	public myhome()
	{
		InitializeComponent();
	}

    private async void backButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}