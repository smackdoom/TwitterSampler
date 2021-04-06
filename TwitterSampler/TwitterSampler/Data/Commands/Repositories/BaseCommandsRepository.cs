using System;
using Microsoft.EntityFrameworkCore;

namespace TwitterSampler.Data.Commands.Repositories
{
    public class BaseCommandsRepository<T>
        where T : DbContext
    {
        protected readonly T DatabaseContext;

        public BaseCommandsRepository(T databaseContext)
        {
            DatabaseContext = databaseContext;
        }
    }
}
