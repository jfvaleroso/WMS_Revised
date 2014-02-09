using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS.Core.Repositories;
using WMS.Entities;
using WMS.NHibernateBase.Filters;

namespace WMS.NHibernateBase.Repositories
{
    public class NHDocumentMappingRepository : NHRepositoryBase<DocumentMapping, long>, IDocumentMappingRepository
    {
        public List<DocumentMapping> GetDataByNode(string nodeId)
        {
            return this.FindAll(MappingFilter.Search(nodeId), MappingFilter.Alias);
        }
    }
}
