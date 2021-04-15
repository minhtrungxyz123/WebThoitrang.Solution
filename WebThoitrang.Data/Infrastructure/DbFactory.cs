using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebThoitrang.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private WebThoitrangDbContext dbContext;

        public WebThoitrangDbContext Init()
        {
            return dbContext ?? (dbContext = new WebThoitrangDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
