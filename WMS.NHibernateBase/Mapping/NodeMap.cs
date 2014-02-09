using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS.Entities;

namespace WMS.NHibernateBase.Mapping
{
    public class NodeMap : ClassMap<Node>
    {
        public NodeMap()
        {
            Table("Node");
            Id(x => x.Id);
            References(x => x.Workflow, "Workflow_Id");
            References(x => x.Process, "Process_Id");
            References(x => x.SubProcess, "SubProcess_Id");
            References(x => x.Classification, "Classification_Id");
        }
    }
}
