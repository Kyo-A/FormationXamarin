using FormationXamForms.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormationXamForms.Background
{
    public class Ticker
    {
        public async Task TickTock(CancellationToken token)
        {
            await Task.Run(async () =>
            {
                int counter = 0;
                while (true)
                {
                    token.ThrowIfCancellationRequested();
                    await Task.Delay(1000);
                    counter += 1;
                    StatusMessage status = new StatusMessage() { msg = string.Format("The app has been running for {0} seconds!", counter) };
                    Device.BeginInvokeOnMainThread(() => { MessagingCenter.Send<StatusMessage>(status, "StatusMessage"); });
                }
            });
        }
    }
}
