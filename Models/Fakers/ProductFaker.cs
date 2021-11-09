using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Fakers
{
    public class ProductFaker : BaseFaker<Product>
    {
        public ProductFaker()
        {
            RuleFor(x => x.Name, x => x.Commerce.ProductName());
            RuleFor(x => x.Price, x => x.Finance.Amount(1, 50) );
            RuleFor(x => x.ExpirationDate, x => x.Date.Future());
        }
    }
}
