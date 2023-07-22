using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart.Interfaces
{
    public interface IItem
    {
        char SKU { get; }
        double Price { get; }
        public IOffer? Offer { get; }
    }
}
