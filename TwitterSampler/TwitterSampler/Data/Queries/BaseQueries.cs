using System;
using Microsoft.EntityFrameworkCore;

namespace TwitterSampler.Data.Queries
{
    public abstract class BaseQueries<T>
        where T : DbContext
    {
        protected readonly T DatabaseContext;

        public BaseQueries(T databaseContext)
        {
            DatabaseContext = databaseContext;
        }
    }
}
