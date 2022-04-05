
using System;
using System.Collections.Generic;
using System.Text;

namespace FormationXamForms.Notifications
{
    public interface INotification
    {
        void CreateNotification(String title, String message);
    }
}
