namespace Exercise3bShop.Migrations
{
    using Exercise3bShop.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Exercise3bShop.Models.ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Exercise3bShop.Models.ShopContext context)
        {
            var Users = new List<User> {
                new User(){ Username="ngannon", Balance=200 },
                new User(){ Username="jsmith", Balance=100 },
                new User(){ Username="sdoe", Balance=2000 },
                new User(){ Username="mriley", Balance=750 }
            };

            var Items = new List<ShopItem> {
                new ShopItem(){ Name="Small Health", Cost=50, Class=ItemClass.Health, ImageURL="~/Content/Images/health_icon.png" },
                new ShopItem(){ Name="Large Health", Cost=100, Class=ItemClass.Health, ImageURL="~/Content/Images/health_icon.png" },
                new ShopItem(){ Name="Small Magic", Cost=50, Class=ItemClass.Magic, ImageURL="~/Content/Images/magic_icon.png" },
                new ShopItem(){ Name="Large Magic", Cost=100, Class=ItemClass.Magic, ImageURL="~/Content/Images/magic_icon.png" },
                new ShopItem(){ Name="Large Stamina", Cost=50, Class=ItemClass.Stamina, ImageURL="~/Content/Images/stamina_icon.png" },
                new ShopItem(){ Name="Small Stamina", Cost=100, Class=ItemClass.Stamina, ImageURL="~/Content/Images/stamina_icon.png" }
            };

            Users.ForEach(u => context.Users.Add(u));
            Items.ForEach(i => context.ShopItems.Add(i));

            context.SaveChanges();
        }
    }
}
