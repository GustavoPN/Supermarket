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
            Id = Guid.NewGuid();
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public string NutritionalInformation { get; private set; }
        public string BarCode { get; private set; }
        public void SetNutritionalInformation(string value)
        {
            if(value != string.Empty && !string.IsNullOrWhiteSpace(value))
                NutritionalInformation = value;
        }
        public void SetName(string value)
        {
            if (value != string.Empty && !string.IsNullOrWhiteSpace(value))
                Name = value;
        }
        public void SetDescription(string value)
        {
            if (value != string.Empty && !string.IsNullOrWhiteSpace(value))
                Description = value;
        }
        public void SetBarCode(string value)
        {
            if (value != string.Empty && !string.IsNullOrWhiteSpace(value))
                BarCode = value;
        }
    }
}
