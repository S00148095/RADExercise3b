using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Exercise3bShop.Models
{
    public class Purchases
    {
        public int ID { get; set; }
        public DateTime PurchaseDate { get; set; }
        public virtual User User { get; set; }
        public virtual ShopItem Item { get; set; }
    }
}