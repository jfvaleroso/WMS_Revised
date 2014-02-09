using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS.Core.Repositories;
using WMS.Core.Services.IServices;
using WMS.Entities;

namespace WMS.Core.Services.Implementation
{
    public class NodeService: INodeService
    {
        private readonly INodeRepository nodeRepository;
        public NodeService(INodeRepository nodeRepository)
        {
            this.nodeRepository = nodeRepository;
        }
        public Node GetDataById(long id)
        {
            return this.nodeRepository.Get(id);
        }

        public List<Node> GetDataListWithPaging(int pageNumber, int pageSize, out long total)
        {
            return this.nodeRepository.GetDataWithPaging(pageNumber, pageSize, out total);
        }

        public List<Node> GetDataListWithPagingAndSearch(string searchString, int pageNumber, int pageSize, out long total)
        {
            return this.nodeRepository.GetDataWithPagingAndSearch(searchString, pageNumber, pageSize, out total);
        }
        public List<Node> GetDataListWithPagingAndSearch(string searchString,long id, int pageNumber, int pageSize, out long total)
        {
            return this.nodeRepository.GetDataWithPagingAndSearch(searchString, id,pageNumber, pageSize, out total);
        }

        public void Save(Node entity)
        {
            this.nodeRepository.Save(entity);
        }

        public long Create(Node entity)
        {
            return this.nodeRepository.Create(entity);
        }

        public void SaveChanges(Node entity)
        {
            this.nodeRepository.SaveChanges(entity);
        }

        public void Delete(long id)
        {
            this.nodeRepository.Delete(id);
        }


        public List<Node> GetDataListByStatus(bool active)
        {
            return this.nodeRepository.Get(x => x.Active.Equals(active)).ToList();
        }

        public bool CheckDataIfExists(Node entity)
        {
            return false;
        }

        public bool CheckDataAndCodeIfExist(Node entity)
        {
            return false;
        }

        public bool CheckDataIfExists(string param)
        {
            return false;
        }


        public Node GetNode(string workflow, string process, string subProcess, string classification)
        {
            var node = this.nodeRepository.GetNode(workflow, process, subProcess, classification);
            if (node != null)
            { return node; }
            return new Node();
           
        }



    }
}
