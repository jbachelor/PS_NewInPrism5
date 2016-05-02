using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserInteractionDemo
{
    /// <summary>
    /// Interaction logic for CustomPopupView.xaml
    /// </summary>
    public partial class CustomPopupView : UserControl, IInteractionRequestAware // NOTE: You would probably have a viewmodel to implement IInteractionRequestAware, but this is for simplicity of the demo.
    {
        public CustomPopupView()
        {
            InitializeComponent();
        }

        #region IInteractionRequestAware Implementation

        public Action FinishInteraction { get; set; }
        public INotification Notification { get; set; }

        #endregion IInteractionRequestAware Implementation

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (FinishInteraction != null)
                FinishInteraction();
        }
    }
}
