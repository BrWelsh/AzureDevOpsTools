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

        protected virtual ILogger Logger { get => logger; }

        public bool IsBusy { get => isBusy; protected set => this.RaiseAndSetIfChanged(ref isBusy, value); }

        public bool IsReady { get => isReady; protected set => this.RaiseAndSetIfChanged(ref isReady, value); }

        public bool IsInitializing { get => isInitializing; private set => this.RaiseAndSetIfChanged(ref isInitializing, value); }

        public async Task InitializeAsync(object parameter)
        {
            IsInitializing = true;
            IsBusy = true;
            IsReady = false;
            try
            {
                await DoInitializeAsync(parameter);
            }
            finally
            {
                IsInitializing = false;
                IsBusy = false;
                IsReady = true;
            }
        }

        protected virtual Task DoInitializeAsync(object parameter)
        {
            // TODO: remove magic strings
            Logger.LogError("Override of DoInitializeAsync() is required");

#pragma warning disable RCS1079 // Throwing of new NotImplementedException.
            throw new NotImplementedException("Override of DoInitialiseAsync must implemented.");
#pragma warning restore RCS1079 // Throwing of new NotImplementedException.
        }
    }
}
