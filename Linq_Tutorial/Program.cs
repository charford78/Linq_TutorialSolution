using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>() {
                new Customer { Id = 1, Name = "Amazon" },
                new Customer { Id = 2, Name = "Target" },
                new Customer { Id = 3, Name = "Microsoft" }
            };

            var orders = new List<Order>() {
                new Order { Id = 1, Description = "1st Order", Sales = 1000, CustomerId = 1 },
                new Order { Id = 2, Description = "2nd Order", Sales = 2000, CustomerId = 3 },
                new Order { Id = 3, Description = "3rd Order", Sales = 3000, CustomerId = 2 }
            };

            var CustOrders = from o in orders
                             join c in customers
                                on o.CustomerId equals c.Id
                             select new { o, c };

            foreach(var co in CustOrders)
            {
                Console.WriteLine($"{co.c.Name} | {co.o.Description} | {co.o.Sales}");
            }
        }    
        static void X() {     
            int[] ints = new int[]
            {
                620, 849, 649, 989, 993, 524, 216, 173, 136, 482,
                842, 308, 251, 572, 150, 797, 611, 489, 934, 310,
                985, 764, 484, 816, 753, 925, 289, 231, 486, 761,
                621, 981, 103, 482, 917, 124, 276, 839, 476 ,789,
                582, 631, 841, 398, 521, 796, 199, 941, 782, 953,
                412, 362, 424, 336, 812, 344, 579, 570, 212, 483,
                250, 829, 835, 429, 833, 992, 657, 461, 782, 498,
                829, 648, 189, 579, 645, 584, 989, 254, 859, 321,
                991, 421, 151, 350, 687, 491, 568, 548, 403, 836,
                303, 104, 538, 426, 150, 843, 943, 864, 694, 639
            };
            var sum = ints.Sum() - ints.Max() - ints.Min();
            var avg = sum / (ints.Count() - 2.0);

            ////method syntax
            //var lessavg = ints.Where(i => i < ints.Average()).OrderByDescending(i => i);
            //foreach (var i in lessavg)
            //{
            //    Console.Write($"{i} ");
            //}

            //
            //or in query syntax
            var Lessavg = from i in ints
                          where i < ints.Average()
                          orderby i descending
                          select i;
            foreach (var i in Lessavg)
            {
                Console.Write($"{i} ");
            }



            //Console.WriteLine($"The average is {ints.Average()}");
            //Console.WriteLine($"The biggest number in the list is {ints.Max()}");
            //Console.WriteLine($"The average without the largest and smallest numbers is " +
            //                    $"{avg}");
        }
    }    
}
