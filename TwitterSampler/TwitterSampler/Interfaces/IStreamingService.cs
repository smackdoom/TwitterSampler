using System;
using System.Threading.Tasks;

namespace TwitterSampler.Interfaces
{
    public interface IStreamingService
    {
        public Task StartAsync();
        public Task StopAsync();
    }
}
