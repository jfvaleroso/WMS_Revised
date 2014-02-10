using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS.Core.Repositories;
using WMS.Entities;
using WMS.NHibernateBase.Filters;

namespace WMS.NHibernateBase.Repositories
{
    public class NHNodeRepository : NHRepositoryBase<Node, long>, INodeRepository
    {
        //tester
        public List<Node> GetDataWithPagingAndSearch(string searchString, int pageIndex, int pageSize, out long total)
        {
            return this.GetDataWithPagingAndSearch(NodeFilter.Search(searchString, 1), NodeFilter.Alias, NodeFilter.Orders(), pageIndex, pageSize, out total);
        }

        public List<Node> GetDataWithPagingAndSearch(string searchString, long id, int pageNumber, int pageSize, out long total)
        {
            return this.GetDataWithPagingAndSearch(NodeFilter.Search(searchString, id), NodeFilter.Alias, NodeFilter.Orders(), pageNumber, pageSize, out total);

        }
        //get node by workflow Id, process id,subprocess id, classification id
        public Node GetNode(string workflow, string process, string subProcess, string classification)
        {
            return this.FindAll(NodeFilter.Search(workflow, process, subProcess, classification), NodeFilter.Alias).FirstOrDefault();

        }
        //get node by workflow code, process code,subprocess code, classification code
        public Node GetNodeByCode(string workflow, string process, string subProcess, string classification)
        {
            return this.FindAll(NodeFilter.SearchByCode(workflow, process, subProcess, classification,"na"), NodeFilter.Alias).FirstOrDefault();

        }
      
    }
}
