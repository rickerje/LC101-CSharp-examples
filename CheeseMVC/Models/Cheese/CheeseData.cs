using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models.Cheese
{
    public class CheeseData
    {
        private static List<Cheese> cheeses = new List<Cheese>();
        private static int nextId = 1;

        //DisplayAll
        public static List<Cheese> DisplayAll()
        {
            List<Cheese> cheeseList = new List<Cheese>();
            cheeseList.AddRange(cheeses);
            return cheeseList;
        }

        //Display a single cheese
        public static Cheese GetById(int cheeseId)
        {
            return cheeses.SingleOrDefault(chs => chs.Id == cheeseId);
        }

        //Add
        public static void AddCheese(Cheese newCheese)
        {
            newCheese.Id = nextId++;
            cheeses.Add(newCheese);
        }

        //Remove
        public static void Remove (int cheeseId)
        {
            Cheese cheeseToRemove = GetById(cheeseId);
            cheeses.Remove(cheeseToRemove);
            //cheeses.RemoveAll(chs => chs.Id == cheeseId)
        }

        public static void Remove (Cheese cheeseToRemove)
        {
            //calling Remove method above
            Remove(cheeseToRemove.Id);
        }
    }
}

