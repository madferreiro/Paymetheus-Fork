using Paymetheus.DTO;
using Paymetheus.Helpers;
using System;
using System.Collections.Generic;

namespace Paymetheus
{
    public partial class Overview
    {
        private OverviewViewModel _overviewViewModel { get; set; }

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
    }
}