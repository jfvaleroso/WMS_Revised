using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS.Core.Repositories;
using WMS.Core.Services.IServices;
using WMS.Entities;


namespace WMS.Core.Services.Implementation
{
    public class ActivityLogsService: IActivityLogsService
    {
        private readonly IActivityLogsRepository activityLogsRepository;
        public ActivityLogsService(IActivityLogsRepository activityLogsRepository)
        {
            this.activityLogsRepository = activityLogsRepository;
        }

        public ActivityLogs GetDataById(long id)
        {
            return this.activityLogsRepository.Get(id);
        }

      
        public List<ActivityLogs> GetAllData()
        {
            return this.activityLogsRepository.GetAll().ToList();
        }
        public List<ActivityLogs> GetDataListWithPaging(int pageNumber, int pageSize, out long total)
        {
            return this.activityLogsRepository.GetDataWithPaging(pageNumber, pageSize, out total);
        }

        public List<ActivityLogs> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize, out long total)
        {
            return this.activityLogsRepository.GetDataWithPagingAndSearch(searchString, pageNumber, pageSize, out total);
        }

        public void Save(ActivityLogs entity)
        {
            this.activityLogsRepository.Save(entity);
        }

        public long Create(ActivityLogs entity)
        {
            return this.activityLogsRepository.Create(entity);
        }

        public void CreateAuditLog(string userName, string ipAddress, string areaAccessed,  DateTime timeAccessed, string action, string result )
        {
            ActivityLogs entity = new ActivityLogs();
            entity.Description = string.Format("IP Address: {0}, Area Access: {1}, Result: {2}", ipAddress, areaAccessed, result);
            entity.ExecutedBy = userName;
            entity.Timestamp = timeAccessed;
            entity.Type = action;
            this.activityLogsRepository.Create(entity);
        }

        public void SaveChanges(ActivityLogs entity)
        {
            this.activityLogsRepository.SaveChanges(entity);
        }

        public void SaveOrUpdate(ActivityLogs entity)
        {
            this.activityLogsRepository.SaveOrUpdate(entity);
        }

      


        public List<ActivityLogs> GetDataListByStatus(bool isActive)
        {
            throw new NotImplementedException();
        }

        public bool CheckDataIfExists(ActivityLogs entity)
        {
            return false;
        }

        public bool CheckDataAndCodeIfExist(ActivityLogs entity)
        {
            return false;
        }

        public bool CheckDataIfExists(string param)
        {
            return false;
        }

        public void Delete(long id)
        {
            this.activityLogsRepository.Delete(id);
        }
    }
}
