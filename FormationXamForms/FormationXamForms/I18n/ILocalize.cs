using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FormationXamForms.I18n
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
        void SetLocale();
    }
}
