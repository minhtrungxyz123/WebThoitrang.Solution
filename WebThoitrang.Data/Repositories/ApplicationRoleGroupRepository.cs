using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebThoitrang.Data.Infrastructure;
using WebThoitrang.Model.Models;

namespace WebThoitrang.Data.Repositories
{
    public interface IApplicationRoleGroupRepository : IRepository<ApplicationRoleGroup>
    {

    }
    public class ApplicationRoleGroupRepository : RepositoryBase<ApplicationRoleGroup>, IApplicationRoleGroupRepository
    {
        public ApplicationRoleGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
