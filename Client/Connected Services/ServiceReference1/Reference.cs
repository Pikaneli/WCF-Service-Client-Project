﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1", CallbackContract=typeof(Client.ServiceReference1.IService1Callback))]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/StartSensors", ReplyAction="http://tempuri.org/IService1/StartSensorsResponse")]
        void StartSensors();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/StartSensors", ReplyAction="http://tempuri.org/IService1/StartSensorsResponse")]
        System.Threading.Tasks.Task StartSensorsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/StopSensors", ReplyAction="http://tempuri.org/IService1/StopSensorsResponse")]
        void StopSensors();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/StopSensors", ReplyAction="http://tempuri.org/IService1/StopSensorsResponse")]
        System.Threading.Tasks.Task StopSensorsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AlignReplicas", ReplyAction="http://tempuri.org/IService1/AlignReplicasResponse")]
        void AlignReplicas();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AlignReplicas", ReplyAction="http://tempuri.org/IService1/AlignReplicasResponse")]
        System.Threading.Tasks.Task AlignReplicasAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Subscribe", ReplyAction="http://tempuri.org/IService1/SubscribeResponse")]
        void Subscribe();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Subscribe", ReplyAction="http://tempuri.org/IService1/SubscribeResponse")]
        System.Threading.Tasks.Task SubscribeAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Callback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/NotifyTemperature", ReplyAction="http://tempuri.org/IService1/NotifyTemperatureResponse")]
        void NotifyTemperature(int sensorId, double temperature);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/AlignReplicasCallback", ReplyAction="http://tempuri.org/IService1/AlignReplicasCallbackResponse")]
        void AlignReplicasCallback(object state);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : Client.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.DuplexClientBase<Client.ServiceReference1.IService1>, Client.ServiceReference1.IService1 {
        
        public Service1Client(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public Service1Client(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public Service1Client(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void StartSensors() {
            base.Channel.StartSensors();
        }
        
        public System.Threading.Tasks.Task StartSensorsAsync() {
            return base.Channel.StartSensorsAsync();
        }
        
        public void StopSensors() {
            base.Channel.StopSensors();
        }
        
        public System.Threading.Tasks.Task StopSensorsAsync() {
            return base.Channel.StopSensorsAsync();
        }
        
        public void AlignReplicas() {
            base.Channel.AlignReplicas();
        }
        
        public System.Threading.Tasks.Task AlignReplicasAsync() {
            return base.Channel.AlignReplicasAsync();
        }
        
        public void Subscribe() {
            base.Channel.Subscribe();
        }
        
        public System.Threading.Tasks.Task SubscribeAsync() {
            return base.Channel.SubscribeAsync();
        }
    }
}
