﻿using Paymetheus.Decred;
using Paymetheus.Rpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Paymetheus
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
                var account = new Decred.Wallet.Account(0); throw new NotImplementedException();
                var address = await App.Current.WalletRpcClient.NextExternalAddressAsync(account);
                GeneratedAddress = address;
            }
            catch (Exception ex)
            {
                // TODO: 
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