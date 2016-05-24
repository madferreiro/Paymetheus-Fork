// Copyright (c) 2016 The btcsuite developers
// Copyright (c) 2016 The Decred developers
// Licensed under the ISC license.  See LICENSE file in the project root for full license information.

namespace Paymetheus.Framework
{
    class WizardDialogViewModelBase : ViewModelBase
    {
        public WizardDialogViewModelBase(ShellViewModelBase shell, WizardViewModelBase wizard)
            : base(shell)
        {
            _shell = shell;
            _wizard = wizard;
        }

        protected ShellViewModelBase _shell;
        protected WizardViewModelBase _wizard;
    }
}
