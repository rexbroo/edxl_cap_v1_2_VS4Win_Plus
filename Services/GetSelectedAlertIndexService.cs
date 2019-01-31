using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace edxl_cap_v1_2.Services
{
    public class GetSelectedAlertIndexService
    {
        private readonly ILogger<GetSelectedAlertIndexService> _logger;

        public GetSelectedAlertIndexService(ILogger<GetSelectedAlertIndexService> logger)
        {
            _logger = logger;
        }

        public Task GetSelectedAlertIndex(int AlertIndex)
        {
            _logger.LogInformation(
                "GetSelectedAlertIndex.GetSelectedAlertIndex");

            return Task.FromResult(0);
        }
    }
}
