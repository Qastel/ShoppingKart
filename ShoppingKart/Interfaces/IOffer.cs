using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart.Interfaces
{
    public interface IOffer
    {
        int Quantity { get; }
        double GetTotalOfferPrice(int quantity);
    }
}
