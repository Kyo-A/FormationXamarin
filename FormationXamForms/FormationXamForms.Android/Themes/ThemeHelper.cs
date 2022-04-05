using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FormationXamForms.Common.Styles;
using FormationXamForms.Droid.Themes;
using FormationXamForms.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using static FormationXamForms.App;

[assembly: Dependency(typeof(ThemeHelper))]
namespace FormationXamForms.Droid.Themes
{
    public class ThemeHelper : IAppTheme
    {
        public void SetAppTheme(Theme theme)
        {

            SetTheme(theme);
        }
        void SetTheme(Theme mode)
        {
            if (mode == Theme.Dark)
            {
                if (App.AppTheme == Theme.Dark)
                    return;
                App.Current.Resources = new DarkTheme();
            }
            else
            {
                if (App.AppTheme != Theme.Dark)
                    return;
                App.Current.Resources = new LightTheme();
            }
            App.AppTheme = mode;
        }
    }
}