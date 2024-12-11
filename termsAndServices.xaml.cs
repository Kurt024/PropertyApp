namespace propertyApp;

public partial class termsAndServices : ContentPage
{
	public termsAndServices()
	{
		InitializeComponent();
	}

    private async void proceedButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }
}