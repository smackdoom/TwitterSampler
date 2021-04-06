using System;
using System.Threading.Tasks;

namespace TwitterSampler.Interfaces
{
    public interface IUtilityService
    {
        Task<T> GetEmbeddedJsonFile<T>(string resourceName);
    }
}
