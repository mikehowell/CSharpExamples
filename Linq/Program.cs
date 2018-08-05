﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Linq
{
    class Program
    {
        static List<Customer> customers = new List<Customer>
        {
            new Customer {First = "Cailin", Last = "Alford", State = "GA", Price = 930.00, Purchases = new string[] {"Panel 625", "Panel 200"}},
            new Customer {First = "Theodore", Last = "Brock", State = "AR", Price = 2100.00, Purchases = new string[] {"12V Li"}},
            new Customer {First = "Jerry", Last = "Gill", State = "MI", Price = 585.80, Purchases = new string[] {"Bulb 23W", "Panel 625"}},
            new Customer {First = "Owens", Last = "Howell", State = "GA", Price = 512.00, Purchases = new string[] {"Panel 200", "Panel 180"}},
            new Customer {First = "Adena", Last = "Jenkins", State = "OR", Price = 2267.80, Purchases = new string[] {"Bulb 23W", "12V Li", "Panel 180"}},
            new Customer {First = "Medge", Last = "Ratliff", State = "GA", Price = 1034.00, Purchases = new string[] {"Panel 625"}},
            new Customer {First = "Sydney", Last = "Bartlett", State = "OR", Price = 2105.00, Purchases = new string[] {"12V Li", "AA NiMH"}},
            new Customer {First = "Malik", Last = "Faulkner", State = "MI", Price = 167.80, Purchases = new string[] {"Bulb 23W", "Panel 180"}},
            new Customer {First = "Serena", Last = "Malone", State = "GA", Price = 512.00, Purchases = new string[] {"Panel 180", "Panel 200"}},
            new Customer {First = "Hadley", Last = "Sosa", State = "OR", Price = 590.20, Purchases = new string[] {"Panel 625", "Bulb 23W", "Bulb 9W"}},
            new Customer {First = "Nash", Last = "Vasquez", State = "OR", Price = 10.20, Purchases = new string[] {"Bulb 23W", "Bulb 9W"}},
            new Customer {First = "Joshua", Last = "Delaney", State = "WA", Price = 350.00, Purchases = new string[] {"Panel 200"}}
        };

        static List<Distributor> distributors = new List<Distributor>
        {
            new Distributor {Name = "Edgepulse", State = "UT"},
            new Distributor {Name = "Jabbersphere", State = "GA"},
            new Distributor {Name = "Quaxo", State = "FL"},
            new Distributor {Name = "Yakijo", State = "OR"},
            new Distributor {Name = "Scaboo", State = "GA"},
            new Distributor {Name = "Innojam", State = "WA"},
            new Distributor {Name = "Edgetag", State = "WA"},
            new Distributor {Name = "Leexo", State = "HI"},
            new Distributor {Name = "Abata", State = "OR"},
            new Distributor {Name = "Vidoo", State = "TX"}
        };

        static void Main(string[] args)
        {
            //filtering
            var stateQuery =
                from c in customers
                select c;

            foreach (Customer c in stateQuery)
            {
                Console.WriteLine("{0} {1}: {2:C}", c.First, c.Last, c.Price);
            }

            Console.ReadLine();

            var stateQueryAndPurchases =
                from c in customers
                where c.State == "OR" && c.Price > 1000
                select c;

            foreach (Customer c in stateQueryAndPurchases)
            {
                Console.WriteLine("{0} {1}: {2:C}", c.First, c.Last, c.Price);
            }

            Console.ReadLine();

            var purchasesQuery =
               from c in customers
               from p in c.Purchases
               select p;
                //select new CustPurchase { custName = c.First + " " + c.Last, productPurchased = p }; //projection?
               //select new { custName = c.First, productPurchased = p };

            foreach (var p in purchasesQuery)
            //foreach (var cp in purchasesQuery)
            {
                Console.WriteLine("{0}", p);
                //Console.WriteLine("{0} - {1}", cp.custName, cp.productPurchased);
            }

            Console.ReadLine();

            //joining & projection?
            var matchupquery =
                from c in customers
                join d in distributors on c.State equals d.State
                select new CustDist { custName = c.Last, distName = d.Name};

            foreach (var cd in matchupquery)
            {
                Console.WriteLine("{0}, {1}", cd.custName, cd.distName);
            }

            Console.ReadLine();
        }
    }
}