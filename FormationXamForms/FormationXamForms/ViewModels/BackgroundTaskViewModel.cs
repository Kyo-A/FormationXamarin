using FormationXamForms.Models.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FormationXamForms.ViewModels
{
    class BackgroundTaskViewModel : BaseViewModel
    {
        public ICommand StartCommand { get; set; }
        public ICommand StopCommand { get; set; }

        private string _StatusMessage = "";
        public string StatusMessage
        {
            get { return _StatusMessage; }
            set { SetValue(ref _StatusMessage, value); }
        }

        public BackgroundTaskViewModel()
        {
            StartCommand = new Command(StartTicking);
            StopCommand = new Command(StopTicking);
            MonitorMessages();
        }

        public void StartTicking()
        {
            StartMessage msg = new StartMessage();
            MessagingCenter.Send(msg, "StartMessage");
        }

        public void StopTicking()
        {
            StopMessage msg = new StopMessage();
            MessagingCenter.Send(msg, "StopMessage");
        }

        public void MonitorMessages()
        {
            MessagingCenter.Subscribe<StatusMessage>(this, "StatusMessage", msg =>
            {
                StatusMessage = msg.msg;
            });
        }
    }
}
