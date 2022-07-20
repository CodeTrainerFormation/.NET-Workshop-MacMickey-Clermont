using BusinessLayer;
using DomainModel;
using System.Diagnostics;

namespace MacConsole
{
    // type de delegate = type de pointeur de fonction(s)
    // précisement une fonction qui a comme paramètre une chaine et ne renvoit rien
    //public delegate void MyLoggerDelegate(string text);

    internal class Program
    {
        //  delegate = pointeur de fonction(s)
        // private static MyLoggerDelegate myLoggerDelegate = null;
        private static Action<string> myLoggerDelegate = null;

        public static void Log(string message)
        {
            Debug.WriteLine($"DEBUG : {message}");
        }

        public static void LogConsole(string myMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"CONSOLE : {myMessage}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Main(string[] args)
        {
            // TODO : modifier l'interface pour qu'elles permettent de requêter
            //        les méthodes de la couche métier

            //SubscriptionsAnonymousMethods();
            //SubscriptionsWithMethods();

            ProductOrder order = new ProductOrder();

            Product p = new Product()
            {
                Name = "Big Mick'",
                Description = "Le seul, l'unique Big Mick' de chez Mac Mickey ! Ses deux steaks hachés, son cheddar fondu, ses oignons, ses cornichons, son lit de salade et sa sauce inimitable, font du Big Mick' un sandwich culte et indémodable.",
                Price = 4.00M,
                Stockpiled = 50,
            };
            order.AddProduct(p);

            order.AddProduct(new Product()
            {
                Name = "Royal O'Duck",
                Description = "Fondez pour son canard pané croustillant et sa sauce légèrement vinaigrée aux oignons et aux câpres, le tout dans un pain cuit vapeur. Laissez-vous prendre dans ses filets !",
                Price = 3.90M,
                Stockpiled = 30,
            });

            order.AddProduct(new Product()
            {
                Name = "Duck Wings",
                Description = "Craquez pour ces ailes croustillantes, à savourer avec ou sans sauce, en famille ou entre amis, faîtes-vous plaisir !",
                Price = 4.30M,
                Stockpiled = 100,
            });

            order.CreateProduct("720", 8.70M, "720 grammes de pur plaisir", 20);

            //Product p3 = order.GetProductByName("Big Mick'");

            //List<Product> products = order.GetProductsWithPriceInferiorAtAndNameStartBy(5M, 'B');

            //foreach (var product in products)
            //{
            //    Console.WriteLine($"{product.Name} - {product.Price}");
            //}


            //Product? p1 = order.GetProductById(1);

            //if(p1 != null)
            //{
            //    p1.Price = 8.80M;
            //    p1.Name = $"New {p1.Name}";
            //}

            //order.UpdateProduct(p1);


            //order.UpdateProduct(2, "Royal O'Duck", 4.99M, "Fondez pour son canard pané croustillant et sa sauce légèrement vinaigrée aux oignons et aux câpres, le tout dans un pain cuit vapeur. Laissez-vous prendre dans ses filets !", 30);


            //order.DeleteProduct(p1);

            //order.DeleteProduct(2);

            //order.DeleteProductRemoveAll(3);


            //foreach (var product in order.GetProducts())
            //{
            //    Console.WriteLine($"{product.Name} - {product.Price}");
            //}



            Console.WriteLine($"--- produits ajoutés ---{Environment.NewLine}");

            Console.WriteLine("Voulez-vous une facture ? (taper oui ou non)");

            string output = Console.ReadLine();

            if (output.ToLower() == "oui")
            {
                if (myLoggerDelegate != null)
                    myLoggerDelegate("ajout d'une facture");

                Console.WriteLine("Format du fichier de facture (tapez uniquement le numéro) : ");
                Console.WriteLine("1 - text");
                Console.WriteLine("2 - json");
                Console.WriteLine("3 - xml");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            if (myLoggerDelegate != null)
                                myLoggerDelegate("impression en texte");

                            FileHelper.PrintBill(order.GetProducts(), FileExtension.TXT);
                            break;
                        case "2":
                            if (myLoggerDelegate != null)
                                myLoggerDelegate("impression en json");

                            FileHelper.PrintBill(order.GetProducts(), FileExtension.JSON);
                            break;
                        case "3":
                            if (myLoggerDelegate != null)
                                myLoggerDelegate("impression en xml");

                            FileHelper.PrintBill(order.GetProducts(), FileExtension.XML);
                            break;
                        default:
                            throw new NotSupportedException();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    myLoggerDelegate($"exception : {ex?.InnerException.Message}");
                }

            }

            Console.WriteLine("Hello, World!");
        }

        private static void SubscriptionsWithMethods()
        {
            Console.WriteLine("Debug ?");
            if ("oui" == Console.ReadLine())
                myLoggerDelegate += Log;


            Console.WriteLine("Console ?");
            if ("oui" == Console.ReadLine())
                myLoggerDelegate += LogConsole;
        }

        private static void SubscriptionsAnonymousMethods()
        {
            Console.WriteLine("Lambda method (simple line) ?");
            if ("oui" == Console.ReadLine())
            {
                myLoggerDelegate += text => Console.WriteLine($"LAMBDA in white : {text}");
            }


            Console.WriteLine("Lambda method ?");
            if ("oui" == Console.ReadLine())
            {
                myLoggerDelegate += text =>
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"LAMBDA : {text}");
                    Console.ForegroundColor = ConsoleColor.White;
                };
            }


            Console.WriteLine("Anonymous method ?");
            if ("oui" == Console.ReadLine())
            {
                myLoggerDelegate += delegate (string text)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"ANONYMOUS : {text}");
                    Console.ForegroundColor = ConsoleColor.White;
                };
            }
        }
    }
}