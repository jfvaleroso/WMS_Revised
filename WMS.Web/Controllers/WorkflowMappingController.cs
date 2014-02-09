using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WMS.Core.Services.IServices;
using WMS.Web.Helper;
using WMS.Web.Filter;
using WMS.Web.Models;
using WMS.Core.Helper.Common;
using WMS.Entities;

namespace WMS.Web.Controllers
{
    public class WorkflowMappingController : Controller
    {
        #region Constructor
        private readonly IProcessService processService;
        private readonly ISubProcessService subProcessService;
        private readonly IClassificationService classificationService;
        private readonly IWorkflowService workflowService;
        private readonly IDocumentService documentService;
        private readonly IDocumentMappingService documentMappingService;
        private readonly INodeService nodeService;
        private readonly Service service;

        public WorkflowMappingController(IProcessService processService, ISubProcessService subProcessService, IClassificationService classificationService, IWorkflowService workflowService, IDocumentMappingService documentMappingService, IDocumentService documentService, INodeService nodeService)
        {
            this.processService = processService;
            this.subProcessService = subProcessService;
            this.classificationService = classificationService;
            this.workflowService = workflowService;
            this.documentMappingService = documentMappingService;
            this.documentService = documentService;
            this.nodeService = nodeService;
            this.service = new Service(documentService, processService, subProcessService, classificationService);
        }
        #endregion
        #region Index
        [CryptoValueProvider]
        public ActionResult Index(long id = 0, long code = 0)
        {
            if (id != 0)
            {
                try
                {
                    WorkflowMappingModel model = new WorkflowMappingModel();
                    Workflow workflow = this.workflowService.GetDataById(id);
                   
                    //get workflowId
                    model.WorkflowId = id;
                    model.NodeId = code.ToString();
                    model.SecuredId = Base.Encrypt(id.ToString());
                    //node
                    model.WorkflowName = string.Format("{0} : {1}", workflow.Code, workflow.Name);
                    model.OperatorList = this.service.GetOperatorList("OR", "AND");
                    model.ProcessList = this.service.GetProcessList(0);        
                    if (model != null)
                        return View(model);
                }
                catch (Exception)
                {

                }
            }
            return RedirectToAction("Index","Workflow");
        }
        
        #endregion
        #region Node
        public JsonResult NodeListWithPaging(long id=0,string searchString = "", int jtStartIndex = 1, int jtPageSize = 15)
        {
            try
            {
                long total = 0;
                var nodeList = this.nodeService.GetDataListWithPagingAndSearch(searchString, id, jtStartIndex, jtPageSize, out total);
                var collection = nodeList.Select(x => new
                {
                    WorkflowName = Common.GenerateWorkflowName(x.Workflow, x.Process, x.SubProcess, x.Classification),
                    NodeSecuredId= Base.Encrypt(x.Id.ToString()),
                    WorklowSecuredId = Base.Encrypt(x.Workflow.Id.ToString())
                });
                return Json(new { Result = "OK", Records = collection, TotalRecordCount = total }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { Result = "ERROR", Message = "error" });
            }

        }
        #endregion



    }
}
