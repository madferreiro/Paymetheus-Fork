// Copyright (c) 2016 The btcsuite developers
// Copyright (c) 2016 The Decred developers
// Licensed under the ISC license.  See LICENSE file in the project root for full license information.

using Paymetheus.Helpers;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Paymetheus
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class ShellView : UserControl
    {
        private Navigator _navigator;
        private Overview _overview;
        private Request _request;
        internal ShellViewModel Shell;

        public ShellView()
        {
            InitializeComponent();
            _navigator = Navigator.GetInstance(ContentHolder);
        }

        private LockableToggleButton _toggledSidebarButton;

        private bool ReplaceCheckedSidebarButton(RoutedEventArgs e, LockableToggleButton replacement)
        {
            if (_toggledSidebarButton != replacement)
            {
                if (_toggledSidebarButton != null)
                {
                    _toggledSidebarButton.Locked = false;
                    _toggledSidebarButton.IsChecked = false;
                }
                _toggledSidebarButton = replacement;
                _toggledSidebarButton.Locked = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void RecentActivityToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            var button = (LockableToggleButton)e.Source;
            if (ReplaceCheckedSidebarButton(e, button))
            {
                Console.WriteLine("todo");
            }
        }

        private void AccountToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            var button = (LockableToggleButton)e.Source;
            if (ReplaceCheckedSidebarButton(e, button))
            {
                var selected = (RecentAccountViewModel)button.DataContext;
                if (selected != null)
                {
                    selected.PostMessage(new ShowAccountMessage(selected.Account));
                }
            }
        }

        public void NavigateOverview(object sender, RoutedEventArgs e)
        {
            if (_overview == null && Shell != null)
                _overview = new Overview(Shell._overviewViewModel);
            NavigateTo(_overview);
        }

        public void NavigateAccounts(object sender, RoutedEventArgs e)
        {
            NavigateTo(new Accounts());
        }

        public void NavigateSend(object sender, RoutedEventArgs e)
        {
            NavigateTo(new Send());
        }

        public void NavigateRequest(object sender, RoutedEventArgs e)
        {
            if (_request == null)
            {
                _request = new Request();
                _request.DataContext = new RequestViewModel(Shell);
            }
            NavigateTo(_request);
        }

        public void NavigateHistory(object sender, RoutedEventArgs e)
        {
            NavigateTo(new History());
        }

        public void NavigateUnspent(object sender, RoutedEventArgs e)
        {
            NavigateTo(new Unspent());
        }

        public void NavigateTo(Page page)
        {
            if(_navigator != null)
                _navigator.NavigateTo(page);
        }
    }
}
