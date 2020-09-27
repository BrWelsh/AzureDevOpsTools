using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureDevOpsTools.Framework.ViewModels
{
    public interface IViewModel
    {
        Task InitializeAsync(object parameter);
    }
}
