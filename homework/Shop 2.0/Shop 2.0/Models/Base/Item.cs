using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop_2._0.Interfaces;

namespace Shop_2._0.Models.Base
{
    public abstract class Item : IDescriber
    {
        public string Name { get; set; }
        public decimal PriceDecimal { get; set; }
        public int Quantity { get; set; }

        public string DescribeItem() => $"{Name}, ${PriceDecimal}, left in stock: {Quantity}.";
    }
}

