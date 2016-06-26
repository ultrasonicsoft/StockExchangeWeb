﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StockExchangeWeb.StockExchangeService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Stock", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class Stock : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        private double PriceField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Code {
            get {
                return this.CodeField;
            }
            set {
                if ((object.ReferenceEquals(this.CodeField, value) != true)) {
                    this.CodeField = value;
                    this.RaisePropertyChanged("Code");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=3)]
        public double Price {
            get {
                return this.PriceField;
            }
            set {
                if ((this.PriceField.Equals(value) != true)) {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="StockExchangeService.StockExchangeServiceSoap")]
    public interface StockExchangeServiceSoap {
        
        // CODEGEN: Generating message contract since element name GetAllStockResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetAllStock", ReplyAction="*")]
        StockExchangeWeb.StockExchangeService.GetAllStockResponse GetAllStock(StockExchangeWeb.StockExchangeService.GetAllStockRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAllStockRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetAllStock", Namespace="http://tempuri.org/", Order=0)]
        public StockExchangeWeb.StockExchangeService.GetAllStockRequestBody Body;
        
        public GetAllStockRequest() {
        }
        
        public GetAllStockRequest(StockExchangeWeb.StockExchangeService.GetAllStockRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class GetAllStockRequestBody {
        
        public GetAllStockRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetAllStockResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetAllStockResponse", Namespace="http://tempuri.org/", Order=0)]
        public StockExchangeWeb.StockExchangeService.GetAllStockResponseBody Body;
        
        public GetAllStockResponse() {
        }
        
        public GetAllStockResponse(StockExchangeWeb.StockExchangeService.GetAllStockResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetAllStockResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public StockExchangeWeb.StockExchangeService.Stock[] GetAllStockResult;
        
        public GetAllStockResponseBody() {
        }
        
        public GetAllStockResponseBody(StockExchangeWeb.StockExchangeService.Stock[] GetAllStockResult) {
            this.GetAllStockResult = GetAllStockResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface StockExchangeServiceSoapChannel : StockExchangeWeb.StockExchangeService.StockExchangeServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class StockExchangeServiceSoapClient : System.ServiceModel.ClientBase<StockExchangeWeb.StockExchangeService.StockExchangeServiceSoap>, StockExchangeWeb.StockExchangeService.StockExchangeServiceSoap {
        
        public StockExchangeServiceSoapClient() {
        }
        
        public StockExchangeServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public StockExchangeServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StockExchangeServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public StockExchangeServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        StockExchangeWeb.StockExchangeService.GetAllStockResponse StockExchangeWeb.StockExchangeService.StockExchangeServiceSoap.GetAllStock(StockExchangeWeb.StockExchangeService.GetAllStockRequest request) {
            return base.Channel.GetAllStock(request);
        }
        
        public StockExchangeWeb.StockExchangeService.Stock[] GetAllStock() {
            StockExchangeWeb.StockExchangeService.GetAllStockRequest inValue = new StockExchangeWeb.StockExchangeService.GetAllStockRequest();
            inValue.Body = new StockExchangeWeb.StockExchangeService.GetAllStockRequestBody();
            StockExchangeWeb.StockExchangeService.GetAllStockResponse retVal = ((StockExchangeWeb.StockExchangeService.StockExchangeServiceSoap)(this)).GetAllStock(inValue);
            return retVal.Body.GetAllStockResult;
        }
    }
}