using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobsPortal.Infrastructure.UnitOfWork;
using System.Data.Entity;

namespace JobsPortal.Infrastructure.EntityFramework.UnitOfWork
{
    public class EntityFrameworkUnitOfWorkProvider : UnitOfWorkProviderBase
    {
        private readonly Func<DbContext> dbContextFactory;

        public EntityFrameworkUnitOfWorkProvider(Func<DbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public override IUnitOfWork Create()
        {
            UowLocalInstance.Value = new EntityFrameworkUnitOfWork(dbContextFactory);
            return UowLocalInstance.Value;
        }
    }
}
