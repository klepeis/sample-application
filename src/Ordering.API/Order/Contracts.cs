namespace Ordering.API.Order
{
    public static class Contracts
    {
        public static class V1
        {
            public class Create
            {
                public string Street { get; set; }
                public string City { get; set; }
                public string State { get; set; }
                public string Country { get; set; }
                public string ZipCode { get; set; }
            }
        }
    }
}
