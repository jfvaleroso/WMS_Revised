using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WMS.Entities;

namespace WMS.Core.Services.IServices
{
    public interface INodeService:IService<Node, long>
    {
        List<Node> GetDataListWithPagingAndSearch(string searchString, long id, int pageNumber, int pageSize, out long total);
        Node GetNode(string workflow, string process, string subProcess, string classification);
    }
}
