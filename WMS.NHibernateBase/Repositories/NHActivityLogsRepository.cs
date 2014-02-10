using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;
using WMS.NHibernateBase.Repositories;
using WMS.Entities;
using WMS.Core.Repositories;
using WMS.Core.Helper.Common;

namespace WMS.NHibernateBase.Repositories
{
    public class NHActivityLogsRepository : NHRepositoryBase<ActivityLogs, long>, IActivityLogsRepository
    {
        public List<ActivityLogs> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize, out long total)
        {
            List<ICriterion> criterion = new List<ICriterion>();
            criterion.Add(Restrictions.Or(
                NHibernate.Criterion.Restrictions.Like("Description",Base.SearchString(searchString)),
                NHibernate.Criterion.Restrictions.Like("ExecutedBy", Base.SearchString(searchString))
                ));
            return this.GetDataWithPagingAndSearch(criterion, searchString, pageIndex, pageSize, out total);
        }
    }
}
