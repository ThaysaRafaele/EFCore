using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public List<Item> Items { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
