using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Order
{
    public static class ReadModels
    {
        public class OrderItem
        {
            public int Id { get; set; }
            public string ProductName { get; set; }
            public string PictureUrl { get; set; }
            public decimal UnitPrice { get; set; }
        }
    }
}
