using System;

namespace Models
{
    public class Product : ICloneable
    {
        public string Name { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Price { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
