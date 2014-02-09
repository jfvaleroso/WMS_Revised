﻿using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS.Core.Helper.Common;
using WMS.Core.Repositories;
using WMS.Entities;

namespace WMS.NHibernateBase.Repositories
{
    public class NHSubProcessRepository : NHRepositoryBase<SubProcess, int>, ISubProcessRepository
    {

        public List<SubProcess> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize, out long total)
        {
            List<ICriterion> criterion = new List<ICriterion>();
            criterion.Add(Restrictions.Or(
                NHibernate.Criterion.Restrictions.Like("Code", Base.SearchString(searchString)),
                NHibernate.Criterion.Restrictions.Like("Name", Base.SearchString(searchString))
                ));
            return this.GetDataWithPagingAndSearch(criterion, searchString, pageIndex, pageSize, out total);
        }

      
    }
}
