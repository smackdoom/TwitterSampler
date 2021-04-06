using System;
using Microsoft.EntityFrameworkCore;

namespace TwitterSampler.Data.Queries.Repositories
{
    public class BaseQueriesRepository<T>
        where T : DbContext
    {
        protected readonly T DatabaseContext;

        public BaseQueriesRepository(T databaseContext)
        {
            DatabaseContext = databaseContext;
        }
    }
}
