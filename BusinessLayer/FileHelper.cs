﻿using DomainModel;
using Newtonsoft.Json;

namespace BusinessLayer
{
    public class FileHelper
    {
        public static void PrintBill(List<Product> products, FileExtension fileExtension)
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
            catch (NotImplementedException ex)
            {
                Console.WriteLine("Ce format n'est pas encore supporté");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Une erreur est survenue avec l'écriture du fichier");
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