using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantMenu.Models
{
    public class Menu
    {
        private DateTime lastUpdatedUtc;
        public Dictionary<MenuItem, DateTime> MenuItems { get; set; }

        public DateTime LastUpdated
        {
            get { return lastUpdatedUtc.ToLocalTime(); }
        }

        private const int NEW_TIMESPAN_IN_DAYS = 14;


        public void AddMenuItem(MenuItem menuItem)
        {
            if (!MenuItems.ContainsKey(menuItem))
            {
                lastUpdatedUtc = DateTime.UtcNow;
                this.MenuItems.Add(menuItem, lastUpdatedUtc);
            }
        }

        public void RemoveMenuItem(MenuItem menuItem)
        {
            this.MenuItems.Remove(menuItem);
        }

        private bool IsNew(DateTime dateAdded)
        {
            return DateTime.UtcNow < dateAdded.AddDays(NEW_TIMESPAN_IN_DAYS);
        }

        public List<MenuItem> GetNewMenuItems()
        {
            List<MenuItem> newItems = new List<MenuItem>();
            foreach (KeyValuePair<MenuItem, DateTime> item in MenuItems)
                if (IsNew(item.Value))
                    newItems.Add(item.Key);

            return newItems;
        }

        public static void PrintMenu(Menu menu)
        {
            throw new NotImplementedException();
        }
    }
}
