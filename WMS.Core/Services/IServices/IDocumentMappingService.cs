using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS.Entities;

namespace WMS.Core.Services.IServices
{
    public interface IDocumentMappingService : IService<DocumentMapping, long>
    {
        List<DocumentMapping> GetFilteredDataByWorkflow(Workflow workflow);
        List<DocumentMapping> GetDataByNode(string nodeId);

        void DeleteDocumentMapping(Workflow workflow);
    }
}
