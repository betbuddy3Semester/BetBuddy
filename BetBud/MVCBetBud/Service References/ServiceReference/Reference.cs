﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCBetBud.ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Kamp", Namespace="http://schemas.datacontract.org/2004/07/ModelLibrary.Kupon")]
    [System.SerializableAttribute()]
    public partial class Kamp : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool AflystField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string HoldVsHoldField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int KampIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime KampStartField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double Odds1Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double Odds2Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double OddsXField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool Vundet1Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool Vundet2Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool VundetXField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Aflyst {
            get {
                return this.AflystField;
            }
            set {
                if ((this.AflystField.Equals(value) != true)) {
                    this.AflystField = value;
                    this.RaisePropertyChanged("Aflyst");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string HoldVsHold {
            get {
                return this.HoldVsHoldField;
            }
            set {
                if ((object.ReferenceEquals(this.HoldVsHoldField, value) != true)) {
                    this.HoldVsHoldField = value;
                    this.RaisePropertyChanged("HoldVsHold");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int KampId {
            get {
                return this.KampIdField;
            }
            set {
                if ((this.KampIdField.Equals(value) != true)) {
                    this.KampIdField = value;
                    this.RaisePropertyChanged("KampId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime KampStart {
            get {
                return this.KampStartField;
            }
            set {
                if ((this.KampStartField.Equals(value) != true)) {
                    this.KampStartField = value;
                    this.RaisePropertyChanged("KampStart");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Odds1 {
            get {
                return this.Odds1Field;
            }
            set {
                if ((this.Odds1Field.Equals(value) != true)) {
                    this.Odds1Field = value;
                    this.RaisePropertyChanged("Odds1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Odds2 {
            get {
                return this.Odds2Field;
            }
            set {
                if ((this.Odds2Field.Equals(value) != true)) {
                    this.Odds2Field = value;
                    this.RaisePropertyChanged("Odds2");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double OddsX {
            get {
                return this.OddsXField;
            }
            set {
                if ((this.OddsXField.Equals(value) != true)) {
                    this.OddsXField = value;
                    this.RaisePropertyChanged("OddsX");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Vundet1 {
            get {
                return this.Vundet1Field;
            }
            set {
                if ((this.Vundet1Field.Equals(value) != true)) {
                    this.Vundet1Field = value;
                    this.RaisePropertyChanged("Vundet1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Vundet2 {
            get {
                return this.Vundet2Field;
            }
            set {
                if ((this.Vundet2Field.Equals(value) != true)) {
                    this.Vundet2Field = value;
                    this.RaisePropertyChanged("Vundet2");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool VundetX {
            get {
                return this.VundetXField;
            }
            set {
                if ((this.VundetXField.Equals(value) != true)) {
                    this.VundetXField = value;
                    this.RaisePropertyChanged("VundetX");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Bruger", Namespace="http://schemas.datacontract.org/2004/07/ModelLibrary.Bruger")]
    [System.SerializableAttribute()]
    public partial class Bruger : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AliasField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int BrugerIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BrugerNavnField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NavnField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Alias {
            get {
                return this.AliasField;
            }
            set {
                if ((object.ReferenceEquals(this.AliasField, value) != true)) {
                    this.AliasField = value;
                    this.RaisePropertyChanged("Alias");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int BrugerId {
            get {
                return this.BrugerIdField;
            }
            set {
                if ((this.BrugerIdField.Equals(value) != true)) {
                    this.BrugerIdField = value;
                    this.RaisePropertyChanged("BrugerId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BrugerNavn {
            get {
                return this.BrugerNavnField;
            }
            set {
                if ((object.ReferenceEquals(this.BrugerNavnField, value) != true)) {
                    this.BrugerNavnField = value;
                    this.RaisePropertyChanged("BrugerNavn");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Navn {
            get {
                return this.NavnField;
            }
            set {
                if ((object.ReferenceEquals(this.NavnField, value) != true)) {
                    this.NavnField = value;
                    this.RaisePropertyChanged("Navn");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IServices")]
    public interface IServices {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/TilføjKamp", ReplyAction="http://tempuri.org/IServices/TilføjKampResponse")]
        bool TilføjKamp(MVCBetBud.ServiceReference.Kamp kamp, bool valgt1, bool valgtX, bool valgt2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/TilføjKamp", ReplyAction="http://tempuri.org/IServices/TilføjKampResponse")]
        System.Threading.Tasks.Task<bool> TilføjKampAsync(MVCBetBud.ServiceReference.Kamp kamp, bool valgt1, bool valgtX, bool valgt2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/FjernKamp", ReplyAction="http://tempuri.org/IServices/FjernKampResponse")]
        bool FjernKamp(MVCBetBud.ServiceReference.Kamp kamp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/FjernKamp", ReplyAction="http://tempuri.org/IServices/FjernKampResponse")]
        System.Threading.Tasks.Task<bool> FjernKampAsync(MVCBetBud.ServiceReference.Kamp kamp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/OddsUdregning", ReplyAction="http://tempuri.org/IServices/OddsUdregningResponse")]
        double OddsUdregning();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/OddsUdregning", ReplyAction="http://tempuri.org/IServices/OddsUdregningResponse")]
        System.Threading.Tasks.Task<double> OddsUdregningAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/MuligGevist", ReplyAction="http://tempuri.org/IServices/MuligGevistResponse")]
        double MuligGevist();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/MuligGevist", ReplyAction="http://tempuri.org/IServices/MuligGevistResponse")]
        System.Threading.Tasks.Task<double> MuligGevistAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/BekræftKupon", ReplyAction="http://tempuri.org/IServices/BekræftKuponResponse")]
        bool BekræftKupon();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/BekræftKupon", ReplyAction="http://tempuri.org/IServices/BekræftKuponResponse")]
        System.Threading.Tasks.Task<bool> BekræftKuponAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/FindKamp", ReplyAction="http://tempuri.org/IServices/FindKampResponse")]
        MVCBetBud.ServiceReference.Kamp FindKamp(int KampId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/FindKamp", ReplyAction="http://tempuri.org/IServices/FindKampResponse")]
        System.Threading.Tasks.Task<MVCBetBud.ServiceReference.Kamp> FindKampAsync(int KampId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/GetAlleKampe", ReplyAction="http://tempuri.org/IServices/GetAlleKampeResponse")]
        MVCBetBud.ServiceReference.Kamp[] GetAlleKampe();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/GetAlleKampe", ReplyAction="http://tempuri.org/IServices/GetAlleKampeResponse")]
        System.Threading.Tasks.Task<MVCBetBud.ServiceReference.Kamp[]> GetAlleKampeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/getBruger", ReplyAction="http://tempuri.org/IServices/getBrugerResponse")]
        MVCBetBud.ServiceReference.Bruger getBruger(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/getBruger", ReplyAction="http://tempuri.org/IServices/getBrugerResponse")]
        System.Threading.Tasks.Task<MVCBetBud.ServiceReference.Bruger> getBrugerAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/getBrugerEfterBrugernavn", ReplyAction="http://tempuri.org/IServices/getBrugerEfterBrugernavnResponse")]
        MVCBetBud.ServiceReference.Bruger getBrugerEfterBrugernavn(string bnavn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/getBrugerEfterBrugernavn", ReplyAction="http://tempuri.org/IServices/getBrugerEfterBrugernavnResponse")]
        System.Threading.Tasks.Task<MVCBetBud.ServiceReference.Bruger> getBrugerEfterBrugernavnAsync(string bnavn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/getBrugere", ReplyAction="http://tempuri.org/IServices/getBrugereResponse")]
        MVCBetBud.ServiceReference.Bruger[] getBrugere();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/getBrugere", ReplyAction="http://tempuri.org/IServices/getBrugereResponse")]
        System.Threading.Tasks.Task<MVCBetBud.ServiceReference.Bruger[]> getBrugereAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/opretBruger", ReplyAction="http://tempuri.org/IServices/opretBrugerResponse")]
        void opretBruger(MVCBetBud.ServiceReference.Bruger bruger);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/opretBruger", ReplyAction="http://tempuri.org/IServices/opretBrugerResponse")]
        System.Threading.Tasks.Task opretBrugerAsync(MVCBetBud.ServiceReference.Bruger bruger);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/opdaterBruger", ReplyAction="http://tempuri.org/IServices/opdaterBrugerResponse")]
        void opdaterBruger(MVCBetBud.ServiceReference.Bruger bruger);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/opdaterBruger", ReplyAction="http://tempuri.org/IServices/opdaterBrugerResponse")]
        System.Threading.Tasks.Task opdaterBrugerAsync(MVCBetBud.ServiceReference.Bruger bruger);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/sletBruger", ReplyAction="http://tempuri.org/IServices/sletBrugerResponse")]
        void sletBruger(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServices/sletBruger", ReplyAction="http://tempuri.org/IServices/sletBrugerResponse")]
        System.Threading.Tasks.Task sletBrugerAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicesChannel : MVCBetBud.ServiceReference.IServices, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicesClient : System.ServiceModel.ClientBase<MVCBetBud.ServiceReference.IServices>, MVCBetBud.ServiceReference.IServices {
        
        public ServicesClient() {
        }
        
        public ServicesClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicesClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicesClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicesClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool TilføjKamp(MVCBetBud.ServiceReference.Kamp kamp, bool valgt1, bool valgtX, bool valgt2) {
            return base.Channel.TilføjKamp(kamp, valgt1, valgtX, valgt2);
        }
        
        public System.Threading.Tasks.Task<bool> TilføjKampAsync(MVCBetBud.ServiceReference.Kamp kamp, bool valgt1, bool valgtX, bool valgt2) {
            return base.Channel.TilføjKampAsync(kamp, valgt1, valgtX, valgt2);
        }
        
        public bool FjernKamp(MVCBetBud.ServiceReference.Kamp kamp) {
            return base.Channel.FjernKamp(kamp);
        }
        
        public System.Threading.Tasks.Task<bool> FjernKampAsync(MVCBetBud.ServiceReference.Kamp kamp) {
            return base.Channel.FjernKampAsync(kamp);
        }
        
        public double OddsUdregning() {
            return base.Channel.OddsUdregning();
        }
        
        public System.Threading.Tasks.Task<double> OddsUdregningAsync() {
            return base.Channel.OddsUdregningAsync();
        }
        
        public double MuligGevist() {
            return base.Channel.MuligGevist();
        }
        
        public System.Threading.Tasks.Task<double> MuligGevistAsync() {
            return base.Channel.MuligGevistAsync();
        }
        
        public bool BekræftKupon() {
            return base.Channel.BekræftKupon();
        }
        
        public System.Threading.Tasks.Task<bool> BekræftKuponAsync() {
            return base.Channel.BekræftKuponAsync();
        }
        
        public MVCBetBud.ServiceReference.Kamp FindKamp(int KampId) {
            return base.Channel.FindKamp(KampId);
        }
        
        public System.Threading.Tasks.Task<MVCBetBud.ServiceReference.Kamp> FindKampAsync(int KampId) {
            return base.Channel.FindKampAsync(KampId);
        }
        
        public MVCBetBud.ServiceReference.Kamp[] GetAlleKampe() {
            return base.Channel.GetAlleKampe();
        }
        
        public System.Threading.Tasks.Task<MVCBetBud.ServiceReference.Kamp[]> GetAlleKampeAsync() {
            return base.Channel.GetAlleKampeAsync();
        }
        
        public MVCBetBud.ServiceReference.Bruger getBruger(int id) {
            return base.Channel.getBruger(id);
        }
        
        public System.Threading.Tasks.Task<MVCBetBud.ServiceReference.Bruger> getBrugerAsync(int id) {
            return base.Channel.getBrugerAsync(id);
        }
        
        public MVCBetBud.ServiceReference.Bruger getBrugerEfterBrugernavn(string bnavn) {
            return base.Channel.getBrugerEfterBrugernavn(bnavn);
        }
        
        public System.Threading.Tasks.Task<MVCBetBud.ServiceReference.Bruger> getBrugerEfterBrugernavnAsync(string bnavn) {
            return base.Channel.getBrugerEfterBrugernavnAsync(bnavn);
        }
        
        public MVCBetBud.ServiceReference.Bruger[] getBrugere() {
            return base.Channel.getBrugere();
        }
        
        public System.Threading.Tasks.Task<MVCBetBud.ServiceReference.Bruger[]> getBrugereAsync() {
            return base.Channel.getBrugereAsync();
        }
        
        public void opretBruger(MVCBetBud.ServiceReference.Bruger bruger) {
            base.Channel.opretBruger(bruger);
        }
        
        public System.Threading.Tasks.Task opretBrugerAsync(MVCBetBud.ServiceReference.Bruger bruger) {
            return base.Channel.opretBrugerAsync(bruger);
        }
        
        public void opdaterBruger(MVCBetBud.ServiceReference.Bruger bruger) {
            base.Channel.opdaterBruger(bruger);
        }
        
        public System.Threading.Tasks.Task opdaterBrugerAsync(MVCBetBud.ServiceReference.Bruger bruger) {
            return base.Channel.opdaterBrugerAsync(bruger);
        }
        
        public void sletBruger(int id) {
            base.Channel.sletBruger(id);
        }
        
        public System.Threading.Tasks.Task sletBrugerAsync(int id) {
            return base.Channel.sletBrugerAsync(id);
        }
    }
}
