using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Interfaces
{
    public interface IUrlService
    {
        Task<bool> SaveUrl(Url url);
        Task<bool> SaveUrls(List<Url> urls);
    }
}
