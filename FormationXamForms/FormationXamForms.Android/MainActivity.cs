using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Xamarin.Forms;
using FormationXamForms.Models.Tasks;
using Android.Content;
using FormationXamForms.Droid.Background;

namespace FormationXamForms.Droid
{
    [Activity(Label = "FormationXamForms", Icon = "@mipmap/fbb")]
    //[Activity(Label = "FormationXamForms", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            ZXing.Net.Mobile.Forms.Android.Platform.Init();
            LoadApplication(new App());

            Subscribe();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void Subscribe()
        {
            MessagingCenter.Subscribe<StartMessage>(this, "StartMessage", message => { Intent intent = new Intent(this, typeof(TickService)); StartService(intent); });
            MessagingCenter.Subscribe<StopMessage>(this, "StopMessage", message => { Intent intent = new Intent(this, typeof(TickService)); StopService(intent); });
        }
    }
}