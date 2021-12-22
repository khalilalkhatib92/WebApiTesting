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
                              where i.Id == invoiceId

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

        public async Task<int> AddCurrency(Currency currency)
        {
            if(db != null)
            {
                await db.Currencies.AddAsync(currency);
                await db.SaveChangesAsync();
                return currency.Id;
            }
            return 0;
        }

        public async Task<int> AddCustomer(Customer customer)
        {
            if (db != null)
            {
                await db.Customers.AddAsync(customer);
                await db.SaveChangesAsync();
                return customer.Id;
            }
            return 0;
        }

        public async Task<int> AddInvoice(Invoice invoice)
        {
            if (db != null)
            {
                await db.Invoices.AddAsync(invoice);
                await db.SaveChangesAsync();
                return invoice.Id;
            }
            return 0;
        }

        public async Task<int> AddItem(Item item)
        {
            if (db != null)
            {
                await db.Items.AddAsync(item);
                await db.SaveChangesAsync();
                return item.Id;
            }
            return 0;
        }

        public async Task<int> DeleteCurrency(int? currencyId)
        {
            int result = 0;
            if(db != null)
            {
                var currency = await db.Currencies.FirstOrDefaultAsync(x => x.Id == currencyId);
                if(currency != null)
                {
                    db.Currencies.Remove(currency);
                    result = await db.SaveChangesAsync();
                }
                return result;

            }
            return result;
        }

        public async Task<int> DeleteCustomer(int? customerId)
        {
            int result = 0;
            if (db != null)
            {
                var customer = await db.Customers.FirstOrDefaultAsync(x => x.Id == customerId);
                if (customer != null)
                {
                    db.Customers.Remove(customer);
                    result = await db.SaveChangesAsync();
                }
                return result;

            }
            return result;
        }

        public async Task<int> DeleteInvoice(int? invoiceId)
        {
            int result = 0;
            if (db != null)
            {
                var invoice = await db.Invoices.FirstOrDefaultAsync(x => x.Id == invoiceId);
                if (invoice != null)
                {
                    db.Invoices.Remove(invoice);
                    result = await db.SaveChangesAsync();
                }
                return result;

            }
            return result;
        }

        public async Task<int> DeleteItem(int? itemId)
        {
            int result = 0;
            if (db != null)
            {
                var item = await db.Items.FirstOrDefaultAsync(x => x.Id == itemId);
                if (item != null)
                {
                    db.Items.Remove(item);
                    result = await db.SaveChangesAsync();
                }
                return result;

            }
            return result;
        }


        public async Task UpdateCurrency(Currency currency)
        {
            if(db != null)
            {
                db.Currencies.Update(currency);
                await db.SaveChangesAsync();
            }
        }

        public async Task UpdateCustomer(Customer customer)
        {
            if (db != null)
            {
                db.Customers.Update(customer);
                await db.SaveChangesAsync();
            }
        }

        public async Task UpdateInvoice(Invoice invoice)
        {
            if (db != null)
            {
                db.Invoices.Update(invoice);
                await db.SaveChangesAsync();
            }
        }

        public async Task UpdateItem(Item item)
        {
            if (db != null)
            {
                db.Items.Update(item);
                await db.SaveChangesAsync();
            }
        }
    }
}
