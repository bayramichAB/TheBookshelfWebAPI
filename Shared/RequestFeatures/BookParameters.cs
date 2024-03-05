using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestFeatures
{
    public class BookParameters : RequestParameters
    {
        public decimal MinPrice {  get; set; }
        public decimal MaxPrice { get; set; } = 1000;

        public bool ValidPriceRange => MaxPrice > MinPrice;

        public bool? availableBook { get; set; }
    }

    public abstract class BookAvailable
    {
        
    }
}
