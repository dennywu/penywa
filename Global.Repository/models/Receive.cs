using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonaStoco.Inf.Data.ViewModel;

namespace Global.Repository.models
{
    public class Receive
    {
        public Guid ReceiveId { get; set; }
        public string ReceiveNo { get; set; }
        public int CustId { get; set; }
        public DateTime ReceiveDate { get; set; }
        public ReceiveItem[] Items { get; set; }
    }
    public class ReceiveHeader:IViewModel
    {
        public Guid ReceiveId { get; set; }
        public string ReceiveNo { get; set; }
        public int CustId { get; set; }
        public DateTime ReceiveDate { get; set; }
    }
    public class ReceiveItem:IViewModel
    {
        public Guid ReceiveId { get; set; }
        public Guid RentalId { get; set; }
        public decimal Total { get; set; }
        public decimal TotalDenda { get; set; }
        public decimal TotalAfterDenda { get; set; }
        public decimal PayAmount { get; set; }
    }
    public class ReceiveSummary : IViewModel
    {
        public Guid ReceiveId { get; set; }
        public decimal Total { get; set; }
    }
}
