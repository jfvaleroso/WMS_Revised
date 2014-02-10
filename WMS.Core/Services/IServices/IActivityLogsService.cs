using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS.Entities;

namespace WMS.Core.Services.IServices
{
    public interface IActivityLogsService : IService<ActivityLogs, long>
    {
        void CreateAuditLog(string userName, string ipAddress, string areaAccessed, DateTime timeAccessed, string action, string result);
    }
}
