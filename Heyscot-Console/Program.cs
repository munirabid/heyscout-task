using Heyscot_DataAccess;
using System;
using static Heyscot_DataAccess.Enums.Enums;

namespace Heyscot_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=heyscot;Uid=root;Pwd=123@a123;";
            MatchCustomerTalent matchTalents = new MatchCustomerTalent(connectionString);

            var customerTalents = matchTalents.GetCustomerTalents(DropDownList.All.ToString());

            if (customerTalents != null)
            {
                if (customerTalents.Customers.Count > 0)
                {
                    Console.WriteLine("---------------------Customers-----------------------");

                    foreach (var item in customerTalents.Customers)
                    {
                        Console.WriteLine("Name: {0} , City: {1}, Registration Date: {2}", item.Name, item.City, item.RegistrationDate.ToString("dd-mm-yyyy"));
                    }
                }

                if (customerTalents.Talents.Count > 0)
                {
                    Console.WriteLine("---------------------Talents-----------------------");

                    foreach (var item in customerTalents.Talents)
                    {
                        Console.WriteLine("Name: {0} , City: {1}", item.Name, item.City);
                    }
                }
            }

            var matchedCustomerTalents = matchTalents.GetCustomerTalents(DropDownList.MatchByCity.ToString());

            if (matchedCustomerTalents != null)
            {
                if (matchedCustomerTalents.Customers.Count > 0)
                {
                    Console.WriteLine("---------------------Matched Customers-----------------------");

                    foreach (var item in matchedCustomerTalents.Customers)
                    {
                        Console.WriteLine("Name: {0} , City: {1}, Registration Date: {2}", item.Name, item.City, item.RegistrationDate.ToString("dd-mm-yyyy"));
                    }
                }

                if (matchedCustomerTalents.Talents.Count > 0)
                {
                    Console.WriteLine("---------------------Matched Talents-----------------------");

                    foreach (var item in matchedCustomerTalents.Talents)
                    {
                        Console.WriteLine("Name: {0} , City: {1}", item.Name, item.City);
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
