using Paymetheus.DTO;
using Paymetheus.Framework;
using Paymetheus.ViewModels;
using System;
using System.Collections.Generic;

namespace Paymetheus
{
    public partial class Overview
    {
        public Overview()
        {
            InitializeComponent();
            lstRecentActivity.MouseDoubleClick += TxSelected;
        }

        internal Overview(object dataContext) : this()
        {
            DataContext = dataContext;
        }

        private void TxSelected(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var selectedItem = (RecentActivity)lstRecentActivity.SelectedItem;
            Navigator.GetInstance().NavigateTo(new OverviewDeeper(selectedItem));
        }
        
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var overviewViewModel = (OverviewViewModel)ViewModelLocator.OverviewViewModel;
            var shellViewModel = (ShellViewModel)ViewModelLocator.ShellViewModel;
            overviewViewModel.RecentTransactions.Add(shellViewModel.TransactionViewModel);
            return;
        }
    }
}