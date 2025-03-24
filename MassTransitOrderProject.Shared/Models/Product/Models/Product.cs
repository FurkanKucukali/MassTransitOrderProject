using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransitOrderProject.Shared.Models.Product.Models
{
    public record Product(Guid ProductId, double Quantity, double Price);
}
