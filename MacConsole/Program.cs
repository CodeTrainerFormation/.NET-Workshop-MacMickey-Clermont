using DomainModel;
using Newtonsoft.Json;

namespace MacConsole
{
    // TODO : enum outputfile (text, json, xml)

    public enum FileExtension
    {
        TXT = 1,
        JSON,
        XML,
    };

    internal class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>()
            {
                new Product()
                {
                    Name = "Big Mick'",
                    Description = "Le seul, l'unique Big Mick' de chez Mac Mickey ! Ses deux steaks hachés, son cheddar fondu, ses oignons, ses cornichons, son lit de salade et sa sauce inimitable, font du Big Mick' un sandwich culte et indémodable.",
                    Price = 4.00M,
                    Stockpiled = 50,
                },
                new Product()
                {
                    Name = "Royal O'Duck",
                    Description = "Fondez pour son canard pané croustillant et sa sauce légèrement vinaigrée aux oignons et aux câpres, le tout dans un pain cuit vapeur. Laissez-vous prendre dans ses filets !",
                    Price = 3.90M,
                    Stockpiled = 30,
                },
                new Product()
                {
                    Name = "Duck Wings",
                    Description = "Craquez pour ces ailes croustillantes, à savourer avec ou sans sauce, en famille ou entre amis, faîtes-vous plaisir !",
                    Price = 4.30M,
                    Stockpiled = 100,
                }
            };

            Console.WriteLine($"--- produits ajoutés ---{Environment.NewLine}");

            Console.WriteLine("Voulez-vous une facture ? (taper oui ou non)");

            string output = Console.ReadLine();

            if(output.ToLower() == "oui")
            {
                Console.WriteLine("Format du fichier de facture (tapez uniquement le numéro) : ");
                Console.WriteLine("1 - text");
                Console.WriteLine("2 - json");
                Console.WriteLine("3 - xml");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PrintBill(products, FileExtension.TXT);
                        break;
                    case "2":
                        PrintBill(products, FileExtension.JSON);
                        break;
                    case "3":
                        PrintBill(products, FileExtension.XML);
                        break;
                    default:
                        throw new NotSupportedException();
                }

            }

            Console.WriteLine("Hello, World!");
        }

        private static void PrintBill(List<Product> products, FileExtension fileExtension)
        {
            FileStream? fs = null;
            StreamWriter? sw = null;

            try
            {
                string filetime = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

                fs = new FileStream($"bill_{filetime}.{fileExtension.ToString().ToLower()}", FileMode.CreateNew, FileAccess.Write);
                sw = new StreamWriter(fs);

                switch (fileExtension)
                {
                    case FileExtension.TXT:
                        PrintText(products, sw);
                        break;

                    case FileExtension.JSON:
                        PrintJson(products, sw);
                        break;

                    case FileExtension.XML:
                        throw new NotImplementedException();
                        break;

                    default:
                        break;
                }

                
            }
            catch (Exception ex)
            {
                // TODO : changer l'exception par un message
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (sw != null)
                    sw.Close();

                if (fs != null)
                    fs.Close();
            }
        }

        private static void PrintJson(List<Product> products, StreamWriter sw)
        {
            string serializedProducts = JsonConvert.SerializeObject(products);

            sw.Write(serializedProducts);
        }

        private static void PrintText(List<Product> products, StreamWriter sw)
        {
            sw.WriteLine($"Facture client {Environment.NewLine}");

            foreach (Product product in products)
            {
                sw.WriteLine($"{product.Name} - {product.Price} €");
            }
        }
    }
}