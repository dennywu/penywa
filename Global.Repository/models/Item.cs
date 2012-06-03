using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BonaStoco.Inf.Data.ViewModel;

namespace Global.Repository.models
{
    [SqlQuery("SELECT * FROM tblitem")]
    [NamedSqlQuery("GetItemById",@"SELECT * FROM tblitem where itemid = @id")]
    [NamedSqlQuery("GetItemByName", @"SELECT * FROM tblitem where lower(name) like @key and status not like 'Non Aktif'")]
    public class Item : IViewModel
    {
        public long ItemId { get; set; }
        public string Name { get; set; }
        public string Deskripsi { get; set; }
        public string Status { get; set; }
        public decimal Harga { get; set; }
        public decimal DendaPerHari { get; set; }
    }
}
