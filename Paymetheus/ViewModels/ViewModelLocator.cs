// Copyright (c) 2016 The Decred developers
// Licensed under the ISC license.  See LICENSE file in the project root for full license information

using Paymetheus.Framework;

namespace Paymetheus.ViewModels
{
    public class ViewModelLocator
    {
        public static ShellViewModel ShellViewModel => SingletonViewModelLocator.Resolve("ShellView") as ShellViewModel;
        public static OverviewViewModel OverviewViewModel => SingletonViewModelLocator.Resolve("Overview") as OverviewViewModel;
        public static RequestViewModel RequestViewModel => SingletonViewModelLocator.Resolve("Request") as RequestViewModel;
    }
}
