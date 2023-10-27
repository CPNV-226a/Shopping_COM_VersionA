using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    internal interface ICollectionOfArticles
    {
        void Add(List<CartItem> cartItems);
        List<CartItem> Remove(Boolean empty=false);
        List<CartItem> CartItems { get; }
    }
}
