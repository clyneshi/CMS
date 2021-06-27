using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CMS.DAL.Repository.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<Role> Filter(Expression<Func<Role, bool>> predicate);
        IEnumerable<Role> GetAll();
    }
}