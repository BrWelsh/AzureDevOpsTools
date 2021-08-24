//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Brian Welsh, welshnson.com">
//     Copyright (c) Brian Welsh, welshnson.com. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.ComponentModel;

using AzureDevOpsTools.Interop;
using AzureDevOpsTools.Model.Settings;

using MahApps.Metro.Controls;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AzureDevOpsTools.Presentation.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
#pragma warning disable IDE0032 // Use auto property

        private readonly ILogger logger;
        private readonly UserPreferences userPreferences;

        public MainWindow(
                IOptions<UserPreferences> userPrefs,
                ILogger<MainWindow> logger)
            : this()
        {
            this.logger = logger;
            userPreferences = userPrefs?.Value;

            Closing += MainWindow_Closing;
        }

        private MainWindow()
        {
            InitializeComponent();
        }

        private ILogger Logger => logger;

#pragma warning disable CA1031 // Do not catch general exception types

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            try
            {
                LoadSettings();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error loading settings.");
            }
        }

#pragma warning restore CA1031 // Do not catch general exception types

        private void LoadSettings()
        {
            this.LoadWindowPlacementFromSettings(userPreferences.WindowPlacement);
        }

        private void SaveSettings()
        {
            userPreferences.WindowPlacement = this.SaveWindowPlacementToSettings();
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            SaveSettings();
        }

#pragma warning restore IDE0032 // Use auto property
    }
}
