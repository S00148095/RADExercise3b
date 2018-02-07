using Exercise3bShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise3bShop.DAL
{
    public interface IItemRepository: IDisposable
    {
        IEnumerable<ShopItem> GetItems();
        ShopItem GetItemByID(int ItemID);

        void InsertItem(ShopItem Item);
        void UpdateItem(ShopItem Item);
        void DeleteItem(int ItemID);
        void Save();
    }
}