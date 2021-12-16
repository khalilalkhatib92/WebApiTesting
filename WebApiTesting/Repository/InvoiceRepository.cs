using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTesting.Models;
using WebApiTesting.ViewModel;

namespace WebApiTesting.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        ApiDbContext db;
        public InvoiceRepository(ApiDbContext _db)
        {
            db = _db;
        }

        public async Task<List<Currency>> GetCurrencies()
        {
            if (db != null)
            {
                return await db.Currencies.ToListAsync();
            }
            return null;
        }

        public Task<List<Customer>> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceViewModel> GetInvoice()
        {
            throw new NotImplementedException();
        }

        public Task<List<InvoiceViewModel>> GetInvoiceViewModels()
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> GetItems()
        {
            throw new NotImplementedException();
        }
    }
}
