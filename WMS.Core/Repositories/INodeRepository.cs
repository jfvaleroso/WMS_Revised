using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS.Entities;

namespace WMS.Core.Repositories
{
    public interface INodeRepository : IRepository<Node, long>, ISearchRepository<Node>
    {
        List<Node> GetDataWithPagingAndSearch(string searchString, long id, int pageNumber, int pageSize, out long total);
        Node GetNode(string workflow, string process, string subProcess, string classification);
    }
}
