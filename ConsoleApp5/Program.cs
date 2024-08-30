using ConsoleApp5.content;
using ConsoleApp5.Modules;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDBContext dbcontext = new ApplicationDBContext();

            // Adding Products
            List<Product> products = new List<Product>()
            {
                new Product() { id = 1, name = "Laptop", price = 1000 },
                new Product() { id = 2, name = "Smartphone", price = 500 },
                new Product() { id = 3, name = "Tablet", price = 300 },
                new Product() { id = 4, name = "Monitor", price = 150 }
            };
            dbcontext.Products.AddRange(products);
            dbcontext.SaveChanges();

            // Adding Orders
            List<Order> orders = new List<Order>()
            {
                new Order() { id = 1, address = "123 Main St", CreatedAt = DateTime.Now, price = 100 },
                new Order() { id = 2, address = "456 Elm St", CreatedAt = DateTime.Now, price = 200 },
                new Order() { id = 3, address = "789 Oak St", CreatedAt = DateTime.Now, price = 300 }
            };
            dbcontext.Orders.AddRange(orders);
            dbcontext.SaveChanges();

            // Get All Products
            var productList = dbcontext.Products.ToList();
            Console.WriteLine("All Products:");
            foreach (var prod in productList)
            {
                Console.WriteLine($"ID: {prod.id}, Name: {prod.name}, Price: {prod.price}");
            }

            // Get All Orders
            var orderList = dbcontext.Orders.ToList();
            Console.WriteLine("\nAll Orders:");
            foreach (var ord in orderList)
            {
                Console.WriteLine($"ID: {ord.id}, Address: {ord.address}, Price: {ord.price}, CreatedAt: {ord.CreatedAt}");
            }

            // Update Product Name with ID 1
            var productToUpdate = dbcontext.Products.FirstOrDefault(p => p.id == 1);
            if (productToUpdate != null)
            {
                productToUpdate.name = "Gaming Laptop";
                dbcontext.SaveChanges();
                Console.WriteLine("\nUpdated Product ID 1 Name to 'Gaming Laptop'.");
            }

            // Update Order CreatedAt with ID 1
            var orderToUpdate = dbcontext.Orders.FirstOrDefault(o => o.id == 1);
            if (orderToUpdate != null)
            {
                orderToUpdate.CreatedAt = DateTime.Now.AddDays(-1);  // Example: Setting it to a day before
                dbcontext.SaveChanges();
                Console.WriteLine("\nUpdated Order ID 1 CreatedAt to a day before.");
            }

            // Remove Product with ID 2
            var productToRemove = dbcontext.Products.FirstOrDefault(p => p.id == 2);
            if (productToRemove != null)
            {
                dbcontext.Products.Remove(productToRemove);
                dbcontext.SaveChanges();
                Console.WriteLine("\nRemoved Product with ID 2.");
            }

            // Remove Order with ID 3
            var orderToRemove = dbcontext.Orders.FirstOrDefault(o => o.id == 3);
            if (orderToRemove != null)
            {
                dbcontext.Orders.Remove(orderToRemove);
                dbcontext.SaveChanges();
                Console.WriteLine("\nRemoved Order with ID 3.");
            }

            // Display updated lists after modifications
            Console.WriteLine("\nProducts After Update and Removal:");
            productList = dbcontext.Products.ToList();
            foreach (var prod in productList)
            {
                Console.WriteLine($"ID: {prod.id}, Name: {prod.name}, Price: {prod.price}");
            }

            Console.WriteLine("\nOrders After Update and Removal:");
            orderList = dbcontext.Orders.ToList();
            foreach (var ord in orderList)
            {
                Console.WriteLine($"ID: {ord.id}, Address: {ord.address}, Price: {ord.price}, CreatedAt: {ord.CreatedAt}");
            }
        }
    }
}
