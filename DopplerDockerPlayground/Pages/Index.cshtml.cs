using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace DopplerDockerPlayground.Pages
{
    public class IndexModel : PageModel
    {
        public ServerStatus ServerStatus { get; }

        public PlaygroundSettings PlaygroundSettings { get; }

        public IEnumerable<KeyValuePair<string, string>> ConfigurationEntries { get; }

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger,
            ServerStatus serverStatus,
            IOptions<PlaygroundSettings> playgroundSettingsAccessor,
            IConfiguration configuration)
        {
            _logger = logger;
            ServerStatus = serverStatus;
            PlaygroundSettings = playgroundSettingsAccessor.Value;
            ConfigurationEntries = configuration.AsEnumerable();
        }

        public void OnGet()
        {

        }
    }
}
