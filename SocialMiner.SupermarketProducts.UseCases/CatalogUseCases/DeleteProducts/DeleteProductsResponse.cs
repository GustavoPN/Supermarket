namespace SupermarketProducts.UseCases.CatalogUseCases.DeleteProducts
{
    public class DeleteProductsResponse 
    {
        public DeleteProductsResponse(bool deleted)
        {
            Deleted = deleted;
        }

        public bool Deleted { get; set; }
    }
}
