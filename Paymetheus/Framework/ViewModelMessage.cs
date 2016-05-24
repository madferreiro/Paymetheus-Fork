// Copyright (c) 2016 The btcsuite developers
// Copyright (c) 2016 The Decred developers
// Licensed under the ISC license.  See LICENSE file in the project root for full license information.

namespace Paymetheus.Framework
{
    public class ViewModelMessageBase { }

    sealed class OpenDialogMessage : ViewModelMessageBase
    {
        public OpenDialogMessage(DialogViewModelBase dialog)
        {
            Dialog = dialog;
        }

        public DialogViewModelBase Dialog { get; }
    }

    sealed class HideDialogMessage : ViewModelMessageBase { }
}
