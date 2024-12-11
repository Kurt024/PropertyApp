using Microsoft.Maui;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace propertyApp;

public partial class homePage : ContentPage
{
    private databaseHelper _databaseHelper;

    private List<property> allProperties;
    public ObservableCollection<property> FilteredProperties { get; set; } = new ObservableCollection<property>();

    public homePage()
    {
        InitializeComponent();

        string databasePath = FileSystem.AppDataDirectory + "/users.db3";
        _databaseHelper = new databaseHelper(databasePath);

        DisplayProperties();

        // Button and ScrollView UI setup
        setActivebutton(homeButton, "#597445");
        ResetButtonStyle(villageButton);
        ResetButtonStyle(apartmentButton);

        homeScrollView.IsVisible = true;
        villageScrollView.IsVisible = false;
        apartmentScrollView.IsVisible = false;

        homeButton.Opacity = 1;
        setStyleLabel(Home, "597445");
        homeNavigation.Opacity = 1;
        Home.Opacity = 1;

        LoadProperties();
        propertiesCollectionView.ItemsSource = FilteredProperties;
    }

    private void LoadProperties()
    {
        allProperties = _databaseHelper.GetProperties(); 
        UpdateFilteredProperties(allProperties);
    }
    private void UpdateFilteredProperties(IEnumerable<property> properties)
    {
        FilteredProperties.Clear();
        foreach (var prop in properties)
        {
            FilteredProperties.Add(prop);
        }
    }
    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var searchText = e.NewTextValue?.ToLower() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(searchText))
        {
            UpdateFilteredProperties(allProperties);
        }
        else
        {
            var filtered = allProperties.Where(p => p.City != null && p.City.ToLower().Contains(searchText));
            UpdateFilteredProperties(filtered);
        }
    }

    private void homeButton_Clicked(object sender, EventArgs    e)
    {
        setActivebutton(homeButton, "#597445");
        ResetButtonStyle(villageButton);
        ResetButtonStyle(apartmentButton);

        homeScrollView.IsVisible = true;
        villageScrollView.IsVisible = false;
        apartmentScrollView.IsVisible = false;
    }

    private void villageButton_Clicked(object sender, EventArgs e)
    {
        setActivebutton(villageButton, "#597445");
        ResetButtonStyle(homeButton);
        ResetButtonStyle(apartmentButton);

        villageScrollView.IsVisible = true;
        homeScrollView.IsVisible = false;
        apartmentScrollView.IsVisible = false;
    }

    private void apartmentButton_Clicked(object sender, EventArgs e)
    {
        setActivebutton(apartmentButton, "#597445");
        ResetButtonStyle(homeButton);
        ResetButtonStyle(villageButton);

        apartmentScrollView.IsVisible = true;
        homeScrollView.IsVisible = false;
        villageScrollView.IsVisible = false;

    }
    private void setStyleLabel(Label label, string backgroundColorHex)
    {
        label.TextColor = Color.FromArgb(backgroundColorHex);
    }
    private void resetLabel(Label label)
    {
        label.TextColor = Colors.Black;
        label.Opacity = .5;
    }
    private void setActivebutton(Button button, string backgroundColorHex) 
    {
        button.BackgroundColor = Color.FromArgb(backgroundColorHex);
        button.TextColor = Colors.White;
    }
    private void ResetButtonStyle(Button button)
    {
        button.BackgroundColor = Colors.Transparent;
        button.TextColor = Colors.Black;
    }

    private async void homeNavigation_Clicked(object sender, EventArgs e)
    {
        setStyleLabel(Home, "597445");
        resetLabel(Message);
        resetLabel(Discover);
        resetLabel(Myhome);
        resetLabel(User);

        Home.Opacity = 1;

        homeNavigation.Opacity = 1;
        messages.Opacity = .5;
        discover.Opacity = .5;
        myhome.Opacity = .5;
        userbutton.Opacity = .5;

        await Navigation.PushAsync(new homePage());
    }

    private async void messages_Clicked(object sender, EventArgs e)
    {
        setStyleLabel(Message, "597445");
        resetLabel(Home);
        resetLabel(Discover);
        resetLabel(Myhome);
        resetLabel(User);

        Message.Opacity = 1;

        homeNavigation.Opacity = .5;
        messages.Opacity = 1;
        discover.Opacity = .5;
        myhome.Opacity = .5;
        userbutton.Opacity = .5;

        await Navigation.PushAsync(new messages());   
    }

    private async void discover_Clicked(object sender, EventArgs e)
    {
        setStyleLabel(Discover, "597445");
        resetLabel(Home);
        resetLabel(Message);
        resetLabel(Myhome);
        resetLabel(User);

        Discover.Opacity = 1;

        homeNavigation.Opacity = .5;
        messages.Opacity = .5;
        discover.Opacity = 1;
        myhome.Opacity = .5;
        userbutton.Opacity = .5;

        await Navigation.PushAsync(new discover());
    }

    private async void myhome_Clicked(object sender, EventArgs e)
    {
        setStyleLabel(Myhome, "597445");
        resetLabel(Home);
        resetLabel(Message);
        resetLabel(Discover);
        resetLabel(User);

        Myhome.Opacity = 1;

        homeNavigation.Opacity = .5;
        messages.Opacity = .5;
        discover.Opacity = .5;
        myhome.Opacity = 1;
        userbutton.Opacity = .5;

        await Navigation.PushAsync(new myhome());
    }

    private async void userbutton_Clicked(object sender, EventArgs e)
    {
        setStyleLabel(User, "597445");
        resetLabel(Message);
        resetLabel(Discover);
        resetLabel(Myhome);
        resetLabel(Home);

        User.Opacity = 1;

        homeNavigation.Opacity = .5;
        messages.Opacity = .5;
        discover.Opacity = .5;
        myhome.Opacity = .5;
        userbutton.Opacity = 1;

        await Navigation.PushAsync(new profile());
    }
    private void DisplayProperties()
    {
        if (_databaseHelper == null)
        {
            Debug.WriteLine("Error: _propertyDatabase is null");
            return;
        }

        var properties = _databaseHelper.GetProperties();

        if (properties == null || !properties.Any())
        {
            Debug.WriteLine("No properties found in the database.");
        }
        else
        {
            Debug.WriteLine($"Properties loaded: {properties.Count()}");
        }

        propertiesCollectionView.ItemsSource = properties;
    }
}