using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiTesting.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int? CurrencyId { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
