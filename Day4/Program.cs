using Day4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class Program
    {

        /* -------------- DATABASE SCHEMA DESIGN -------------------
         * Diagram: https://drive.google.com/file/d/0B8ie37YIHMJUZmIyYjQyU041SHM/view?usp=sharing
         *  
         */


        /*****************************************************
         * Main()
         ****************************************************/
        static void Main(string[] args)
        {
            using (var db = new OrderContext())
            {
                while (true)
                {
                    Console.WriteLine("1) Create Customer");
                    Console.WriteLine("2) Create Product");
                    Console.WriteLine("3) Start Order");
                    Console.WriteLine("4) Add Product to Order");
                    int choice = int.Parse(WriteRead(">> "));

                    switch (choice)
                    {
                        case 1:
                            CreateCustomer(db);
                            break;
                        case 2:
                            CreateProduct(db);
                            break;
                        case 3:
                            CreateOrder(db);
                            break;
                        case 4:
                            CreateOrderItem(db);
                            break;
                        default:
                            break;
                    }
                    Console.Clear();
                }
            }
        }
        

        /*****************************************************
         * WriteRead()
         *     Cuts down on code
         ****************************************************/
        static string WriteRead(string input)
        {
            Console.Write(input);
            return Console.ReadLine();
        }

        /*****************************************************
         * CreateOrderItem()
         *      Gets and adds OrderItem data to db
         ****************************************************/
        private static void CreateOrderItem(OrderContext db)
        {
            int allOrderItems = db.OrderItems.Count();
            Console.WriteLine($"{allOrderItems} Order Items in DB.");

            foreach (var o in db.Orders)
            {
                Console.WriteLine($"Order number and customer name: {o.Id} - {o.Customer.Name}");
                /*SELECT o.Id, c.Name
                 * FROM Customer c
                 * INNER JOIN Orders o ON o.CustomerId = c.Id
                 * */
            }

            int orderId = int.Parse(WriteRead("Order Id? "));
            var orderInst = db.Orders.Where(o => o.Id == orderId).First();

            foreach (var orderItems in orderInst.Items)
            {
                Console.WriteLine($"-- {orderItems}");
            }

            foreach (var item in db.Products)
            {
                Console.WriteLine($"{item.Id} - {item.Name}");
            }

            int itemId = int.Parse(WriteRead("Item Id? "));

            var itemInst = db.Products.Where(i => i.Id == itemId).First();

            var orderItem = new OrderItems
            {
                Order = orderInst,
                Product = itemInst
            };

            db.OrderItems.Add(orderItem);
            db.SaveChanges();
        }

        /*****************************************************
         * CreateOrder()
         *      Gets and adds Order data to db
         ****************************************************/
        private static void CreateOrder(OrderContext db)
        {
            int allOrders = db.Orders.Count();
            Console.WriteLine($"{allOrders} Orders in db.");

            //Display all customers
            foreach (var c in db.Customers)
            {
                Console.WriteLine($"{c.Id} - {c.Name}");
            }

            int customerId = int.Parse(WriteRead("Enter Customer Id: "));

            var customer = db.Customers.Where(c => c.Id == customerId).First();

            var discount = double.Parse(WriteRead("Discount (25.0): "));

            var newOrder = new Order
            {
                Customer = customer,
                OrderDate = DateTime.Now,
                Discount = discount
            };

            db.Orders.Add(newOrder);
            db.SaveChanges();
        }

        /*****************************************************
         * CreateProduct()
         *      Gets and adds Product data to DB
         ****************************************************/
        private static void CreateProduct(OrderContext db)
        {
            var allProducts = db.Products.Count();
            /* SELECT DISTINCT COUNT
             * FROM  Products*/

            Console.WriteLine($"{allProducts} products in DB.");
            var name = WriteRead("Name? ");
            double price = double.Parse(WriteRead("Price? "));
            int qnty = int.Parse(WriteRead("Quantity? "));

            //This didn't add to db, just allocated memory for it
            Product newProduct = new Product
            {
                Name = name,
                Cost = price,
                Quantity = qnty
            };

            db.Products.Add(newProduct);

            //SaveChanges() actually adds to db
            db.SaveChanges();
        }

        /*****************************************************
         * CreateCustomer()
         *     Gets and saves Customer Data to db
         ****************************************************/
        private static void CreateCustomer(OrderContext db)
        {

            //LINQ provides protection from SQL injection
            var allCustomers = db.Customers.Count();
            /* SELECT DISTINCT COUNT
             * FROM Customers */

            Console.WriteLine($"{allCustomers} in the database.");

            var name = WriteRead("Name? ");
            var phone = WriteRead("Phone? ");
            var address = WriteRead("Address? ");
            var joinDate = DateTime.Now;

            Customer newCustomer = new Customer
            {
                Name = name,
                Phone = phone,
                Address = address,
                JoinDate = joinDate
            };

            db.Customers.Add(newCustomer);
            /* INSERT Customers
             * VALUES name, phone, address, joinDate */

            db.SaveChanges();
        }
    }
}


/* -------------------- EXTRAS -----------------------
* "If you're going to be wrong, be consistantly wrong."
*      (Don't mix naming conventions in a project) 
*      
* To revert a Commit:
*  1) Team Explorer
*  2) Branches
*  3) Right-Click master
*  4) Right-Click commit
*  5) Revert
*  
*  Marking something as "virtual" allows 
*  visual studios to take over
*    
*/


