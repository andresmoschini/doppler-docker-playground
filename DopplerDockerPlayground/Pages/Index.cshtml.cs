using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DopplerDockerPlayground.Pages
{
    public class IndexModel : PageModel
    {
        public string ServerId { get; }

        public int ServerCounter { get; }

        public string MachineName { get; }

        public string GetHostName { get; }

        public PlaygroundSettings PlaygroundSettings { get; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger,
            ServerStatus serverStatus,
            IOptions<PlaygroundSettings> playgroundSettingsAccessor)
        {
            _logger = logger;
            ServerId = serverStatus.ServerId;
            ServerCounter = serverStatus.GetAndIncrementCounter();
            MachineName = serverStatus.MachineName;
            GetHostName = serverStatus.GetHostName;
            PlaygroundSettings = playgroundSettingsAccessor.Value;
        }

        public void OnGet()
        {

        }
    }
}
