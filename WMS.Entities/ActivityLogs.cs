﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMS.Entities
{
    public class ActivityLogs : Entity<long>
    {
        public virtual string Type { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime Timestamp { get; set; }
        public virtual string ExecutedBy { get; set; }

    }
}
