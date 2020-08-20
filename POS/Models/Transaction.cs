using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Models

{
    [Table("tblTransactionMaster")]
    public class TransactionMaster
    {
        /*  Sl, TransactionType, TransactionDate, PaymentDate,TransactionMonthYear, TransactionId, 
        MenualTransactionId, MenualOrderId, VendorSupId, StoreIdFrom, StoreIdTo, Remarks, 
        PaymentType, TotalAmount, DiscountPercent, DiscountAmount, VatAmount, NetAmount, 
        CashAmount,BankAmount, PaidAmount, DueAmount, CreateDate, CreateBy, EditId, EditDate, Action,IsCancel   */
        [Key]
        public Int64 Sl { get; set; }
        public string TransactionType { get; set; }
        [DisplayName("Transaction Date:")]
        public DateTime TransactionDate { get; set; }
        [DisplayName("Payment Date:")]
        public DateTime? PaymentDate { get; set; } 
        [DisplayName("Month Year:")]
        public string TransactionMonthYear { get; set; }
        [DisplayName("Transaction Id:")]
        public string TransactionId { get; set; }
        public string BrandId { get; set; }
        public string MenualOrderId { get; set; }
        [DisplayName("Name:")]
        public string VendorSupId { get; set; }
        [DisplayName("From:")]
        public string StoreIdFrom { get; set; }
        [DisplayName("To:")]
        public string StoreIdTo { get; set; } 
        [DisplayName("Remarks:")]
        public string Remarks { get; set; }
        public string PaymentType { get; set; }
        public string BankName { get; set; }
        public decimal? TotalAmount { get; set; }
        public string DiscountType { get; set; }
        public decimal? DiscountPercent { get; set; }
        public decimal? OtherDiscountPercent { get; set; }
        public decimal? DiscountAmount { get; set; }
        public decimal? UtilizeDiscountAmount { get; set; }
        public decimal? PromotionalAmount { get; set; }
        public decimal? VatAmount { get; set; }
        public decimal? NetAmount { get; set; }
        [DisplayName("Cash Amount:")]
        [DefaultValue(0.00)]
        public decimal CashAmount { get; set; }
        [DisplayName("Bank Amount:")]
        [DefaultValue(0.00)]
        public decimal BankAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }
        public DateTime? CreateDate { get; set; }
        public Int64 CreateBy { get; set; }
        public DateTime? EditDate { get; set; }
        public int? EditId { get; set; }
        public string Action { get; set; }
        [DefaultValue(false)]
        public bool IsCancel { get; set; }
    }
    [Table("tblTransactionDetails")]
    public class TransactionDetails
    {
        /* SELECT Sl, TransactionType, TransactionDate, TransactionMonthYear, 
        TransactionId, GiftType, ItemSerial, ItemId, SizeId, PackQty, SizeQty, UnitQty, 
        UnitRate, Amount, RemarksDetails, CreateBy, CreateDate, EditId, EditDate, Action
        FROM tblTransactionDetails */
        [Key]
        public Int64 Sl { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionMonthYear { get; set; }
        public string TransactionId { get; set; }
        public string GiftType { get; set; }
        public int ItemSerial { get; set; }
        public string BrandId { get; set; }
        public string ProductId { get; set; }
        public int PackId { get; set; }

        public decimal PackQty { get; set; }
        public decimal SizeQty { get; set; }
        public decimal UnitQty { get; set; }
        public decimal UnitRate { get; set; }
        public decimal Amount { get; set; }
        public string RemarksDetails { get; set; }
        public DateTime? CreateDate { get; set; }
        public Int32? CreateBy { get; set; }
        public DateTime? EditDate { get; set; }
        public Int32? EditId { get; set; }
        public string Action { get; set; }
    }

    public class TransactionDetailsCc
    {
        //CounterId: count, GiftType: itemType, ItemTypeName: itemTypeName, ItemId: itemid,
        //ItemName: itemName, PackQty: txtPackQty, UnitQty: txtUnitQty, UnitRate: txtUnitRate, Amount: txtAmount
        public string CounterId { get; set; }
        public string GiftType { get; set; }
        public string ItemTypeName { get; set; }
        public string BrandId { get; set; } 
        public string ProductId { get; set; }
        public string ItemName { get; set; }
    
        public string PackQty { get; set; }
        public string UnitQty { get; set; }
        public string UnitRate { get; set; }
        public string Amount { get; set; }
    }

    [Table("tblBank")]
    public class Bank
    {
        // Sl, BankName, BankInitial, CreateBy, CreateDate, EditId, EditDate, Action
        [Key]
        public int Sl { get; set; }
        public int Acc_NameFk { get; set; }
        [DisplayName("Bank Name:")]
        [Required]
        public string BankName { get; set; }
        public string BankInitial { get; set; }
        public DateTime? CreateDate { get; set; }
        public Int32? CreateBy { get; set; }
        public DateTime? EditDate { get; set; }
        public Int32? EditId { get; set; }
        public string Action { get; set; }
    }

    [Table("tblExpenseName")]
    public class tblExpenceName
    {
        // Sl, TypeName, CreateBy, CreateDate, EditId, EditDate, Action
        [Key]
        public Int64 Sl { get; set; }
        [DisplayName("Expense Name:")]
        [Required]
        public string ExpName { get; set; }
        public string Description { get; set; }
        public string ExpNameId { get; set; }
        public DateTime? CreateDate { get; set; }
        public Int32? CreateBy { get; set; }
        public DateTime? EditDate { get; set; }
        public Int32? EditId { get; set; }
        public string Action { get; set; }
    }


    [Table("tblExpenseEntry")]
    public class tblExpenseEntry
    {
        // Sl, TypeName, CreateBy, CreateDate, EditId, EditDate, Action
        [Key]
        public Int64 Sl { get; set; }
        //public string ReferenceNo { get; set; }
        [DisplayName("Expense Type:")]
        [Required]
        public string ExpNameId { get; set; }
        [DisplayName("Party:")]
        [Required]
        public string PartySupId { get; set; }
        public string Remarks { get; set; }
        [DisplayName("Name:")]
        [Required]
        public string DealerName { get; set; }
        public string DealerEID { get; set; }
        public decimal Amount { get; set; }
        [DisplayName("Date:")]
        [Required]
        public DateTime EntryDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public Int32? CreateBy { get; set; }
        public DateTime? EditDate { get; set; }
        public Int32? EditId { get; set; }
        public string Action { get; set; }
    }

    public class TransactionMasterWithPartyDetails
    {
        public TransactionMaster TransactionMasters { get; set; }
        //public PartySupplier PartySuppliers { get; set; }
        public Supplier Suppliers { get; set; }
        //public EmployeeInfo EmployeeInfo { get; set; }
        public PaymentHistory PaymentHistory { get; set; }
        //public ItemBrand ItemBrand { get; set; }
        public Company Company { get; set; }
    }
    public class TransactionDetailsWithItemnameDetails
    {
        public TransactionDetails TransactionDetails { get; set; }
        //public ItemDb ItemDb { get; set; }
    }



    public class SampleItemDetailsCc
    {
        //CounterId: count, GiftType: itemType, ItemTypeName: itemTypeName, ItemId: itemid,
        //ItemName: itemName, PackQty: txtPackQty, UnitQty: txtUnitQty, UnitRate: txtUnitRate, Amount: txtAmount
        public Int64 CounterId { get; set; }
        public string GiftType { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string PackQty { get; set; }
        public string UnitQty { get; set; }
        public string UnitRate { get; set; }
        public string Amount { get; set; }
    }

    public class ViewSampleItem
    {
        //public SampleItem SampleItem {get; set;}
        //public ItemDb ItemDb { get; set; }
        public Int64 CounterId { get; set; }
        public string GiftType { get; set; }
        public int ItemSerial { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public int SizeQty { get; set; }
        public decimal PackQty { get; set; }
        public decimal UnitQty { get; set; }
        public decimal UnitRate { get; set; }
        public decimal Amount { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreateDate { get; set; }
        public Int32? CreateBy { get; set; }
        public DateTime? EditDate { get; set; }
        public Int32? EditId { get; set; }
        public string Action { get; set; }
    }
    [Table("tblPaymentHistory")]
    public class PaymentHistory
    {
        /*  Sl, TransactionType, TransactionDate, PaymentDate,TransactionMonthYear, TransactionId, 
        MenualTransactionId, MenualOrderId, VendorSupId, StoreIdFrom, StoreIdTo, Remarks, 
        PaymentType, TotalAmount, DiscountPercent, DiscountAmount, VatAmount, NetAmount, 
        CashAmount,BankAmount, PaidAmount, DueAmount, CreateDate, CreateBy, EditId, EditDate, Action,IsCancel   */
        [Key]
        public Int64 Sl { get; set; }
        [DisplayName("Payment Date:")]
        public DateTime? PaymentDate { get; set; } 
        [DisplayName("Transaction Id:")]
        public string TransactionId { get; set; }
        [DisplayName("Party Name:")]
        public string VendorSupId { get; set; }
        [DisplayName("Payment Type:")]
        public string PaymentType { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? NetAmount { get; set; }
        [DisplayName("Cash Amount:")]
        [DefaultValue(0.00)]
        public decimal CashAmount { get; set; }
        [DisplayName("Bank Amount:")]
        [DefaultValue(0.00)]
        public decimal BankAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal DueAmount { get; set; }
        public DateTime? CreateDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime? EditDate { get; set; }
        public int? EditId { get; set; }
        public string Action { get; set; }
        public string TransactionType { get; set; }
    }
}