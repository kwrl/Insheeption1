﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18010
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GUIClient.ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Authentication", Namespace="http://schemas.datacontract.org/2004/07/Insheeption")]
    [System.SerializableAttribute()]
    public partial class Authentication : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int FarmerIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
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
        public int FarmerID {
            get {
                return this.FarmerIDField;
            }
            set {
                if ((this.FarmerIDField.Equals(value) != true)) {
                    this.FarmerIDField = value;
                    this.RaisePropertyChanged("FarmerID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Flock", Namespace="http://schemas.datacontract.org/2004/07/Insheeption")]
    [System.SerializableAttribute()]
    public partial class Flock : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int flockIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private GUIClient.ServiceReference.Sheep[] sheepField;
        
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
        public int flockID {
            get {
                return this.flockIDField;
            }
            set {
                if ((this.flockIDField.Equals(value) != true)) {
                    this.flockIDField = value;
                    this.RaisePropertyChanged("flockID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public GUIClient.ServiceReference.Sheep[] sheep {
            get {
                return this.sheepField;
            }
            set {
                if ((object.ReferenceEquals(this.sheepField, value) != true)) {
                    this.sheepField = value;
                    this.RaisePropertyChanged("sheep");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Sheep", Namespace="http://schemas.datacontract.org/2004/07/Insheeption")]
    [System.SerializableAttribute()]
    public partial class Sheep : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private GUIClient.ServiceReference.HealthStatus[] healthLogField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private GUIClient.ServiceReference.Position[] positionLogField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int sheepIDField;
        
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
        public GUIClient.ServiceReference.HealthStatus[] healthLog {
            get {
                return this.healthLogField;
            }
            set {
                if ((object.ReferenceEquals(this.healthLogField, value) != true)) {
                    this.healthLogField = value;
                    this.RaisePropertyChanged("healthLog");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public GUIClient.ServiceReference.Position[] positionLog {
            get {
                return this.positionLogField;
            }
            set {
                if ((object.ReferenceEquals(this.positionLogField, value) != true)) {
                    this.positionLogField = value;
                    this.RaisePropertyChanged("positionLog");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int sheepID {
            get {
                return this.sheepIDField;
            }
            set {
                if ((this.sheepIDField.Equals(value) != true)) {
                    this.sheepIDField = value;
                    this.RaisePropertyChanged("sheepID");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="HealthStatus", Namespace="http://schemas.datacontract.org/2004/07/Insheeption")]
    [System.SerializableAttribute()]
    public partial class HealthStatus : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool AlarmField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PulseField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeField;
        
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
        public bool Alarm {
            get {
                return this.AlarmField;
            }
            set {
                if ((this.AlarmField.Equals(value) != true)) {
                    this.AlarmField = value;
                    this.RaisePropertyChanged("Alarm");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Pulse {
            get {
                return this.PulseField;
            }
            set {
                if ((this.PulseField.Equals(value) != true)) {
                    this.PulseField = value;
                    this.RaisePropertyChanged("Pulse");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Time {
            get {
                return this.TimeField;
            }
            set {
                if ((this.TimeField.Equals(value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Position", Namespace="http://schemas.datacontract.org/2004/07/Insheeption")]
    [System.SerializableAttribute()]
    public partial class Position : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LatitudeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LongitudeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimeField;
        
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
        public string Latitude {
            get {
                return this.LatitudeField;
            }
            set {
                if ((object.ReferenceEquals(this.LatitudeField, value) != true)) {
                    this.LatitudeField = value;
                    this.RaisePropertyChanged("Latitude");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Longitude {
            get {
                return this.LongitudeField;
            }
            set {
                if ((object.ReferenceEquals(this.LongitudeField, value) != true)) {
                    this.LongitudeField = value;
                    this.RaisePropertyChanged("Longitude");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Time {
            get {
                return this.TimeField;
            }
            set {
                if ((this.TimeField.Equals(value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.ISheepService")]
    public interface ISheepService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISheepService/LoadFlockByFlockID", ReplyAction="http://tempuri.org/ISheepService/LoadFlockByFlockIDResponse")]
        GUIClient.ServiceReference.Flock LoadFlockByFlockID(int flockID, System.DateTime startTime, System.DateTime stopTime, GUIClient.ServiceReference.Authentication login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISheepService/LoadFlockBySheepID", ReplyAction="http://tempuri.org/ISheepService/LoadFlockBySheepIDResponse")]
        GUIClient.ServiceReference.Flock LoadFlockBySheepID(int sheepID, System.DateTime startTime, System.DateTime stopTime, GUIClient.ServiceReference.Authentication login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISheepService/LoadAllFlockIDs", ReplyAction="http://tempuri.org/ISheepService/LoadAllFlockIDsResponse")]
        int[] LoadAllFlockIDs(GUIClient.ServiceReference.Authentication authentication);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISheepService/GetHealthLog", ReplyAction="http://tempuri.org/ISheepService/GetHealthLogResponse")]
        GUIClient.ServiceReference.HealthStatus[] GetHealthLog(int sheepID, System.DateTime startTime, System.DateTime stopTime, GUIClient.ServiceReference.Authentication login);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISheepService/CreateNewUser", ReplyAction="http://tempuri.org/ISheepService/CreateNewUserResponse")]
        bool CreateNewUser(GUIClient.ServiceReference.Authentication newUser, GUIClient.ServiceReference.Authentication adminAuthentication);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISheepService/NormalLogin", ReplyAction="http://tempuri.org/ISheepService/NormalLoginResponse")]
        bool NormalLogin(string brukernavn, string passord);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISheepServiceChannel : GUIClient.ServiceReference.ISheepService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SheepServiceClient : System.ServiceModel.ClientBase<GUIClient.ServiceReference.ISheepService>, GUIClient.ServiceReference.ISheepService {
        
        public SheepServiceClient() {
        }
        
        public SheepServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SheepServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SheepServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SheepServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public GUIClient.ServiceReference.Flock LoadFlockByFlockID(int flockID, System.DateTime startTime, System.DateTime stopTime, GUIClient.ServiceReference.Authentication login) {
            return base.Channel.LoadFlockByFlockID(flockID, startTime, stopTime, login);
        }
        
        public GUIClient.ServiceReference.Flock LoadFlockBySheepID(int sheepID, System.DateTime startTime, System.DateTime stopTime, GUIClient.ServiceReference.Authentication login) {
            return base.Channel.LoadFlockBySheepID(sheepID, startTime, stopTime, login);
        }
        
        public int[] LoadAllFlockIDs(GUIClient.ServiceReference.Authentication authentication) {
            return base.Channel.LoadAllFlockIDs(authentication);
        }
        
        public GUIClient.ServiceReference.HealthStatus[] GetHealthLog(int sheepID, System.DateTime startTime, System.DateTime stopTime, GUIClient.ServiceReference.Authentication login) {
            return base.Channel.GetHealthLog(sheepID, startTime, stopTime, login);
        }
        
        public bool CreateNewUser(GUIClient.ServiceReference.Authentication newUser, GUIClient.ServiceReference.Authentication adminAuthentication) {
            return base.Channel.CreateNewUser(newUser, adminAuthentication);
        }
        
        public bool NormalLogin(string brukernavn, string passord) {
            return base.Channel.NormalLogin(brukernavn, passord);
        }
    }
}
