//-----------------------------------------------------------------------
// <copyright file="DiagnosticsClient.cs" company="Brian Welsh, welshnson.com">
//     Copyright (c) Brian Welsh, welshnson.com. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Threading;

using AzureDevOpsTools.Internal;

using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

namespace AzureDevOpsTools.Diagnostics
{
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
#pragma warning disable CA2000 // Dispose objects before losing scope

    public static class DiagnosticsClient
    {
        private static TelemetryClient? telemetryClient;

        public static void Initialize()
        {
            var config = TelemetryConfiguration.CreateDefault();

            config.TelemetryInitializers.Add(new AppVersionTelemetryInitializer());
            config.TelemetryInitializers.Add(new EnvironmentTelemetryInitializer());

            Application.Current.DispatcherUnhandledException += App_DispatcherUnhandledException;
            telemetryClient = new TelemetryClient(config);
        }

        public static void OnExit()
        {
            if (telemetryClient == null) return;
            telemetryClient.Flush();

            // Allow time for flushing and sending:
            System.Threading.Thread.Sleep(LibraryConstants.TelemetryFlushSleepTimeout);
        }

        private static void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            TrackException(e.Exception);
        }

        public static void TrackEvent(string eventName, IDictionary<string, string>? properties = null, IDictionary<string, double>? metrics = null)
        {
            if (telemetryClient == null) return;
            telemetryClient.TrackEvent(eventName, properties, metrics);
        }

        //public static void TrackEvent(string eventName, IPackage package, bool packageIsPublic, IDictionary<string, string>? properties = null, IDictionary<string, double>? metrics = null)
        //{
        //    if (telemetryClient == null) return;

        //    if (packageIsPublic && package != null)
        //    {
        //        properties ??= new Dictionary<string, string>();

        //        properties.Add("packageId", package.Id);
        //        properties.Add("packageVersion", package.Version.ToNormalizedString());
        //    }

        //    telemetryClient.TrackEvent(eventName, properties, metrics);
        //}

        public static void TrackTrace(string evt, IDictionary<string, string>? properties = null)
        {
            if (telemetryClient == null) return;
            telemetryClient.TrackTrace(evt, properties);
        }

        public static void TrackException(Exception exception, IDictionary<string, string>? properties = null, IDictionary<string, double>? metrics = null)
        {
            if (telemetryClient == null) return;
            telemetryClient.TrackException(exception, properties, metrics);
        }

        //public static void TrackException(Exception exception, IPackage package, bool packageIsPublic, IDictionary<string, string>? properties = null, IDictionary<string, double>? metrics = null)
        //{
        //    if (telemetryClient == null) return;

        //    if (packageIsPublic && package != null)
        //    {
        //        properties ??= new Dictionary<string, string>();

        //        properties.Add("packageId", package.Id);
        //        properties.Add("packageVersion", package.Version.ToNormalizedString());
        //    }

        //    telemetryClient.TrackException(exception, properties, metrics);
        //}

        public static void TrackPageView(string pageName)
        {
            if (telemetryClient == null) return;
            telemetryClient.TrackPageView(pageName);
        }
    }
#pragma warning restore CA2000 // Dispose objects before losing scope
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
}
