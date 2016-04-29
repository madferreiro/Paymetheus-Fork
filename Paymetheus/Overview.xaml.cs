using Paymetheus.DTO;
using Paymetheus.Helpers;
using System;
using System.Collections.Generic;

namespace Paymetheus
{
    public partial class Overview
    {
        public Overview()
        {
            this.InitializeComponent();

            var lstTest = new List<RecentActivity>();
            lstTest.Add(new RecentActivity()
            {
                Ammount = 12.23,
                Confirmations = 3,
                IsDeposit = true,
                OperatingTo = "Tsbg8qouweyraksjdhfui123wf5g",
                Status = TransactionUserControl.TransactionStatus.Confirmed,
                TransactionLocalTime = DateTime.Now,
                WalletName = "TestWallet"
            });
            lstTest.Add(new RecentActivity()
            {
                Ammount = 9.3,
                Confirmations = 1,
                IsDeposit = false,
                OperatingTo = "Tsbg8qouweyraksjdhfui123wf5g",
                Status = TransactionUserControl.TransactionStatus.Pending,
                TransactionLocalTime = DateTime.Now.AddHours(-1),
                WalletName = "TestWallet"
            });
            lstTest.Add(new RecentActivity()
            {
                Ammount = 20,
                Confirmations = 0,
                IsDeposit = false,
                OperatingTo = "Tsbg8qouweyraksjdhfui123wf5g",
                Status = TransactionUserControl.TransactionStatus.Invalid,
                TransactionLocalTime = DateTime.Now.AddDays(-3).AddMinutes(40),
                WalletName = "TestWallet2"
            });
            lstRecentActivity.ItemsSource = lstTest;
            lstRecentActivity.MouseDoubleClick += TxSelected;
        }

        private void TxSelected(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var selectedItem = (RecentActivity)lstRecentActivity.SelectedItem;
            Navigator.GetInstance().NavigateTo(new OverviewDeeper(selectedItem));
        }
        
        
    }
}