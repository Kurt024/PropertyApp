using propertyApp;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;

namespace propertyApp;

public partial class listing : ContentPage
{
    private databaseHelper _propertyDatabase;
    public listing()
    {
        InitializeComponent();
        _propertyDatabase = new databaseHelper(FileSystem.AppDataDirectory + "/users.db3");
        LoadProperties();
    }
    private void LoadProperties()
    {
        try
        {
            var properties = _propertyDatabase.GetProperties();
            propertyList.ItemsSource = properties;
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"Failed to load properties: {ex.Message}", "OK");
        }
    }
        
    private async void editButton_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is int propertyId)
        {
            var property = _propertyDatabase.GetProperty(propertyId);

            if (property != null)
            {
                await Navigation.PushAsync(new updatePage(property));
            }
            else
            {
                await DisplayAlert("Error", "Property not found.", "OK");
            }
        }
    }

    private async void deleteButton_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is int propertyId)
        {
            bool isConfirmed = await DisplayAlert("Confirm Deletion", "Are you sure you want to delete this property?", "Yes", "No");

            if (isConfirmed)
            {
                try
                {
                    _propertyDatabase.DeleteProperty(propertyId);

                    LoadProperties();

                    await DisplayAlert("Success", "Property deleted successfully.", "OK");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", $"Failed to delete property: {ex.Message}", "OK");
                }
            }
        }
    }

    private async void addProperty_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new sellmyHome());
    }

    private async void backButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}