﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS.Entities;

namespace WMS.Core.Repositories
{
    public interface INotificationMappingRepository : IRepository<NotificationMapping, long>
    {
        List<NotificationMapping> GetDataByNode(string nodeId);
        List<NotificationMapping> GetDataByNode(string nodeId, string status);
    }
}
