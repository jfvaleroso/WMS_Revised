using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WMS.Entities
{
    public class Classification: Entity<int>
    {
        [Required]
        public virtual string Code { get; set; }
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual string Description { get; set; }
        public virtual SubProcess SubProcess { get; set; }
        public virtual IList<Node> Nodes { get; set; }
        public Classification()
        {
           
            this.Nodes = new List<Node>();
        }

       
    }
}
