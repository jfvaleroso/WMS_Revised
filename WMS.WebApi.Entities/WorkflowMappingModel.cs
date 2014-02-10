using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMS.WebApi.Entities
{
    public class WorkflowMappingModel
    {
        public int LevelId { get; set; }
        public int SLA { get; set; }
        public string Operator { get; set; }
        public string Assignee { get; set; }
        public string AlertTo { get; set; }
        public bool SMSNotification { get; set; }
        public bool EmailNotification { get; set; }
        public bool Active { get; set; }
    }
}
