using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.Order
{
    public static class ReadModel
    {
        public class OrderItem
        {
            public int ProductId { get; private set; }
            public string _productName;
            public string _pictureUrl;
            public decimal _unitPrice;
            public decimal _discount;
            public int _units;
        }
    }
}
