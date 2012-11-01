using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test
{
    public class Class1
    {
        public static void Main(String[] args)
        {
            IT1901Entities1 db = new IT1901Entities1();

            List<Sauer> sheepIDs = db.Sauer.ToList();

            foreach (Sauer i in sheepIDs)
            {
                Console.WriteLine(i.sauID);
            }

        }

    }
}