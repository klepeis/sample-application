using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.Contracts
{
    public static class Orders
    {
        public static class V1
        {
            public class Create
            {
                public Guid Id { get; set; }
            }
        }
    }
}
