using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WMS.Entities;

namespace WMS.Web.Helper
{
    public class Common
    {
        public static string GenerateWorkflowName(Workflow workflow, Process process, SubProcess subProcess, Classification classification)
        {
            if (classification != null)
            { 
            return  string.Format("{0} {1}", string.Empty, classification.Name);
            }
            else if(subProcess !=null)
            {
                return string.Format("{0} {1}", string.Empty, subProcess.Name);
            }
             else if(process !=null)
            {
                return string.Format("{0} {1}", string.Empty, process.Name);
            }
            else
            {
                return string.Format("{0} {1} (Default workflow)", string.Empty, workflow.Name);
            }
        }
    }
}