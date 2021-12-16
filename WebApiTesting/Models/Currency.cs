using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiTesting.Models
{
    public partial class Currency
    {
        public Currency()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
