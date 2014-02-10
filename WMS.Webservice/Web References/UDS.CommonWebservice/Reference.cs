﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.18408.
// 
#pragma warning disable 1591

namespace WMS.Webservice.UDS.CommonWebservice {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="CommonWSSoap", Namespace="http://tempuri.org/")]
    public partial class CommonWS : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetAllActiveSystemOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public CommonWS() {
            this.Url = global::WMS.Webservice.Properties.Settings.Default.WMS_Webservice_UDS_CommonWebservice_CommonWS;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetAllActiveSystemCompletedEventHandler GetAllActiveSystemCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetAllActiveSystem", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Systems[] GetAllActiveSystem() {
            object[] results = this.Invoke("GetAllActiveSystem", new object[0]);
            return ((Systems[])(results[0]));
        }
        
        /// <remarks/>
        public void GetAllActiveSystemAsync() {
            this.GetAllActiveSystemAsync(null);
        }
        
        /// <remarks/>
        public void GetAllActiveSystemAsync(object userState) {
            if ((this.GetAllActiveSystemOperationCompleted == null)) {
                this.GetAllActiveSystemOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllActiveSystemOperationCompleted);
            }
            this.InvokeAsync("GetAllActiveSystem", new object[0], this.GetAllActiveSystemOperationCompleted, userState);
        }
        
        private void OnGetAllActiveSystemOperationCompleted(object arg) {
            if ((this.GetAllActiveSystemCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllActiveSystemCompleted(this, new GetAllActiveSystemCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18408")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Systems {
        
        private int systemIDField;
        
        private string systemCodeField;
        
        private string systemNameField;
        
        private string systemDescriptionField;
        
        private bool activeField;
        
        private string pathField;
        
        private string dateCreatedField;
        
        private string createdByField;
        
        private string dateModifiedField;
        
        private string modifiedByField;
        
        private int rowsField;
        
        /// <remarks/>
        public int SystemID {
            get {
                return this.systemIDField;
            }
            set {
                this.systemIDField = value;
            }
        }
        
        /// <remarks/>
        public string SystemCode {
            get {
                return this.systemCodeField;
            }
            set {
                this.systemCodeField = value;
            }
        }
        
        /// <remarks/>
        public string SystemName {
            get {
                return this.systemNameField;
            }
            set {
                this.systemNameField = value;
            }
        }
        
        /// <remarks/>
        public string SystemDescription {
            get {
                return this.systemDescriptionField;
            }
            set {
                this.systemDescriptionField = value;
            }
        }
        
        /// <remarks/>
        public bool Active {
            get {
                return this.activeField;
            }
            set {
                this.activeField = value;
            }
        }
        
        /// <remarks/>
        public string Path {
            get {
                return this.pathField;
            }
            set {
                this.pathField = value;
            }
        }
        
        /// <remarks/>
        public string DateCreated {
            get {
                return this.dateCreatedField;
            }
            set {
                this.dateCreatedField = value;
            }
        }
        
        /// <remarks/>
        public string CreatedBy {
            get {
                return this.createdByField;
            }
            set {
                this.createdByField = value;
            }
        }
        
        /// <remarks/>
        public string DateModified {
            get {
                return this.dateModifiedField;
            }
            set {
                this.dateModifiedField = value;
            }
        }
        
        /// <remarks/>
        public string ModifiedBy {
            get {
                return this.modifiedByField;
            }
            set {
                this.modifiedByField = value;
            }
        }
        
        /// <remarks/>
        public int Rows {
            get {
                return this.rowsField;
            }
            set {
                this.rowsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    public delegate void GetAllActiveSystemCompletedEventHandler(object sender, GetAllActiveSystemCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.18408")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllActiveSystemCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllActiveSystemCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Systems[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Systems[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591