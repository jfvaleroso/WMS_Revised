using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS.Entities;

namespace WMS.Core.Repositories
{
    public interface IWorkflowMappingRepository: IRepository<WorkflowMapping, long>, ISearchRepository<WorkflowMapping>
    {
        List<WorkflowMapping> GetDataByNode(string nodeId);
        List<WorkflowMapping> GetDataByNode(string nodeId, int levelId);
    }
}
