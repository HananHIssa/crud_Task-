using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.content
{
    internal class Order
    {
        public int id { get; set; }
        public string address { get; set; }
        public DateTime CreatedAt { get; set; }
        public int price { get; set; }
    }
}
