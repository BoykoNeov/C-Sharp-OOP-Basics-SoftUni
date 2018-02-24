using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        List<Person> people = new List<Person>();
        List<Product> products = new List<Product>();

        string[] personsInput = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string personInput in personsInput)
        {
            try
            {
                string[] currentPersonArgs = personInput.Split(new char[] { '=' });
                string name = currentPersonArgs[0];
                decimal money = decimal.Parse(currentPersonArgs[1]);
                Person person = new Person(name, money);
                people.Add(person);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        string[] productAndTheirCost = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var currentProduct in productAndTheirCost)
        {
            try
            {
                string[] currentProductArgs = currentProduct.Split(new char[] { '=' });
                string productName = currentProductArgs[0];
                decimal cost = decimal.Parse(currentProductArgs[1]);
                Product product = new Product(productName, cost);
                products.Add(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

        }

        string comandLine = string.Empty;
        while ((comandLine = Console.ReadLine()) != "END")
        {
            string[] tokens = comandLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Person person = people.FirstOrDefault(x => x.Name == tokens[0]);
            Product product = products.FirstOrDefault(x => x.Name == tokens[1]);

            if (person != null && product != null)
            {
                if (product.Cost <= person.Money)
                {
                    person.Products.Add(product);
                    person.Money -= product.Cost;

                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }
            }
        }

        foreach (Person person in people)
        {
            if (!person.Products.Any())
            {
                Console.WriteLine($"{person.Name} - Nothing bought");
                continue;
            }

            Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products)}");
        }
    }
}