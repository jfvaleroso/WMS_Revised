﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS.Entities;

namespace WMS.Core.Repositories
{
    public interface IProcessRepository : IRepository<Process, int>, ISearchRepository<Process>
    {
       
    }
}
