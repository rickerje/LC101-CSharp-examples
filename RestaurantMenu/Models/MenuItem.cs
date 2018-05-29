using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantMenu.Models
{
    public class MenuItem
    {
        public double Price { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != typeof(MenuItem))
                return false;

            return Equals((MenuItem)obj);
        }

        public bool Equals(MenuItem menuItem)
        {
            if (menuItem == null)
                return false;

            return menuItem.Name == this.Name;
        }

        public static void Print(MenuItem menuItem)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode(MenuItem menuItem)
        {
            return menuItem.Name.GetHashCode();
        }
    }
}
