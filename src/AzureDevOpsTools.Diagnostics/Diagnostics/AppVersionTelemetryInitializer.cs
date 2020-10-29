//-----------------------------------------------------------------------
// <copyright file="AppVersionTelemetryInitializer.cs" company="Brian Welsh, welshnson.com">
//     Copyright (c) Brian Welsh, welshnson.com. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Linq;
using System.Reflection;

using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;

namespace AzureDevOpsTools.Diagnostics
{
    internal class AppVersionTelemetryInitializer : ITelemetryInitializer
    {
        private readonly string wpfVersion;
        private readonly string appVersion;

        public AppVersionTelemetryInitializer()
        {
            wpfVersion = typeof(System.Windows.Application).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()!.InformationalVersion;
            appVersion = typeof(DiagnosticsClient).Assembly.GetCustomAttributes<AssemblyMetadataAttribute>()
                                                            .First(ama => string.Equals(ama.Key, "CloudBuildNumber", StringComparison.OrdinalIgnoreCase))
                                                            .Value!;
        }

        public void Initialize(ITelemetry telemetry)
        {
            telemetry.Context.GlobalProperties["WPF version"] = wpfVersion;
            telemetry.Context.Component.Version = appVersion;
        }
    }
}
