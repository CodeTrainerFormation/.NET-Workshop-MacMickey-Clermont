using DomainModel;
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
                //Log.LogError(ex);
                throw new Exception("Ce format n'est pas encore supporté", ex); 
            }
            catch (Exception ex)
            {
                //Log.LogError(ex);
                throw new Exception("Une erreur est survenue avec l'écriture du fichier", ex);
            }
            finally
            {
                if (sw != null)
                    sw.Close();

                if (fs != null)
                    fs.Close();
            }

            try
            {

            }
            catch (Exception)
            {

                throw;
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