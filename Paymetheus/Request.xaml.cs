using Paymetheus.ViewModels;
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

namespace Paymetheus
{
    /// <summary>
    /// Interaction logic for Request.xaml
    /// </summary>
    public partial class Request : Page
    {
        public Request()
        {
            InitializeComponent();
        }

        private void buttonGenerate_Click(object sender, RoutedEventArgs e)
        {
            GenerateAnotherBtn.Visibility = Visibility.Visible;
            ButtonGenerate.Visibility = Visibility.Hidden;
            ButtonGenerate.Command = null;
            RectangleGenerate.Visibility = Visibility.Visible;
            LblCode.Visibility = Visibility.Visible;
            var viewmodel = (RequestViewModel)ViewModelLocator.RequestViewModel;
            viewmodel.GenerateAddressAction();
        }
    }
}
