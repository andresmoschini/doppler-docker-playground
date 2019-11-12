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
        public string ServerId { get; }

        public int ServerCounter { get; }

        public string MachineName { get; }

        public string GetHostName { get; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, ServerStatus serverStatus)
        {
            _logger = logger;
            ServerId = serverStatus.ServerId;
            ServerCounter = serverStatus.GetAndIncrementCounter();
            MachineName = serverStatus.MachineName;
            GetHostName = serverStatus.GetHostName;
        }

        public void OnGet()
        {

        }
    }
}
