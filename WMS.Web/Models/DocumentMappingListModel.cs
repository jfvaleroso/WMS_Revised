using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMS.Web.Models
{
    public class DocumentMappingListModel
    {
        public int DocumentId { get; set; }
        public long  NodeId { get; set; }
        public  string Code { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool Mandatory { get; set; }
    }
}