﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterSampler.Models;
using TwitterSampler.Models.Dto;

namespace TwitterSampler.Data.Interfaces
{
    public interface IHashTagQueries
    {
        Task<TryGetResult<List<ItemCountDto>>> GetTopHashTags();
    }
}
