namespace propertyApp;

public partial class messages : ContentPage
{
	public messages()
	{
		InitializeComponent();
	}

    private async void backButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}