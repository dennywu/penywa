using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Global.Repository.models;

namespace Global.Repository
{
    public interface IItemRepository
    {
        IList<Item> GetItems();
        void AddItem(Item item);
        Item GetItemById(long id);
        void UpdateItem(Item item);
        void ChangeStatus(string status, long itemId);
    }
}
