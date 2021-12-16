using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiTesting.Models
{
    public partial class Invoice
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? ItemId { get; set; }
        public DateTime? DateOf { get; set; }
        public int? Quantity { get; set; }
        public int? Total { get; set; }
        public int? NetTotal { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Item Item { get; set; }
    }
}
