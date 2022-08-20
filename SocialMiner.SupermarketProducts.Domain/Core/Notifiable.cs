namespace SocialMiner.SupermarketProducts.Domain.Core
{
    [BsonIgnoreExtraElements]
    public abstract class Notifiable : INotifiable
    {
        [BsonIgnore]
        public List<DomainError> Errors { get; set; }

        protected Notifiable()
        {
            Errors = new List<DomainError>();
        }

        public void Fail(string mensage, int statusCode)
        {
            this.Errors.Add(new DomainError { Code = statusCode, Message = mensage });
        }
        public void Fail(IList<DomainError> errors)
        {
            this.Errors.AddRange(errors);
        }
    }

    internal class BsonIgnoreExtraElementsAttribute : Attribute
    {
    }

    internal class BsonIgnoreAttribute : Attribute
    {
    }

    public interface INotifiable
    {
        List<DomainError> Errors { get; set; }
    }

}