﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormationXamForms.Services
{
    public interface IPageService
    {
        Task PushAsync(Page page);

        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);

        Task DisplayAlert(string title, string message, string ok);

        Task<Page> PopAsync();
    }
}
