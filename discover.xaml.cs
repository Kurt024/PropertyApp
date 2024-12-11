namespace propertyApp;

public partial class discover : ContentPage
{
	public discover()
	{
		InitializeComponent();
	}

    private async void backButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }
}