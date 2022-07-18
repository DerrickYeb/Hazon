using Core.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application
{
    public static class CacheKey
    {
        public static string GetCacheKey<T>(object id) where T : BaseEntity
        {
            return $"{typeof(T).Name}-{id}";
        }
        public static string GetCachekey(string name,string id)
        {
            return $"{name}-{id}";
        }
    }
}
