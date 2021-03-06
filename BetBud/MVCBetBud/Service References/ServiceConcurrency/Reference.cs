﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCBetBud.ServiceConcurrency {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceConcurrency.IConcurrency")]
    public interface IConcurrency {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConcurrency/FeedBackReservedNames", ReplyAction="http://tempuri.org/IConcurrency/FeedBackReservedNamesResponse")]
        string[] FeedBackReservedNames(string text, int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IConcurrency/FeedBackReservedNames", ReplyAction="http://tempuri.org/IConcurrency/FeedBackReservedNamesResponse")]
        System.Threading.Tasks.Task<string[]> FeedBackReservedNamesAsync(string text, int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IConcurrencyChannel : MVCBetBud.ServiceConcurrency.IConcurrency, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ConcurrencyClient : System.ServiceModel.ClientBase<MVCBetBud.ServiceConcurrency.IConcurrency>, MVCBetBud.ServiceConcurrency.IConcurrency {
        
        public ConcurrencyClient() {
        }
        
        public ConcurrencyClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ConcurrencyClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConcurrencyClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ConcurrencyClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] FeedBackReservedNames(string text, int id) {
            return base.Channel.FeedBackReservedNames(text, id);
        }
        
        public System.Threading.Tasks.Task<string[]> FeedBackReservedNamesAsync(string text, int id) {
            return base.Channel.FeedBackReservedNamesAsync(text, id);
        }
    }
}
