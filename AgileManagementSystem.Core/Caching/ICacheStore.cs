using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Core.Caching
{
    public interface ICacheStore<TModel>
    {
        /// <summary>
        /// Keye göre cachler
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <param name="model"></param>
        void Set(string cacheKey, TModel model);
        /// <summary>
        /// Keye göre Cache getirir
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        TModel Get(string cacheKey);
        /// <summary>
        /// Cahce temizler
        /// </summary>
        /// <param name="cacheKey"></param>
        void Clear(string cacheKey);
    }
}
