using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Exercise3bShop.Models;

namespace Exercise3bShop.DAL
{
    public class ShopItemRepository : IItemRepository, IDisposable
    {
        ShopContext context;

        public ShopItemRepository(ShopContext context) {
            this.context = context;
        }

        public void DeleteItem(int ItemID)
        {
            this.context.ShopItems.Remove(this.context.ShopItems.Where(i => i.ID == ItemID).ToList()[0]);
        }

        public ShopItem GetItemByID(int ItemID)
        {
            return this.context.ShopItems.Where(i => i.ID == ItemID).ToList()[0];
        }

        public IEnumerable<ShopItem> GetItems()
        {
            return this.context.ShopItems.ToList();
        }

        public void InsertItem(ShopItem Item)
        {
            this.context.ShopItems.Add(Item);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UpdateItem(ShopItem Item)
        {
            context.Entry(Item).State = EntityState.Modified;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}