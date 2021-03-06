//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MieTrakWrapper.MieTrak
{
    using System;
    using System.Collections.Generic;
    
    public partial class Address
    {
        public Address()
        {
            this.Users = new HashSet<User>();
            this.BillPaymentChecks = new HashSet<BillPaymentCheck>();
            this.DivisionParameters = new HashSet<DivisionParameter>();
            this.DivisionParameters1 = new HashSet<DivisionParameter>();
            this.DivisionParameters2 = new HashSet<DivisionParameter>();
            this.DivisionParameters3 = new HashSet<DivisionParameter>();
            this.Form1099Report = new HashSet<Form1099Report>();
            this.Invoices = new HashSet<Invoice>();
            this.Invoices1 = new HashSet<Invoice>();
            this.InvoiceLines = new HashSet<InvoiceLine>();
            this.Manifests = new HashSet<Manifest>();
            this.Manifests1 = new HashSet<Manifest>();
            this.ManifestDropLocations = new HashSet<ManifestDropLocation>();
            this.PickLists = new HashSet<PickList>();
            this.PurchaseOrders = new HashSet<PurchaseOrder>();
            this.PurchaseOrders1 = new HashSet<PurchaseOrder>();
            this.PurchaseOrderReceivings = new HashSet<PurchaseOrderReceiving>();
            this.RequestForQuotes = new HashSet<RequestForQuote>();
            this.RequestForQuotes1 = new HashSet<RequestForQuote>();
            this.SalesOrders = new HashSet<SalesOrder>();
            this.SalesOrders1 = new HashSet<SalesOrder>();
            this.SalesOrderLines = new HashSet<SalesOrderLine>();
        }
    
        public int AddressPK { get; set; }
        public Nullable<int> AddressTypeFK { get; set; }
        public Nullable<int> StateFK { get; set; }
        public Nullable<int> CountryFK { get; set; }
        public Nullable<int> RegionFK { get; set; }
        public Nullable<int> DivisionFK { get; set; }
        public Nullable<int> PartyFK { get; set; }
        public Nullable<int> SalesTax1FK { get; set; }
        public Nullable<int> SalesTax2FK { get; set; }
        public Nullable<int> SalesTax3FK { get; set; }
        public Nullable<int> SalesTax4FK { get; set; }
        public Nullable<int> SalesTax1TypeFK { get; set; }
        public Nullable<int> SalesTax2TypeFK { get; set; }
        public Nullable<int> SalesTax3TypeFK { get; set; }
        public Nullable<int> SalesTax4TypeFK { get; set; }
        public Nullable<int> ShipViaFK { get; set; }
        public Nullable<int> TransitTime { get; set; }
        public Nullable<bool> DefaultShipping { get; set; }
        public string Code { get; set; }
        public string Fax { get; set; }
        public string Phone { get; set; }
        public string ShippingAccountNumber { get; set; }
        public string Contact { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string AddressAlt { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Comment { get; set; }
        public byte[] LastAccess { get; set; }
        public Nullable<int> FreightCodeFK { get; set; }
        public Nullable<int> LocationFK { get; set; }
        public Nullable<bool> RemitAddress { get; set; }
        public Nullable<bool> Archived { get; set; }
        public Nullable<bool> Exported { get; set; }
    
        public virtual AddressType AddressType { get; set; }
        public virtual Country Country { get; set; }
        public virtual Division Division { get; set; }
        public virtual FreightCode FreightCode { get; set; }
        public virtual Location Location { get; set; }
        public virtual Party Party { get; set; }
        public virtual Region Region { get; set; }
        public virtual SalesTax SalesTax { get; set; }
        public virtual SalesTax SalesTax1 { get; set; }
        public virtual SalesTax SalesTax2 { get; set; }
        public virtual SalesTax SalesTax3 { get; set; }
        public virtual SalesTaxType SalesTaxType { get; set; }
        public virtual SalesTaxType SalesTaxType1 { get; set; }
        public virtual SalesTaxType SalesTaxType2 { get; set; }
        public virtual SalesTaxType SalesTaxType3 { get; set; }
        public virtual ShipVia ShipVia { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<BillPaymentCheck> BillPaymentChecks { get; set; }
        public virtual ICollection<DivisionParameter> DivisionParameters { get; set; }
        public virtual ICollection<DivisionParameter> DivisionParameters1 { get; set; }
        public virtual ICollection<DivisionParameter> DivisionParameters2 { get; set; }
        public virtual ICollection<DivisionParameter> DivisionParameters3 { get; set; }
        public virtual ICollection<Form1099Report> Form1099Report { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Invoice> Invoices1 { get; set; }
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }
        public virtual ICollection<Manifest> Manifests { get; set; }
        public virtual ICollection<Manifest> Manifests1 { get; set; }
        public virtual ICollection<ManifestDropLocation> ManifestDropLocations { get; set; }
        public virtual ICollection<PickList> PickLists { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<PurchaseOrder> PurchaseOrders1 { get; set; }
        public virtual ICollection<PurchaseOrderReceiving> PurchaseOrderReceivings { get; set; }
        public virtual ICollection<RequestForQuote> RequestForQuotes { get; set; }
        public virtual ICollection<RequestForQuote> RequestForQuotes1 { get; set; }
        public virtual ICollection<SalesOrder> SalesOrders { get; set; }
        public virtual ICollection<SalesOrder> SalesOrders1 { get; set; }
        public virtual ICollection<SalesOrderLine> SalesOrderLines { get; set; }
    }
}
