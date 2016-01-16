using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xaml.Interactivity;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;


namespace RestaurantManager.Extensions
{
    public class RightClickMessageDialogBehavior : DependencyObject, IBehavior
    {
        public string Message { get; set; }
        public string Title { get; set; }

        public DependencyObject AssociatedObject { get; private set; }

        public void Attach(DependencyObject associatedObject)
        {
            if (associatedObject is Page)
            {
                AssociatedObject = associatedObject;
                (AssociatedObject as Page).RightTapped += Page_RightTapped;
            }
        }

        private async void Page_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            await new MessageDialog(Message, Title).ShowAsync();
        }

        public void Detach()
        {
            (AssociatedObject as Page).RightTapped -= Page_RightTapped;
            AssociatedObject = null;
        }
    }
}
