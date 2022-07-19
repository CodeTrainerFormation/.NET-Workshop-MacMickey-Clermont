using System.Runtime.Serialization;

namespace DomainModel
{
    // POCO : Plain Old CLR Object
    // DTO : Data Transfer Object (Sérialisation/Désérialisation)
    // Entités
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Stockpiled { get; set; }
    }
}