using System;
using Microsoft.EntityFrameworkCore;

namespace TwitterSampler.Data.Commands
{
    public abstract class BaseCommands<T>
        where T : DbContext
    {
        protected readonly T DatabaseContext;

        public BaseCommands(T databaseContext)
        {
            DatabaseContext = databaseContext;
        }
    }
}
