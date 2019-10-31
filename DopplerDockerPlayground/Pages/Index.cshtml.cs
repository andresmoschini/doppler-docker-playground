using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DopplerDockerPlayground.Pages
{
    public class IndexModel : PageModel
    {
        private static readonly string _serverId = Guid.NewGuid().ToString();
        public string ServerId => _serverId;

        private static int _serverCounter = 0;
        public int ServerCounter { get; }

        public string MachineName { get; } = System.Environment.MachineName;

        public string GetHostName { get; } = System.Net.Dns.GetHostName();

        private readonly ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            ServerCounter = System.Threading.Interlocked.Add(ref _serverCounter, 1);
        }

        public void OnGet()
        {

        }
    }
}
