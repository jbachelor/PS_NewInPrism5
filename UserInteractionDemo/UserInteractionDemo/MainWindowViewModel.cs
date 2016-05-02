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

            ConfirmationRequest = new InteractionRequest<IConfirmation>();
            ConfirmationCommand = new DelegateCommand(RaiseConfirmation);

            CustomPopupRequest = new InteractionRequest<INotification>();
            CustomPopupCommand = new DelegateCommand(RaiseCustomPopup);
        }

        private void RaiseCustomPopup()
        {
            string ts = DateTime.Now.ToString();
            CustomPopupRequest.Raise(new Notification { Title = "Custom Popup Thingy", Content = $"Super duper custom job. Oh yeah!{lf}{lf}{ts}" }, 
                result => Status = "Custom good to go stuff");
        }
        
        private void RaiseConfirmation()
        {
            string ts = $"{DateTime.Now}";
            ConfirmationRequest.Raise(new Confirmation
            {
                Title = "Neato Confirmation Title",
                Content = $"This is a cautionary tale of a confirmation message you love to read.{lf}{lf}{ts}"
            }, result => Status = result.Confirmed ? $"Confirmed!{lf}{lf}{ts}" : $"Nope... Not confirmed.{lf}{lf}{ts}");
        }

        private void RaiseNotification()
        {
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

        string lf = $"{System.Environment.NewLine}";


        public InteractionRequest<INotification> NotificationRequest { get; set; }
        public ICommand NotificationCommand { get; set; }
        public InteractionRequest<IConfirmation> ConfirmationRequest { get; set; }
        public ICommand ConfirmationCommand { get; set; }
        public InteractionRequest<INotification> CustomPopupRequest { get; set; }
        public ICommand CustomPopupCommand { get; set; }
    }
}
