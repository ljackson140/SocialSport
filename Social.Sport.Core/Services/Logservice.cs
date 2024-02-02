using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Options;
using Social.Sport.Core.Interfaces.Services;

namespace Social.Sport.Core.Services
{
    public class LogService : ILogService
    {
        private readonly TelemetryClient _telemetryClient;
        public LogService(IOptions<TelemetryConfiguration> options)
        {
            _telemetryClient = new TelemetryClient(options.Value);
        }

        public void Warning(string message)
        {
            _telemetryClient.TrackTrace(message);
        }
        public void Failure(Exception ex, string message)
        {

            var properties = new Dictionary<string, string>()
            {
                ["Log Level"] = "Error",
                ["Log Message"] = message,

            };
            _telemetryClient.TrackTrace(message);
            _telemetryClient.TrackException(ex, properties);
        }
        public void Failure(string message)
        {

            var properties = new Dictionary<string, string>()
            {
                ["Log Level"] = "Error",
                ["Log Message"] = message,
            };


            Exception ex = new Exception(message);
            _telemetryClient.TrackTrace(message);
            _telemetryClient.TrackException(ex, properties);
        }

        public void Failure(Exception ex)
        {
            _telemetryClient.TrackTrace(ex.Message);
            _telemetryClient.TrackException(ex);
        }
    }
}
