using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Global.Repository.models;
using BonaStoco.Inf.DataMapper.Impl;

namespace Global.Repository
{
    public class ItemRepository:IItemRepository
    {
        QueryObjectMapper qryObjectMapper;
        public ItemRepository(QueryObjectMapper qryObject)
        {
            this.qryObjectMapper = qryObject;
        }
        public IList<Item> GetItems()
        {
            return qryObjectMapper.Map<Item>().OrderBy(i => i.Name).ToList();
        }
        public void AddItem(Item item)
        {
            string query = String.Format("INSERT INTO tblitem (name,deskripsi,harga,dendaperhari,status) values('{0}','{1}','{2}','{3}','{4}')",
                item.Name, item.Deskripsi, item.Harga,item.DendaPerHari, item.Status);
            qryObjectMapper.Map<Item>(query);
        }
        public void UpdateItem(Item item)
        {
            string query = String.Format("UPDATE tblitem set name= '{0}', deskripsi = '{1}', harga = '{2}', dendaperhari= '{3}' where itemid = '{4}'",
                item.Name, item.Deskripsi, item.Harga,item.DendaPerHari, item.ItemId);
            qryObjectMapper.Map<Item>(query);
        }
        public Item GetItemById(long id)
        {
            return qryObjectMapper.Map<Item>("GetItemById", new string[1] { "id" }, new object[1] { id }).FirstOrDefault();
        }
        public void ChangeStatus(string status, long itemId)
        {
            string query = String.Format("UPDATE tblitem set status = '{0}' where itemid = '{1}'",
                status, itemId);
            qryObjectMapper.Map<Item>(query);
        }
        public IList<Item> GetItemByName(string key)
        {
            key = "%" + key.ToLower() + "%";
            return qryObjectMapper.Map<Item>("GetItemByName", new string[1] { "key" }, new object[1] { key }).OrderBy(c => c.Name).ToList();
        }
    }
}
