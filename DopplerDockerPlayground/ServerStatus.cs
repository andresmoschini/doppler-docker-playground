using System;
using System.Net;
using System.Threading;

namespace DopplerDockerPlayground
{
    public class ServerStatus
    {
        public string ServerId { get; } = Guid.NewGuid().ToString();
        public string MachineName { get; } = Environment.MachineName;
        public string GetHostName { get; } = Dns.GetHostName();
        public string AspNetCoreEnvironment { get; } = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        int _serverCounter = 0;
        public int GetAndIncrementCounter() => Interlocked.Add(ref _serverCounter, 1);
    }
}
