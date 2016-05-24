// Copyright (c) 2016 The Decred developers
// Licensed under the ISC license.  See LICENSE file in the project root for full license information

using System;
using System.Collections.Generic;
using System.Windows;

namespace Paymetheus.Framework
{
    public static class SingletonViewModelLocator
    {
        static Dictionary<Type, Func<ViewModelBase>> Factories = new Dictionary<Type, Func<ViewModelBase>>();
        static Dictionary<Type, ViewModelBase> ViewModels = new Dictionary<Type, ViewModelBase>();

        public static void RegisterFactory<TView>(Func<ViewModelBase> factory)
        {
            Factories[typeof(TView)] = factory;
        }

        public static void RegisterFactory<TView, TViewModel>()
            where TView : FrameworkElement
            where TViewModel : ViewModelBase, new()
        {
            RegisterFactory<TView>(() => new TViewModel());
        }

        public static void RegisterInstance<TView>(ViewModelBase viewModel)
            where TView : FrameworkElement
        {
            ViewModels[typeof(TView)] = viewModel;
        }

        public static ViewModelBase Resolve<TView>()
        {
            var viewType = typeof(TView);

            if (ViewModels.ContainsKey(viewType))
            {
                return ViewModels[viewType];
            }

            if (Factories.ContainsKey(viewType))
            {
                var instance = Factories[viewType]();
                ViewModels[viewType] = instance;
                return instance;
            }

            return null;
        }
    }
}
