﻿namespace Application.Common.Interfaces
{
    using System;
    using System.Threading.Tasks;

    public interface IResponseCacheService
    {
        Task CacheResponseAsync(string key, object response, TimeSpan cachingTime);

        Task<string> GetCachedResponseAsync(string cacheKey);
    }
}