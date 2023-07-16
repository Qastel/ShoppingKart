using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart.Interfaces
{
    public interface ICheckoutSystem
    {
        void Scan(char item);
        double GetTotalPrice();
    }
}
