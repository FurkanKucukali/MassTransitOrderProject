using MassTransitOrderProject.Shared.Models.Product.Models;

namespace MassTransitOrderProject.API.Models
{
    public record CreateOrder (Guid customerID, List<Product> Products);
    
        
    
}
