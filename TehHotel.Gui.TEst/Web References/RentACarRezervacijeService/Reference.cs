﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.17929.
// 
#pragma warning disable 1591

namespace TehHotel.Gui.Test.RentACarRezervacijeService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="BasicHttpBinding_IRezervacije", Namespace="http://tempuri.org/")]
    public partial class Rezervacije : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback dodajRezervacijoOperationCompleted;
        
        private System.Threading.SendOrPostCallback spremeniRezervacijoOperationCompleted;
        
        private System.Threading.SendOrPostCallback prekliciRezervacijoOperationCompleted;
        
        private System.Threading.SendOrPostCallback pregledVsehRezervacijOperationCompleted;
        
        private System.Threading.SendOrPostCallback izdajRacunOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Rezervacije() {
            this.Url = global::TehHotel.Gui.Test.Properties.Settings.Default.TehHotel_Gui_Test_RentACarRezervacijeService_Rezervacije;
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
        public event dodajRezervacijoCompletedEventHandler dodajRezervacijoCompleted;
        
        /// <remarks/>
        public event spremeniRezervacijoCompletedEventHandler spremeniRezervacijoCompleted;
        
        /// <remarks/>
        public event prekliciRezervacijoCompletedEventHandler prekliciRezervacijoCompleted;
        
        /// <remarks/>
        public event pregledVsehRezervacijCompletedEventHandler pregledVsehRezervacijCompleted;
        
        /// <remarks/>
        public event izdajRacunCompletedEventHandler izdajRacunCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IRezervacije/dodajRezervacijo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string dodajRezervacijo([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] Rezervacija rezervacija) {
            object[] results = this.Invoke("dodajRezervacijo", new object[] {
                        rezervacija});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void dodajRezervacijoAsync(Rezervacija rezervacija) {
            this.dodajRezervacijoAsync(rezervacija, null);
        }
        
        /// <remarks/>
        public void dodajRezervacijoAsync(Rezervacija rezervacija, object userState) {
            if ((this.dodajRezervacijoOperationCompleted == null)) {
                this.dodajRezervacijoOperationCompleted = new System.Threading.SendOrPostCallback(this.OndodajRezervacijoOperationCompleted);
            }
            this.InvokeAsync("dodajRezervacijo", new object[] {
                        rezervacija}, this.dodajRezervacijoOperationCompleted, userState);
        }
        
        private void OndodajRezervacijoOperationCompleted(object arg) {
            if ((this.dodajRezervacijoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.dodajRezervacijoCompleted(this, new dodajRezervacijoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IRezervacije/spremeniRezervacijo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string spremeniRezervacijo(int idRezervacije, [System.Xml.Serialization.XmlIgnoreAttribute()] bool idRezervacijeSpecified, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] Rezervacija rezervacija) {
            object[] results = this.Invoke("spremeniRezervacijo", new object[] {
                        idRezervacije,
                        idRezervacijeSpecified,
                        rezervacija});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void spremeniRezervacijoAsync(int idRezervacije, bool idRezervacijeSpecified, Rezervacija rezervacija) {
            this.spremeniRezervacijoAsync(idRezervacije, idRezervacijeSpecified, rezervacija, null);
        }
        
        /// <remarks/>
        public void spremeniRezervacijoAsync(int idRezervacije, bool idRezervacijeSpecified, Rezervacija rezervacija, object userState) {
            if ((this.spremeniRezervacijoOperationCompleted == null)) {
                this.spremeniRezervacijoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnspremeniRezervacijoOperationCompleted);
            }
            this.InvokeAsync("spremeniRezervacijo", new object[] {
                        idRezervacije,
                        idRezervacijeSpecified,
                        rezervacija}, this.spremeniRezervacijoOperationCompleted, userState);
        }
        
        private void OnspremeniRezervacijoOperationCompleted(object arg) {
            if ((this.spremeniRezervacijoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.spremeniRezervacijoCompleted(this, new spremeniRezervacijoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IRezervacije/prekliciRezervacijo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string prekliciRezervacijo(int idRezervacije, [System.Xml.Serialization.XmlIgnoreAttribute()] bool idRezervacijeSpecified) {
            object[] results = this.Invoke("prekliciRezervacijo", new object[] {
                        idRezervacije,
                        idRezervacijeSpecified});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void prekliciRezervacijoAsync(int idRezervacije, bool idRezervacijeSpecified) {
            this.prekliciRezervacijoAsync(idRezervacije, idRezervacijeSpecified, null);
        }
        
        /// <remarks/>
        public void prekliciRezervacijoAsync(int idRezervacije, bool idRezervacijeSpecified, object userState) {
            if ((this.prekliciRezervacijoOperationCompleted == null)) {
                this.prekliciRezervacijoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnprekliciRezervacijoOperationCompleted);
            }
            this.InvokeAsync("prekliciRezervacijo", new object[] {
                        idRezervacije,
                        idRezervacijeSpecified}, this.prekliciRezervacijoOperationCompleted, userState);
        }
        
        private void OnprekliciRezervacijoOperationCompleted(object arg) {
            if ((this.prekliciRezervacijoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.prekliciRezervacijoCompleted(this, new prekliciRezervacijoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IRezervacije/pregledVsehRezervacij", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlArrayAttribute(IsNullable=true)]
        [return: System.Xml.Serialization.XmlArrayItemAttribute(Namespace="http://schemas.datacontract.org/2004/07/RentACar2_Rezervacije")]
        public Rezervacija[] pregledVsehRezervacij() {
            object[] results = this.Invoke("pregledVsehRezervacij", new object[0]);
            return ((Rezervacija[])(results[0]));
        }
        
        /// <remarks/>
        public void pregledVsehRezervacijAsync() {
            this.pregledVsehRezervacijAsync(null);
        }
        
        /// <remarks/>
        public void pregledVsehRezervacijAsync(object userState) {
            if ((this.pregledVsehRezervacijOperationCompleted == null)) {
                this.pregledVsehRezervacijOperationCompleted = new System.Threading.SendOrPostCallback(this.OnpregledVsehRezervacijOperationCompleted);
            }
            this.InvokeAsync("pregledVsehRezervacij", new object[0], this.pregledVsehRezervacijOperationCompleted, userState);
        }
        
        private void OnpregledVsehRezervacijOperationCompleted(object arg) {
            if ((this.pregledVsehRezervacijCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.pregledVsehRezervacijCompleted(this, new pregledVsehRezervacijCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IRezervacije/izdajRacun", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string izdajRacun([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] Racun racun) {
            object[] results = this.Invoke("izdajRacun", new object[] {
                        racun});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void izdajRacunAsync(Racun racun) {
            this.izdajRacunAsync(racun, null);
        }
        
        /// <remarks/>
        public void izdajRacunAsync(Racun racun, object userState) {
            if ((this.izdajRacunOperationCompleted == null)) {
                this.izdajRacunOperationCompleted = new System.Threading.SendOrPostCallback(this.OnizdajRacunOperationCompleted);
            }
            this.InvokeAsync("izdajRacun", new object[] {
                        racun}, this.izdajRacunOperationCompleted, userState);
        }
        
        private void OnizdajRacunOperationCompleted(object arg) {
            if ((this.izdajRacunCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.izdajRacunCompleted(this, new izdajRacunCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/RentACar2_Rezervacije")]
    public partial class Rezervacija {
        
        private System.DateTime datumPrevzemaField;
        
        private bool datumPrevzemaFieldSpecified;
        
        private System.DateTime datumVracilaField;
        
        private bool datumVracilaFieldSpecified;
        
        private int idRezervacijaField;
        
        private bool idRezervacijaFieldSpecified;
        
        private int idStrankaField;
        
        private bool idStrankaFieldSpecified;
        
        private int idVoziloField;
        
        private bool idVoziloFieldSpecified;
        
        private int prevzemIdPoslovalnicaField;
        
        private bool prevzemIdPoslovalnicaFieldSpecified;
        
        private int vraciloIdPoslovalnicaField;
        
        private bool vraciloIdPoslovalnicaFieldSpecified;
        
        /// <remarks/>
        public System.DateTime DatumPrevzema {
            get {
                return this.datumPrevzemaField;
            }
            set {
                this.datumPrevzemaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DatumPrevzemaSpecified {
            get {
                return this.datumPrevzemaFieldSpecified;
            }
            set {
                this.datumPrevzemaFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime DatumVracila {
            get {
                return this.datumVracilaField;
            }
            set {
                this.datumVracilaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DatumVracilaSpecified {
            get {
                return this.datumVracilaFieldSpecified;
            }
            set {
                this.datumVracilaFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int IdRezervacija {
            get {
                return this.idRezervacijaField;
            }
            set {
                this.idRezervacijaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdRezervacijaSpecified {
            get {
                return this.idRezervacijaFieldSpecified;
            }
            set {
                this.idRezervacijaFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int IdStranka {
            get {
                return this.idStrankaField;
            }
            set {
                this.idStrankaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdStrankaSpecified {
            get {
                return this.idStrankaFieldSpecified;
            }
            set {
                this.idStrankaFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int IdVozilo {
            get {
                return this.idVoziloField;
            }
            set {
                this.idVoziloField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdVoziloSpecified {
            get {
                return this.idVoziloFieldSpecified;
            }
            set {
                this.idVoziloFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int PrevzemIdPoslovalnica {
            get {
                return this.prevzemIdPoslovalnicaField;
            }
            set {
                this.prevzemIdPoslovalnicaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PrevzemIdPoslovalnicaSpecified {
            get {
                return this.prevzemIdPoslovalnicaFieldSpecified;
            }
            set {
                this.prevzemIdPoslovalnicaFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int VraciloIdPoslovalnica {
            get {
                return this.vraciloIdPoslovalnicaField;
            }
            set {
                this.vraciloIdPoslovalnicaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool VraciloIdPoslovalnicaSpecified {
            get {
                return this.vraciloIdPoslovalnicaFieldSpecified;
            }
            set {
                this.vraciloIdPoslovalnicaFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.datacontract.org/2004/07/RentACar2_Rezervacije")]
    public partial class Racun {
        
        private System.DateTime datumRacunaField;
        
        private bool datumRacunaFieldSpecified;
        
        private int idRacunaField;
        
        private bool idRacunaFieldSpecified;
        
        private int idRezervacijaField;
        
        private bool idRezervacijaFieldSpecified;
        
        private string nazivBankeField;
        
        private string stevilkaBancnegaRacunaField;
        
        private double znesekRacunaField;
        
        private bool znesekRacunaFieldSpecified;
        
        private string bICField;
        
        /// <remarks/>
        public System.DateTime DatumRacuna {
            get {
                return this.datumRacunaField;
            }
            set {
                this.datumRacunaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DatumRacunaSpecified {
            get {
                return this.datumRacunaFieldSpecified;
            }
            set {
                this.datumRacunaFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int IdRacuna {
            get {
                return this.idRacunaField;
            }
            set {
                this.idRacunaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdRacunaSpecified {
            get {
                return this.idRacunaFieldSpecified;
            }
            set {
                this.idRacunaFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int IdRezervacija {
            get {
                return this.idRezervacijaField;
            }
            set {
                this.idRezervacijaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IdRezervacijaSpecified {
            get {
                return this.idRezervacijaFieldSpecified;
            }
            set {
                this.idRezervacijaFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string NazivBanke {
            get {
                return this.nazivBankeField;
            }
            set {
                this.nazivBankeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string StevilkaBancnegaRacuna {
            get {
                return this.stevilkaBancnegaRacunaField;
            }
            set {
                this.stevilkaBancnegaRacunaField = value;
            }
        }
        
        /// <remarks/>
        public double ZnesekRacuna {
            get {
                return this.znesekRacunaField;
            }
            set {
                this.znesekRacunaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ZnesekRacunaSpecified {
            get {
                return this.znesekRacunaFieldSpecified;
            }
            set {
                this.znesekRacunaFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string bIC {
            get {
                return this.bICField;
            }
            set {
                this.bICField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void dodajRezervacijoCompletedEventHandler(object sender, dodajRezervacijoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class dodajRezervacijoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal dodajRezervacijoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void spremeniRezervacijoCompletedEventHandler(object sender, spremeniRezervacijoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class spremeniRezervacijoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal spremeniRezervacijoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void prekliciRezervacijoCompletedEventHandler(object sender, prekliciRezervacijoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class prekliciRezervacijoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal prekliciRezervacijoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void pregledVsehRezervacijCompletedEventHandler(object sender, pregledVsehRezervacijCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class pregledVsehRezervacijCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal pregledVsehRezervacijCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Rezervacija[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Rezervacija[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    public delegate void izdajRacunCompletedEventHandler(object sender, izdajRacunCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.17929")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class izdajRacunCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal izdajRacunCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591