using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMS.Entities
{
    public class Node : Entity<long> 
    {
        public virtual Workflow Workflow { get; set; }
        public virtual Process Process { get; set; }
        public virtual SubProcess SubProcess { get; set; }
        public virtual Classification Classification { get; set; }


    }
}
