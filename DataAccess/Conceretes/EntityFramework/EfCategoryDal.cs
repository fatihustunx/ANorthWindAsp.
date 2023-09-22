using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Conceretes.EntityFramework.Contexts;
using Entities.Conceretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Conceretes.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category,NorthwindContext>, ICategoryDal
    {
        
    }
}