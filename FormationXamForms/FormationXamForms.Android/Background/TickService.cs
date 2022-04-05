using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FormationXamForms.Models.Tasks;
using FormationXamForms.Background;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormationXamForms.Droid.Background
{
    [Service]
    class TickService : Service
    {
        CancellationTokenSource cts;

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int id)
        {
            cts = new CancellationTokenSource();
            Task.Run(() =>
            {
                try
                {
                    Ticker t = new Ticker();
                    t.TickTock(cts.Token).Wait();
                }
                catch (Android.OS.OperationCanceledException)
                {
                    if (cts.IsCancellationRequested)
                    {
                        CancelledMessage msg = new CancelledMessage();
                        Device.BeginInvokeOnMainThread(() => MessagingCenter.Send(msg, "CancelledMessage"));
                    }
                }
            }, cts.Token);

            return StartCommandResult.Sticky;
        }

        public override void OnDestroy()
        {
            if (cts != null)
            {
                cts.Token.ThrowIfCancellationRequested();
                cts.Cancel();
            }
            base.OnDestroy();
        }
    }
}
