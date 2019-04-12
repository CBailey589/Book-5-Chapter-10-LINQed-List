using System;
using System.Collections.Generic;
using System.Linq;

namespace myApp
{
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }

    public class Bank
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
    }

    public class BankReportEntry
    {
        public string ReportBank { get; set; }
        public int MillionairesInBank { get; set; }
    }

    public class ReportItem
    {
        public string CustomerName { get; set; }
        public string BankName { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Given the collections of items shown below, use LINQ to build the requested collection, and then Console.WriteLine() each item in that resulting collection.

            // Restriction/Filtering Operations
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            IEnumerable<string> LFruits = from taco in fruits
                                          where taco.StartsWith("L")
                                          select taco;
            foreach (String taco in LFruits)
            {
                Console.WriteLine($"{taco}");
            }


            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            IEnumerable<int> fourSixMultiples = numbers.Where(n => n % 4 == 0 || n % 6 == 0);
            foreach (int taco in fourSixMultiples)
            {
                Console.WriteLine($"{taco}");
            }


            // Ordering Operations
            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre"
            };

            IEnumerable<string> descend = from taco in names
                                          orderby taco descending
                                          select taco;
            foreach (string taco in descend)
            {
                Console.WriteLine($"{taco}");
            }

            // Build a collection of these numbers sorted in ascending order
            List<int> numbers2 = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            IEnumerable<int> ascend = from taco in numbers2
                                      orderby taco ascending
                                      select taco;
            foreach (int taco in ascend)
            {
                Console.WriteLine($"{taco}");
            }


            // Aggregate Operations
            // Output how many numbers are in this list
            List<int> numbers3 = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
            Console.WriteLine($"There are {numbers3.Count} numbers in numbers3");

            // How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };
            Console.WriteLine($"the sum of purchases is {purchases.Sum()}");

            // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };
            Console.WriteLine($"The most expensive product is {prices.Max()}");


            // Partitioning Operations
            /*
            Store each number in the following List until a perfect square
            is detected.

            Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
            */
            List<int> wheresSquaredo = new List<int>()
            {
                66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
            };
            IEnumerable<int> numsUntilPerfectSquare = wheresSquaredo.TakeWhile(n => n % Math.Sqrt(n) != 0);
            // List<int> untilPerfectSquareFound = wheresSquaredo.TakeWhile(number => Math.Sqrt(number) % 1 != 0).ToList();
            foreach (int taco in numsUntilPerfectSquare)
            {
                Console.WriteLine($"{taco}");
            }


            // Using Custom Types
            // // Build a collection of customers who are millionaires

            List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            IEnumerable<Customer> millionaires = customers.Where(taco => taco.Balance >= 1000000);
            foreach (Customer taco in millionaires)
            {
                Console.WriteLine($"{taco.Name}");
            }


            // Given the same customer set, display how many millionaires per bank.
            // Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq

            // Example Output:
            // WF 2
            // BOA 1
            // FTB 1
            // CITI 1

            List<BankReportEntry> BankReport = (from taco in millionaires
                                                group taco by taco.Bank into BankGroup
                                                select new BankReportEntry
                                                {
                                                    ReportBank = BankGroup.Key,
                                                    MillionairesInBank = BankGroup.Count()
                                                }
            ).OrderByDescending(br => br.MillionairesInBank).ToList();
            foreach (BankReportEntry taco in BankReport)
            {
                Console.WriteLine($" Bank: {taco.ReportBank}, Balance: {taco.MillionairesInBank}");
            }

            // Dictionary<string, int> results = new Dictionary<string, int>();

            // results.Add(millionaires.GroupBy(
            //                            p => p.Bank,
            //                            (taco, g) => { taco, g.Count()});



           var results = millionaires.GroupBy(
               p => p.Bank,
               (key, g) => new { Bank = key, p = g.Count() });

           foreach (var item in results)
           {
               Console.WriteLine(item);
           }




            // Introduction to Joining Two Related Collections
            // As a light introduction to working with relational databases, this example works with two collections of data - banks and customers - that are related through the Bank attribute on the customer. In that attribute, we store the abbreviation for a bank. However, we want to get the full name of the bank when we produce our output.

            // This is called joining the collections together.

            // This exercise is also an introduction to producing anonymous objects as the result of the LINQ statement.

            // Read the Group Join example to get started.

            // TASK:
            // As in the previous exercise, you're going to output the millionaires,
            // but you will also display the full name of the bank. You also need
            // to sort the millionaires' names, ascending by their LAST name.

            // Example output:
            //     Tina Fey at Citibank
            //     Joe Landy at Wells Fargo
            //     Sarah Ng at First Tennessee
            //     Les Paul at Wells Fargo
            //     Peg Vale at Bank of America

            // Create some banks and store in a List
            List<Bank> banks = new List<Bank>() {
            new Bank(){ Name="First Tennessee", Symbol="FTB"},
            new Bank(){ Name="Wells Fargo", Symbol="WF"},
            new Bank(){ Name="Bank of America", Symbol="BOA"},
            new Bank(){ Name="Citibank", Symbol="CITI"},
        };

            // Create some customers and store in a List
            List<Customer> customers2 = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };

            /*
                You will need to use the `Where()`
                and `Select()` methods to generate
                instances of the following class.

                public class ReportItem
                {
                    public string CustomerName { get; set; }
                    public string BankName { get; set; }
                }
            */

            List<ReportItem> millionaireNamesSorted = customers2
            .Where(taco => taco.Balance >= 1000000)
            .OrderBy(taco => taco.Name.Split(" ")[1])
            .Select(taco => new ReportItem
            {
                CustomerName = taco.Name,
                BankName = banks.First(bankTaco => bankTaco.Symbol == taco.Bank).Name
            })
            .ToList();

            foreach (ReportItem taco in millionaireNamesSorted)
            {
                Console.WriteLine($"{taco.CustomerName} {taco.BankName}");
            }
        }
    }
}
