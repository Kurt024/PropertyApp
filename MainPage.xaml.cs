namespace propertyApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void getStartedbutton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new continuePage()); 
        }
    }

}
 