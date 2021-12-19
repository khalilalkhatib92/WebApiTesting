using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTesting.ViewModel
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? ItemId { get; set; }
        public DateTime? DateOf { get; set; }
        public int? Quantity { get; set; }
        public int? Total { get; set; }
        public int? NetTotal { get; set; }

        // Customer Info
        //public virtual Customer Customer { get; set; }
        public string CustomerName { get; set; }
        public int? CurrencyId { get; set; }
        public string CurrencyName { get; set; }

        // Item Info
        //public virtual Item Item { get; set; }
        public string ItemName { get; set; }
        public string Unit { get; set; }
        public int Price { get; set; }

    }
}
