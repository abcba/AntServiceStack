//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18052
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AntServiceStack.Common.Soap11
{
    using System;
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System.Collections;
    using System.Xml.Schema;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    
    /// <summary>
    /// Fault reporting structure
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.18054")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://schemas.xmlsoap.org/soap/envelope/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://schemas.xmlsoap.org/soap/envelope/", IsNullable=false)]
    public partial class Fault
    {
        
        private System.Xml.XmlQualifiedName faultcodeField;
        
        private string faultstringField;
        
        private string faultactorField;
        
        private detail detailField;
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public System.Xml.XmlQualifiedName faultcode
        {
            get
            {
                return this.faultcodeField;
            }
            set
            {
                this.faultcodeField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string faultstring
        {
            get
            {
                return this.faultstringField;
            }
            set
            {
                this.faultstringField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="anyURI", Order=2)]
        public string faultactor
        {
            get
            {
                return this.faultactorField;
            }
            set
            {
                this.faultactorField = value;
            }
        }
        
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public detail detail
        {
            get
            {
                if ((this.detailField == null))
                {
                    this.detailField = new detail();
                }
                return this.detailField;
            }
            set
            {
                this.detailField = value;
            }
        }
    }
}