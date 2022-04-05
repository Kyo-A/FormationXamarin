using FormationXamForms.Common.Styles;
using FormationXamForms.iOS.Themes;
using FormationXamForms.Themes;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using static FormationXamForms.App;

[assembly: Dependency(typeof(ThemeHelper))]
namespace FormationXamForms.iOS.Themes
{
    public class ThemeHelper : IAppTheme
    {
        public void SetAppTheme(App.Theme theme)
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