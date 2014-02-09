using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace WMS.Entities
{
    public class Status: Entity<int>
    {

        [Required]
        public virtual string Code { get; set; }
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual string Description { get; set; }
        public virtual IList<NotificationMapping> NotificationMappings { get; set; }
        public Status()
        {
            this.NotificationMappings = new List<NotificationMapping>();
        }
    }
}
