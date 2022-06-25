using SocialMiner.SupermarketProducts.Domain.Core;

namespace SupermarketProducts.Core.Reset
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
            Errors = new List<string>();
        }
        public T Response { get; set; }
        public bool Success => !Errors.Any();
        public List<string> Errors { get; set; }

        public void AddDomainErrors(IList<DomainError> domainErrors)
            => Errors.AddRange(domainErrors.Select(x => x.Message));
 
    }
}
