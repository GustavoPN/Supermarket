using SocialMiner.SupermarketProducts.Domain.Core;

namespace SocialMiner.SupermarketProducts.Domain.Product
{
    public class Product : Entity
    {
        public Product(string name, string description, string nutritionalInformation, string barCode)
        {
            Name = name;
            Description = description;
            NutritionalInformation = nutritionalInformation;
            BarCode = barCode;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string NutritionalInformation { get; private set; }
        public string BarCode { get; private set; }
    }
}
