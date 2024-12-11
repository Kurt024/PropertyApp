using SQLite;
using System.Diagnostics.Metrics;
using System.Diagnostics;

namespace propertyApp;

public partial class updatePage : ContentPage
{
    private property _property;
    private databaseHelper databaseHelper;
    public updatePage(property property)
	{
		InitializeComponent();
        string dbPath = FileSystem.AppDataDirectory + "/users.db3";
        _property = property;
        
        databaseHelper = new databaseHelper(dbPath);

        StreetAddress.Text = _property.StreetAddress;
        City.Text = _property.City;
        Country.Text = _property.Country;
        Price.Text = _property.Price;
    }

    private async void saveButton_Clicked(object sender, EventArgs e)
    {
        _property.StreetAddress = StreetAddress.Text;
        _property.City = City.Text;
        _property.Country = Country.Text;
        _property.Price = Price.Text;

        int result = databaseHelper.UpdateProperty(_property);

        if (result > 0)
        {
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "Unable to update the property. Please try again.", "OK");
        }
    }
}