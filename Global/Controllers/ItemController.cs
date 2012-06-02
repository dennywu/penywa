using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Global.Repository;
using Spring.Context.Support;
using Global.Repository.models;
using Global.Models;

namespace Global.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
        IItemRepository itemRepo;
        public ActionResult Index()
        {
            IList<Item> items = ItemRepository.GetItems();
            return View(items);
        }

        public ActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddItem(Item item)
        {
            try
            {
                item.Status = StatusItem.ACTIVE;
                ItemRepository.AddItem(item);
                return RedirectToAction("Index", "Item");
            }
            catch(ApplicationException ex)
            {
                return View(ex.Message);
            }
        }

        public JsonResult GetItemById(long id)
        {
            Item item = ItemRepository.GetItemById(id);
            return Json(item, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateItem(long id)
        {
            Item item = ItemRepository.GetItemById(id);
            return View(item);
        }

        [HttpPost]
        public ActionResult UpdateItem(Item item)
        {
            try
            {
                ItemRepository.UpdateItem(item);
                return RedirectToAction("Index", "Item");
            }
            catch (ApplicationException ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult ChangeStatusItem(string status, long itemId)
        {
            try
            {
                string stat = string.Empty;
                if (status == "AKTIF")
                    stat = StatusItem.ACTIVE;
                else
                    stat = StatusItem.NONACTIVE;
                ItemRepository.ChangeStatus(stat, itemId);
                return RedirectToAction("Index", "Item");
            }
            catch (ApplicationException ex)
            {
                return View(ex.Message);
            }
        }

        [HttpGet]
        public JsonResult SearchItemByName(string key)
        {
            IList<Item> item = ItemRepository.GetItemByName(key);
            return Json(item, JsonRequestBehavior.AllowGet);
        }

        private IItemRepository ItemRepository
        {
            get
            {
                if (itemRepo == null)
                    itemRepo = (IItemRepository)ContextRegistry.GetContext().GetObject("ItemRepository");
                return itemRepo;
            }
        }
    }
}
