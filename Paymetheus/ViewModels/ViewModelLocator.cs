// Copyright (c) 2016 The Decred developers
// Licensed under the ISC license.  See LICENSE file in the project root for full license information

using Paymetheus.Framework;

namespace Paymetheus.ViewModels
{
    public class ViewModelLocator
    {
        public object ShellViewModel => SingletonViewModelLocator.Resolve("ShellView");
        public object OverviewViewModel => SingletonViewModelLocator.Resolve("Overview");
    }
}
