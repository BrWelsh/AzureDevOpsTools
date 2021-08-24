//-----------------------------------------------------------------------
// <copyright file="IViewModel.cs" company="Brian Welsh, welshnson.com">
//     Copyright (c) Brian Welsh, welshnson.com. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System.Threading.Tasks;

namespace AzureDevOpsTools.Framework.ViewModels
{
    public interface IViewModel
    {
        Task InitializeAsync(object parameter);
    }
}
