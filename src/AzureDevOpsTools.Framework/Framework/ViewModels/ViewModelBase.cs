//-----------------------------------------------------------------------
// <copyright file="ViewModelBase.cs" company="Brian Welsh, welshnson.com">
//     Copyright (c) Brian Welsh, welshnson.com. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using ReactiveUI;

namespace AzureDevOpsTools.Framework.ViewModels
{
    public abstract class ViewModelBase : ReactiveObject, IViewModel
    {
        private readonly ILogger logger;

        private bool isInitializing;
        private bool isBusy;
        private bool isReady;

        protected ViewModelBase(ILogger logger)
        {
            this.logger = logger;
        }

        protected virtual ILogger Logger { get => this.logger; }

        public bool IsBusy { get => this.isBusy; protected set => this.RaiseAndSetIfChanged(ref this.isBusy, value); }

        public bool IsReady { get => this.isReady; protected set => this.RaiseAndSetIfChanged(ref this.isReady, value); }

        public bool IsInitializing { get => this.isInitializing; private set => this.RaiseAndSetIfChanged(ref this.isInitializing, value); }

        public async Task InitializeAsync(object parameter)
        {
            this.IsInitializing = true;
            this.IsBusy = true;
            this.IsReady = false;
            try
            {
                await this.DoInitializeAsync(parameter);
            }
            finally
            {
                this.IsInitializing = false;
                this.IsBusy = false;
                this.IsReady = true;
            }
        }

        protected virtual Task DoInitializeAsync(object parameter)
        {
            // TODO: remove magic strings
            this.Logger.LogError("Override of DoInitializeAsync() is required");

#pragma warning disable RCS1079 // Throwing of new NotImplementedException.
            throw new NotImplementedException("Override of DoInitialiseAsync must implemented.");
#pragma warning restore RCS1079 // Throwing of new NotImplementedException.
        }
    }
}
