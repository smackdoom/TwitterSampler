using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterSampler.Models.Data;

namespace TwitterSampler.Data.Interfaces
{
    public interface IUrlCommands
    {
        Task AddUrl(Url url);
        Task AddUrls(List<Url> urls);
    }
}
