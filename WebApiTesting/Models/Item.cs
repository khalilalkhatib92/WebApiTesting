using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiTesting.Models
{
    public partial class Item
    {
        public Item()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public int? Price { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
