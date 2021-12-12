using Android.App;
using Challenge.Droid;
using Challenge.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(AppInfoAndorid))]
namespace Challenge.Droid
{
    public class AppInfoAndorid : IAppInfo
    {
        public AppInfoAndorid()
        {
        }

        public string GetPackageName => Application.Context.PackageName; 
    }
}