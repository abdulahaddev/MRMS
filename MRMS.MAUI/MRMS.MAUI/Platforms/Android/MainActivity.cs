using Android.App;
using Android.Content.PM;
using Android.OS;

namespace MRMS.MAUI.Platforms.Android;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.SmallestScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.ScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
}
