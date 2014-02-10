using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS.Core.Repositories;
using WMS.Entities;
using WMS.NHibernateBase.Filters;

namespace WMS.NHibernateBase.Repositories
{
    public class NHNotificationMappingRepository : NHRepositoryBase<NotificationMapping, long>, INotificationMappingRepository
    {
        public List<NotificationMapping> GetDataByNode(string nodeId)
        {
            return this.FindAll(MappingFilter.Search(nodeId), MappingFilter.Alias);
        }


        public List<NotificationMapping> GetDataByNode(string nodeId, string status)
        {
            return this.FindAll(MappingFilter.Search(nodeId,status), MappingFilter.Alias);
        }
    }
}
