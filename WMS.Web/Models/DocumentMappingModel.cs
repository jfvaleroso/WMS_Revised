using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WMS.Entities;

namespace WMS.Web.Models
{
    public class DocumentMappingModel : DocumentMapping
    {
        [Required]
        public long WorkflowId { get; set; }
        public string NodeId { get; set; }
        public string WorkflowName { get; set; }

        [Required]
        [Display(Name="Document")]
        public int DocumentId { get; set; }
        public string SecuredId { get; set; }
        public IList<SelectListItem> DocumentList { get; set; }
        public IList<DocumentMapping> DocumentMappingList { get; set; }
        public IList<Node> NodeList { get; set; }

        //populate node
        public IList<SelectListItem> ProcessList { get; set; }
        //dropdownlist values
        public int? ProcessId { get; set; }
        public int? SubProcessId { get; set; }
        public int? ClassificationId { get; set; }



        public DocumentMappingModel()
        {
            this.DocumentList = new List<SelectListItem>();
            this.DocumentMappingList = new List<DocumentMapping>();
            this.NodeList = new List<Node>();
            //process list
            this.ProcessList = new List<SelectListItem>();
        }
    }
}