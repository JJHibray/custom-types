using System;
using System.Linq;
using System.Collections.Generic;

namespace Custom_Types
{


            // Build a collection of customers who are millionaires
                // public class Customer
                // {
                //     public string Name { get; set; }
                //     public double Balance { get; set; }
                //     public string Bank { get; set; }
                // }

                // public class Rich
                // {
                //    public string BankName { get; set; }

                //    public int RichFolks { get; set; }

                // }

                // public class Program
                // {
                //     public static void Main() {

                //         List<Customer> customers = new List<Customer>() {
                //             new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                //             new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                //             new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                //             new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                //             new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                //             new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                //             new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                //             new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                //             new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                //             new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
                //         };

                //         IEnumerable<Rich> Millionares = ( from customer in customers

                //             group customer by customer.Bank into richGroup

                //             select new Rich {

                //                 BankName = richGroup.Key,
                //                 RichFolks = richGroup.Where(monies => monies.Balance >= 1000000).Count()


                //             }


                //         );

                //         foreach (Rich millionaire in Millionares)
                //         {
                //             Console.WriteLine($"Banks:{millionaire.BankName} Balance: {millionaire.RichFolks}");
                //         }

                // }
                /*
                    Given the same customer set, display how many millionaires per bank.
                    Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq

                    Example Output:
                    WF 2
                    BOA 1
                    FTB 1
                    CITI 1
                */


                    public class Bank
                {
                    public string Symbol { get; set; }
                    public string Name { get; set; }
                }

                // Define a customer
                public class Customer
                {
                    public string Name { get; set; }
                    public double Balance { get; set; }
                    public string Bank { get; set; }
                }

                public class ReportItem
                {
                    public string CustomerName { get; set; }
                    public string BankName { get; set; }
                }

                public class Program
                {
                    public static void Main() {
                        // Create some banks and store in a List
                        List<Bank> banks = new List<Bank>() {
                            new Bank(){ Name="First Tennessee", Symbol="FTB"},
                            new Bank(){ Name="Wells Fargo", Symbol="WF"},
                            new Bank(){ Name="Bank of America", Symbol="BOA"},
                            new Bank(){ Name="Citibank", Symbol="CITI"},
                        };

                        // Create some customers and store in a List
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
                        List<ReportItem> millionaireReport = (

                            from oneBank in banks
                            join customer in customers.Where(customer => customer.Balance >= 1000000)
                            on oneBank.Symbol equals customer.Bank
                            select new ReportItem{

                            CustomerName = customer.Name,
                            BankName = oneBank.Name}).OrderBy(Custy => Custy.CustomerName.Split(" ")[1]).ToList();



                        foreach(var item in millionaireReport)
                        {
                            Console.WriteLine($"{item.CustomerName} at {item.BankName}");
                        }

                }

    }
}




