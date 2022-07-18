﻿using BusinessLayer;
using DomainModel;
using System.Diagnostics;

namespace MacConsole
{
    internal class Program
    {
        public static void Main(string[] args)
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
                Log("ajout d'une facture");

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
                            Log("impression en texte");
                            FileHelper.PrintBill(products, FileExtension.TXT);
                            break;
                        case "2":
                            Log("impression en json");
                            FileHelper.PrintBill(products, FileExtension.JSON);
                            break;
                        case "3":
                            Log("impression en xml");
                            FileHelper.PrintBill(products, FileExtension.XML);
                            break;
                        default:
                            throw new NotSupportedException();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Log($"exception : {ex?.InnerException.Message}");
                }

            }

            Console.WriteLine("Hello, World!");
        }

        public static void Log(string message)
        {
            Debug.WriteLine($"DEBUG : {message}");
        }
    }
}