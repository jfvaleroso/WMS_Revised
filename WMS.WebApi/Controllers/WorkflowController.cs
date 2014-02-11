using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WMS.Core.Services.IServices;
using WMS.Entities;
using WMS.WebApi.Entities;

namespace WMS.WebApi.Controllers
{
    public class WorkflowController : ApiController
    {
        #region Constructor
        private readonly IWorkflowService workflowService;
        private readonly IDocumentMappingService documentMappingService;
        private readonly INotificationMappingService notificationMappingService;
        private readonly IWorkflowMappingService workflowMappingService;
        private readonly INodeService nodeService;
        private readonly IStatusService statusService;
    
        public WorkflowController(IWorkflowService workflowService, IDocumentMappingService documentMappingService,
            INotificationMappingService notificationMappingService, IWorkflowMappingService workflowMappingService,
            IStatusService statusService,
            INodeService nodeService)
        {
            this.workflowService = workflowService;
            this.documentMappingService = documentMappingService;
            this.notificationMappingService = notificationMappingService;
            this.workflowMappingService = workflowMappingService;
            this.nodeService = nodeService;
        }
        #endregion
        #region Workflow Mapping
        /// <summary>
        /// GetWorkflowMapping
        /// </summary>
        /// <param name="workflow code"></param>
        /// <param name="process code"></param>
        /// <param name="subProcess code"></param>
        /// <param name="classification code"></param>
        /// <returns></returns>
        /// 
        public IEnumerable<WorkflowMappingModel> GetWorkflowMapping(string workflow, string process, string subProcess, string classification)
        {
            Node node = this.nodeService.GetNodeByCode(workflow, process, subProcess, classification);
            var workflowMappingList = this.workflowMappingService.GetDataByNode(node.Id.ToString());
            List<WorkflowMappingModel> modelList = new List<WorkflowMappingModel>();
            foreach (var item in workflowMappingList)
            {
                WorkflowMappingModel model = new WorkflowMappingModel();
                model.LevelId = item.LevelId;
                model.SLA = item.SLA;
                model.Operator = item.Operator;
                model.Assignee = item.Assignee;
                model.AlertTo = item.AlertTo;
                model.SMSNotification = item.SMSNotification;
                model.EmailNotification = item.EmailNotification;
                model.Active = item.Active;
                modelList.Add(model);
            }
            return modelList;
        }
        public HttpResponseMessage GetWorkflowMappingByLevel(string workflow, string process, string subProcess, string classification, int level = 0)
        {
            Node node = this.nodeService.GetNodeByCode(workflow, process, subProcess, classification);
            var workflowMapping = this.workflowMappingService.GetDataByNode(node.Id.ToString(),level).FirstOrDefault();
            WorkflowMappingModel model = new WorkflowMappingModel();
            if (workflowMapping!= null)
            {
                model.LevelId = workflowMapping.LevelId;
                model.SLA = workflowMapping.SLA;
                model.Operator = workflowMapping.Operator;
                model.Assignee = workflowMapping.Assignee;
                model.AlertTo = workflowMapping.AlertTo;
                model.SMSNotification = workflowMapping.SMSNotification;
                model.EmailNotification = workflowMapping.EmailNotification;
                model.Active = workflowMapping.Active;
                return this.Request.CreateResponse(HttpStatusCode.OK, model);
            }
            return this.Request.CreateResponse(HttpStatusCode.NotFound);
            
        }
        public List<string> GetPendingApproval(string workflow, string process, string subProcess, string classification, int level, string roles)
        {
            Node node = this.nodeService.GetNodeByCode(workflow, process, subProcess, classification);
            var workflowMapping = this.workflowMappingService.GetDataByNode(node.Id.ToString(), level).FirstOrDefault();
            List<string> output = new List<string>();
            if (workflowMapping != null)
            {
                string[] approved = roles.Split(',');
                string[] assignee = workflowMapping.Assignee.Split(',');
                foreach (var p in assignee)
                {
                    if (!approved.Contains(p))
                    {
                        output.Add(p);
                    }
                }
            }
            else { throw new HttpResponseException(HttpStatusCode.NotFound); }
            return  output;
        }
        //public async Task<IHttpActionResult> GetBookDetail(int id)
        //{
        //     Node node = this.nodeService.GetNodeByCode(workflow, process, subProcess, classification);
        //     var workflowMapping = await this.workflowMappingService.GetDataByNode(node.Id.ToString(), level).FirstOrDefaultAsync();
        //     if (workflowMapping == null)
        //     {
        //        return NotFound();
        //     }
        //     return Ok(book);
        //}
        #endregion
        #region Document Mapping
        public IEnumerable<DocumentMappingModel> GetDocumentMapping(string workflow, string process, string subProcess, string classification)
        {
            Node node = this.nodeService.GetNodeByCode(workflow, process, subProcess, classification);
            var documentMappingList = this.documentMappingService.GetDataByNode(node.Id.ToString());
            List<DocumentMappingModel> modelList = new List<DocumentMappingModel>();
            foreach (var item in documentMappingList)
            {
                DocumentMappingModel model = new DocumentMappingModel();
                model.Active = item.Active;
                model.Code = item.Document.Code;
                model.Description = item.Document.Description;
                model.Mandatory = item.Mandatory;
                model.Name = item.Document.Name;
                model.NodeId = item.Node.Id;
                modelList.Add(model);
            }
            return modelList;
        }
        #endregion
        #region Notification Mapping
        public IEnumerable<NotificationMappingModel> GetNotificationMapping(string workflow, string process, string subProcess, string classification)
        {
            Node node = this.nodeService.GetNodeByCode(workflow, process, subProcess, classification);
            var notificationMappingList = this.notificationMappingService.GetDataByNode(node.Id.ToString());
            List<NotificationMappingModel> modelList = new List<NotificationMappingModel>();
            foreach (var item in notificationMappingList)
            {
                NotificationMappingModel model = new NotificationMappingModel();
                model.EmailContent = item.EmailContent;
                model.SMSContent = item.SMSContent;
                model.StatusCode = item.Status.Code;
                model.StatusName = item.Status.Name;
                modelList.Add(model);
            }
            return modelList;

        }
        public NotificationMappingModel GetNotificationMappingByStatus(string workflow, string process, string subProcess, string classification,string status)
        {
           
            Node node = this.nodeService.GetNodeByCode(workflow, process, subProcess, classification);
            var notificationMapping = this.notificationMappingService.GetDataByNode(node.Id.ToString(), status).FirstOrDefault();
            NotificationMappingModel model = new NotificationMappingModel();
            if (notificationMapping != null)
            {

                model.EmailContent = notificationMapping.EmailContent;
                model.SMSContent = notificationMapping.SMSContent;
                model.StatusCode = notificationMapping.Status.Code;
                model.StatusName = notificationMapping.Status.Name;

            }
            return model;
        }
        #endregion

         
    }


}
