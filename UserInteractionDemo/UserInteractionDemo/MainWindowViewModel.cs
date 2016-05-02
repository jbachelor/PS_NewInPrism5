using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UserInteractionDemo
{
    class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
        {
            NotificationRequest = new InteractionRequest<INotification>();
            NotificationCommand = new DelegateCommand(RaiseNotification);
        }

        private void RaiseNotification()
        {
            string lf = $"{System.Environment.NewLine}";
            string timeStamp = $"{DateTime.Now}";
            StringBuilder sb = new StringBuilder("Amazingly clear, concise, enlightening notification goes here, yo.");

            NotificationRequest.Raise(new Notification
            {
                Title = "Catchy yet Informative Title",
                Content = $"{sb.ToString()}{lf}{lf}{timeStamp}"
            },
            result => Status = $"Notification complete, dawg.{lf}{lf}{timeStamp}");
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { SetProperty<string>(ref _status, value); }
        }

        public InteractionRequest<INotification> NotificationRequest { get; set; }
        public ICommand NotificationCommand { get; set; }
    }
}
