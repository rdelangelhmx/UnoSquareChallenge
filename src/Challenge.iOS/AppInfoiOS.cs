using Challenge.Interfaces;
using Challenge.iOS;
using Foundation;

[assembly: Xamarin.Forms.Dependency(typeof(AppInfoiOS))]
namespace Challenge.iOS
{
    public class AppInfoiOS : IAppInfo
    {
        public AppInfoiOS()
        {
        }

        public string GetPackageName => NSBundle.MainBundle.BundleIdentifier;
    }
}