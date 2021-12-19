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

        public async Task<List<Customer>> GetCustomers()
        {
            if (db != null)
            {
                return await db.Customers.ToListAsync();
            }
            return null;
        }

        public async Task<InvoiceViewModel> GetInvoice(int? invoiceId)
        {
            if (db != null)
            {
                return await (from i in db.Invoices
                              from c in db.Customers
                                  //from cr in db.Currencies
                                  //from it in db.Items
                              where i.CustomerId == c.Id

                              select new InvoiceViewModel
                              {
                                  Id = i.Id,
                                  CustomerId = i.CustomerId,
                                  CustomerName = i.Customer.Name,
                                  DateOf = i.DateOf,
                                  CurrencyId = i.Customer.Currency.Id,
                                  CurrencyName = i.Customer.Currency.Name,
                                  ItemId = i.Item.Id,
                                  ItemName = i.Item.Name,
                                  Unit = i.Item.Unit,
                                  Price = (int)i.Item.Price,
                                  Quantity = i.Quantity,
                                  Total = i.Total,
                                  NetTotal = i.NetTotal
                              }

                    ).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<List<InvoiceViewModel>> GetInvoices()
        {
            if(db != null)
            {
                return await (from i in db.Invoices
                             from c in db.Customers
                             //from cr in db.Currencies
                             //from it in db.Items
                             where i.CustomerId == c.Id
                             
                             select new InvoiceViewModel
                              {
                                  Id = i.Id,
                                  CustomerId = i.CustomerId,
                                  CustomerName = i.Customer.Name,
                                  DateOf = i.DateOf,
                                  CurrencyId = i.Customer.Currency.Id,
                                  CurrencyName= i.Customer.Currency.Name,
                                  ItemId = i.Item.Id,
                                  ItemName = i.Item.Name,
                                  Unit = i.Item.Unit,
                                  Price = (int)i.Item.Price,
                                  Quantity = i.Quantity,
                                  Total = i.Total,
                                  NetTotal = i.NetTotal
                             }

                    ).ToListAsync();
            }
            return null;
        }

        public async Task<List<Item>> GetItems()
        {
            if (db != null)
            {
                return await db.Items.ToListAsync();
            }
            return null;
        }

        public Task<int> AddCurrency(Currency currency)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddInvoice(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddItem(Item item)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteCurrency(int? currencyId)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteCustomer(int? customerId)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteInvoice(int? invoiceId)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteItem(int? itemId)
        {
            throw new NotImplementedException();
        }


        public Task UpdateCurrency(Currency currency)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task UpdateInvoice(Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public Task UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
