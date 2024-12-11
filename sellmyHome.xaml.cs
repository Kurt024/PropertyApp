
namespace propertyApp;

public partial class sellmyHome : ContentPage
{
    private databaseHelper _propertydatabase;
    private string imagePath;
    public sellmyHome()
	{
		InitializeComponent();
        _propertydatabase = new databaseHelper(FileSystem.AppDataDirectory + "/users.db3");     
    }

    private async void backButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopAsync();
    }

    private async void nextButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                await DisplayAlert("Error", "Please upload an image.", "OK");
                return;
            }

            var newProperty = new property
            {
                StreetAddress = streetAddressEntry.Text,
                City = cityEntry.Text,
                Country = countryEntry.Text,
                Description = descriptionEntry.Text,
                FullnameOwner = fullnameOwnerEntry.Text,
                PhoneNumber = phoneNumEntry.Text,
                Price = priceEntry.Text,
                ImagePath = imagePath
            };

            _propertydatabase.SaveProperty(newProperty); 
            await Navigation.PushAsync(new homePage()); 
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Failed to save property: " + ex.Message, "OK");
        }
    }
    private async void uploadImage_Clicked(object sender, EventArgs e)
    {


        try
        {
            var fileResult = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images 
            });

            if (fileResult != null)
            {
                imagePath = fileResult.FullPath; 

            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Failed to pick file: " + ex.Message, "OK");
        }
    }

}