using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS.Web.Models
{
    public class NodeModel
    {
        public long NodeId { get; set; }
        public string WorkflowName { get; set; }
        public string ProcessName { get; set; }
        public string SubProcessName { get; set; }
        public string ClassificationName { get; set; }
    }
}