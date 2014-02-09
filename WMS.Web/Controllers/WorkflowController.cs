using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WMS.Core.Helper.Common;
using WMS.Core.Services.IServices;
using WMS.Web.Helper;
using WMS.Web.Filter;
using WMS.Web.Models;
using WMS.Entities;
using WMS.Helper.Transaction;
using WMS.Webservice.IServices;

namespace WMS.Web.Controllers
{
    public class WorkflowController : Controller
    {
        
        #region Constructor
        private readonly IWorkflowService workflowService;
        public WorkflowController(IWorkflowService workflowService)
        {         
            this.workflowService = workflowService;
        }
        #endregion
        #region Index
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult WorkflowListWithPaging(string searchString = "", int jtStartIndex = 1, int jtPageSize = 15)
        {
            try
            {
                long total = 0;
                var workflowList = !string.IsNullOrEmpty(searchString) ?
                    this.workflowService.GetDataListWithPagingAndSearch(searchString, jtStartIndex, jtPageSize, out total) :
                   this.workflowService.GetDataListWithPaging(jtStartIndex, jtPageSize, out total);
                var collection = workflowList.Select(x => new
                {
                    Id = x.Id,
                    SecuredId = Base.Encrypt(x.Id.ToString()),
                    Active = x.Active,
                    Code= x.Code,
                    Name= x.Name,
                    Count= x.Nodes.Count()
                });
                return Json(new { Result = "OK", Records = collection, TotalRecordCount = total }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { Result = "ERROR", Message = "error" });
            }
        }
        #endregion
        #region New
        public ActionResult New()
        {
          
            return View();
        }
        [HttpPost]
        public JsonResult New(Workflow model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Workflow workflow = new Workflow();
                    bool ifExists = this.workflowService.CheckDataAndCodeIfExist(model);
                    if (!ifExists)
                    {
                       
                        workflow.Code = model.Code.ToUpper();
                        workflow.Name = model.Name;
                        workflow.Description = model.Description;
                        workflow.Active = true;
                        workflow.DateCreated = DateTime.Now;
                        workflow.CreatedBy = User.Identity.Name.ToString();
                        workflow.Id = this.workflowService.Create(workflow);
                        model.Id = workflow.Id;
                        return Json(new { result = Base.Encrypt(workflow.Id.ToString()), message = MessageCode.saved, code = StatusCode.saved, content = model.Name });
                    }
                    return Json(new { result = StatusCode.existed, message = MessageCode.existed, code = StatusCode.existed });
                }
                return Json(new { result = StatusCode.failed, message = MessageCode.error, code = StatusCode.invalid });
            }
            catch (Exception ex)
            {
                return Json(new { result = StatusCode.failed, message = ex.Message.ToString(), code = StatusCode.failed, content = model.Name.ToString() });
            }
        }
        #endregion
        #region Manage
        [CryptoValueProvider]
        public ActionResult Manage(int id)
        {
            try
            {
                Workflow model = this.workflowService.GetDataById(id);
                if (model != null)
                    return View(model);
            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult Manage(Workflow model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool ifExists = this.workflowService.CheckDataIfExists(model);
                    if (!ifExists)
                    {

                        Workflow workflow = new Workflow();
                        workflow = this.workflowService.GetDataById(model.Id);
                        workflow.Code= model.Code.ToUpper();
                        workflow.Name = model.Name;
                        workflow.Description = model.Description;
                        workflow.Active = model.Active;
                        workflow.DateModified = DateTime.Now;
                        workflow.ModifiedBy = User.Identity.Name.ToString();
                        this.workflowService.SaveChanges(workflow);
                        return Json(new { result = Base.Encrypt(workflow.Id.ToString()), message = MessageCode.modified, code = StatusCode.modified, content = workflow.Name });
                    }
                    return Json(new { result = StatusCode.existed, message = MessageCode.existed, code = StatusCode.existed });
                }
                return Json(new { result = StatusCode.failed, message = MessageCode.error, code = StatusCode.invalid });
            }
            catch (Exception ex)
            {
                return Json(new { result = StatusCode.failed, message = ex.Message.ToString(), code = StatusCode.failed, content = model.Name });
            }


        }
        #endregion
        #region Item
        public ActionResult Item(string id, string status)
        {
            try
            {
                int workfowId = Convert.ToInt32(Base.Decrypt(id));
                Workflow workflow = this.workflowService.GetDataById(workfowId);
                if (workflow != null)
                {
                    ViewBag.StatusCode = status;
                    ViewBag.SecuredId = id;
                    ViewBag.Message = MessageCode.GetMessage(status);
                    return View(workflow);
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return RedirectToAction("Index");
        }
        #endregion
        #region Delete
        public JsonResult Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    this.workflowService.Delete(id);
                    return Json(new { result = StatusCode.done, message = MessageCode.deleted, code = StatusCode.deleted });
                }
            }
            catch (Exception)
            {
            }
            return Json(new { result = StatusCode.failed, message = MessageCode.error });
        }
        #endregion
        #region Common
        public ActionResult CheckAvailability(string param)
        {
            if (!string.IsNullOrEmpty(param))
            {
                bool ifExists = this.workflowService.CheckDataIfExists(param);
                if (!ifExists)
                {
                    return Json(new { result = StatusCode.valid, MessageCode.valid, code = StatusCode.valid });
                }
                else
                {
                    return Json(new { result = StatusCode.existed, message = MessageCode.existed, code = StatusCode.existed });
                }
            }
            return Json(new { result = StatusCode.empty, message = MessageCode.empty, code = StatusCode.empty });
        }
        #endregion
       

    }
}
