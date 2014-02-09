using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WMS.Entities;

namespace WMS.Web.Models
{
    public class WorkflowMappingModel : WorkflowMapping
    {
        [Required]
        [Display(Name="Workflow")]
        public long WorkflowId { get; set; }
        public string WorkflowName { get; set; }
        public string NodeId { get; set; }
         [Required]
        public string[] Assignee { get; set; }
        public string[] NoticeTo { get; set; }
        public string SecuredId { get; set; }
       
        public IList<SelectListItem> OperatorList { get; set; }

        //populate node
        public IList<SelectListItem> ProcessList { get; set; }
        //dropdownlist values
        public int? ProcessId { get; set; }
        public int? SubProcessId { get; set; }
        public int? ClassificationId { get; set; }
       

        public WorkflowMappingModel()
        {
           
            this.ProcessList = new List<SelectListItem>();
           
        }
    }
}