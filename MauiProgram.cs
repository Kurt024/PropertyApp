using Microsoft.Extensions.Logging;

namespace propertyApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("SFPRODISPLAYREGULAR.OTF", "SfProRegular");
                    fonts.AddFont("SFPRODISPLAYBOLD.OTF", "SfProBold");
                    fonts.AddFont("SFPRODISPLAYMEDIUM.OTF", "SfProMedium");
                    fonts.AddFont("SFPRODISPLAYSEMIBOLD.OTF", "SfProSemiBold");
                    fonts.AddFont("SFPRODISPLAYTHINITALICE.OTF", "SfProThin");
                    fonts.AddFont("lekton005_l.otf", "Lekton");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
