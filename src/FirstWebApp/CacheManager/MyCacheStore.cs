﻿using Microsoft.AspNetCore.OutputCaching;

namespace FirstWebApp.CacheManager
{
    public class MyCacheStore : IOutputCacheStore
    {
        public ValueTask EvictByTagAsync(string tag, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask<byte[]?> GetAsync(string key, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public ValueTask SetAsync(string key, byte[] value, string[]? tags, TimeSpan validFor, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
