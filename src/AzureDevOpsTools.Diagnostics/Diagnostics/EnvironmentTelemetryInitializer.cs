using System.Diagnostics;

using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;

namespace AzureDevOpsTools.Diagnostics
{
    internal class EnvironmentTelemetryInitializer : ITelemetryInitializer
    {
        private const string Channel = "zip";

        public void Initialize(ITelemetry telemetry)
        {
            telemetry.Context.GlobalProperties["Environment"] = Channel;
            // Always default to development if we're in the debugger
            if (Debugger.IsAttached)
            {
                telemetry.Context.GlobalProperties["Environment"] = "development";
            }
        }
    }
}
