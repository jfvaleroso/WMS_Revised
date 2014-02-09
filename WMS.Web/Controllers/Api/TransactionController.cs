using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WMS.Core.Services.IServices;
using WMS.Entities;
using WMS.Web.Helper;
using WMS.Web.Models;

namespace WMS.Web.Controllers.Api
{
    public class TransactionController : ApiController
    {

   #region Constructor    
        #region Constructor
        private readonly IWorkflowService workflowService;
        private readonly IProcessService processService;
        private readonly ISubProcessService subProcessService;
        private readonly IClassificationService classificationService;
        private readonly INodeService nodeService;
        private readonly IDocumentMappingService documentMappingService;
        private readonly IWorkflowMappingService workflowMappingService;
        private readonly INotificationMappingService notificationMappingService;


        private readonly Service service;
        public TransactionController(IWorkflowService workflowService, 
                           IProcessService processService, 
                           ISubProcessService subProcessService, 
                           IClassificationService classificationService, INodeService nodeService,
                           IDocumentMappingService documentMappingService,
                           IWorkflowMappingService workflowMappingService,
                           INotificationMappingService notificationMappingService )
        {
            this.workflowService = workflowService;
            this.processService = processService;
            this.subProcessService= subProcessService;;
            this.classificationService= classificationService;
            this.documentMappingService = documentMappingService;
            this.notificationMappingService = notificationMappingService;
            this.workflowMappingService = workflowMappingService;
            this.nodeService = nodeService;
            this.service = new Service(this.processService, this.subProcessService, this.classificationService);
        }
        #endregion
#endregion

        #region Node
        public IEnumerable<TransactionModel> GetSubProcessByProcessId(int id = 0)
        {
            List<SelectListItem> subProcessList = new List<SelectListItem>();
            List<TransactionModel> model = new List<TransactionModel>();
            subProcessList = service.GetSubProcessList(0, id);
            foreach (var item in subProcessList)
            {
                TransactionModel transaction = new TransactionModel();
                transaction.Value = item.Value;
                transaction.Text = item.Text;
                transaction.Selected = item.Selected;
                model.Add(transaction);
            }
            return model;
        }
        public IEnumerable<TransactionModel> GetClassificationBySubProcessId(int id = 0)
        {
            List<SelectListItem> classificationList = new List<SelectListItem>();
            List<TransactionModel> model = new List<TransactionModel>();
            classificationList = service.GetClassificationList(0, id);
            foreach (var item in classificationList)
            {
                TransactionModel transaction = new TransactionModel();
                transaction.Value = item.Value;
                transaction.Text = item.Text;
                transaction.Selected = item.Selected;
                model.Add(transaction);
            }
            return model;
        }
        public NodeModel GetNodeId(string workflow, string process, string subProcess, string classification)
        {
            Node node = this.nodeService.GetNode(workflow, process, subProcess, classification);
            NodeModel model = new NodeModel();
            if (node != null)
            {
                model.NodeId = node.Id;
                model.WorkflowName = node.Workflow != null ? node.Workflow.Name : string.Empty;
                model.ProcessName = node.Process != null ? node.Process.Name : string.Empty;
                model.SubProcessName = node.SubProcess != null ? node.SubProcess.Name : string.Empty;
                model.ClassificationName = node.Classification != null ? node.Classification.Name : string.Empty;
            }
            return model;
        }
        public NodeModel GetNodeById(string id)
        {
            NodeModel model = new NodeModel();
            if(!string.IsNullOrEmpty(id))
            {
                Node node = this.nodeService.GetDataById(Convert.ToInt64(id));
                if (node != null)
                {
                    model.NodeId = node.Id;
                    model.WorkflowName = node.Workflow != null ? node.Workflow.Id.ToString() : string.Empty;
                    model.ProcessName = node.Process != null ? node.Process.Id.ToString() : string.Empty;
                    model.SubProcessName = node.SubProcess != null ? node.SubProcess.Id.ToString() : string.Empty;
                    model.ClassificationName = node.Classification != null ? node.Classification.Id.ToString() : string.Empty;
                }
            }
           
            return model;
        }
        #endregion
        #region DocumentMapping
        public IEnumerable<DocumentMappingListModel> GetDocumentMappingByNode(string id)
        {
            List<DocumentMappingListModel> documentMappingList = new List<DocumentMappingListModel>();
            var data = this.documentMappingService.GetDataByNode(id);
            foreach (var item in data)
            {
                DocumentMappingListModel model = new DocumentMappingListModel();
                model.Active = item.Active;
                model.Code = item.Document.Code;
                model.Name = item.Document.Name;
                model.Mandatory = item.Mandatory;
                model.NodeId = item.Node.Id;
                model.DocumentId = item.Document.Id;
                documentMappingList.Add(model);
            }
            return documentMappingList;
        }
        #endregion
        #region Workflow Mapping
        public IEnumerable<WorkflowMappingListModel> GetWorkflowMappingByNode(string id)
        {
            List<WorkflowMappingListModel> workflowMappingList = new List<WorkflowMappingListModel>();
            var data = this.workflowMappingService.GetDataByNode(id);
            foreach (var item in data)
            {
                WorkflowMappingListModel model = new WorkflowMappingListModel();
                model.AlertTo = item.AlertTo;
                model.Assignee = item.Assignee;
                model.EmailNotification = item.EmailNotification;
                model.LevelId = item.LevelId;
                model.NodeId = item.Node.Id;
                model.Operator = item.Operator;
                model.SLA = item.SLA;
                model.SMSNotification = item.SMSNotification;
                model.Active = item.Active;
                workflowMappingList.Add(model);
            }
            return workflowMappingList;
        }
        #endregion

    }
}
