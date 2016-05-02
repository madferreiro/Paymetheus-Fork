using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for TransactionUserControl.xaml
    /// </summary>
    public partial class TransactionUserControl : UserControl
    {

        public enum TransactionStatus
        {
            Pending,
            Invalid,
            Confirmed
        }

        private TransactionStatus status { get; set; }
        public TransactionStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                ChangeStatus();
            }
        }

        public TransactionUserControl()
        {
            this.InitializeComponent();

        }

        private void ChangeStatus()
        {
            confirmedSignal.Visibility = System.Windows.Visibility.Hidden;

            if (Status == TransactionStatus.Pending)
            {
                lblText.Text = "... Pending";
                lblText.Foreground = (Brush)this.Resources["PendingColor"];
                rectangle.Stroke = (Brush)this.Resources["PendingColor"];
            }
            else if (Status == TransactionStatus.Invalid)
            {
                lblText.Text = "X  Invalid";
                lblText.Foreground = (Brush)this.Resources["InvalidColor"];
                rectangle.Stroke = (Brush)this.Resources["InvalidColor"];

            }
            else if (Status == TransactionStatus.Confirmed)
            {
                lblText.Text = "    Confirmed";
                lblText.Foreground = (Brush)this.Resources["ConfirmedColor"];
                confirmedSignal.Visibility = System.Windows.Visibility.Visible;

                rectangle.Stroke = (Brush)this.Resources["ConfirmedColor"];

            }
            else
            {
                lblText.Text = "No Status";
                lblText.Foreground = Brushes.Gray;
                rectangle.Stroke = Brushes.Gray;
            }
        }
    }
}