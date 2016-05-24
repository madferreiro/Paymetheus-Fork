// Copyright (c) 2016 The Decred developers
// Licensed under the ISC license.  See LICENSE file in the project root for full license information.

using Paymetheus.Decred.Wallet;
using Paymetheus.Framework;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Paymetheus.ViewModels
{
    sealed class RequestViewModel : ViewModelBase
    {
        public RequestViewModel(ShellViewModel shell) : base(shell)
        {
            _generateAddressCommand = new DelegateCommand(GenerateAddressAction);
        }

        // TODO: This should be moved to the shell (or some other global context), as well as the
        // active account. Changing the active account in one place should change it everywhere.
        private List<string> _accountNames = new List<string>();

        private string _generatedAddress;
        public string GeneratedAddress
        {
            get { return _generatedAddress; }
            set { _generatedAddress = value; RaisePropertyChanged(); }
        }

        private DelegateCommand _generateAddressCommand;
        public ICommand GenerateAddressCommand => _generateAddressCommand;

        private async void GenerateAddressAction()
        {
            try
            {
                _generateAddressCommand.Executable = false;
                var account = new Account(0); // TODO: use selected account
                var address = await App.Current.WalletRpcClient.NextExternalAddressAsync(account);
                GeneratedAddress = address;
            }
            catch (Exception ex)
            {
                // TODO: stop using messagebox for error reporting
                MessageBox.Show($"Error occurred when requesting address:\n\n{ex}", "Error");
            }
            finally
            {
                _generateAddressCommand.Executable = true;
                CommandManager.InvalidateRequerySuggested();
            }
        }
    }
}
