using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace WMS.Entities
{
    public class Workflow : Entity<long>
    {
        [Required]
        public virtual string Code { get; set; }
        [Required]
        public virtual string Name { get; set; }
         [Required]
        public virtual string Description { get; set; }
        public virtual IList<Node> Nodes { get; set; }
    


        public Workflow()
        {
            this.Nodes = new List<Node>();
        }
    }
}
