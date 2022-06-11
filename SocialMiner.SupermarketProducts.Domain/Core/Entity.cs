namespace SocialMiner.SupermarketProducts.Domain.Core
{
    public abstract class Entity : Notifiable
    {

        public Guid Id { get; protected set; }

        public virtual bool IsValid()
        {
            return !this.Errors.Any();
        }
    }

}
