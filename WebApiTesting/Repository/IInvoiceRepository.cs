using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTesting.Models;
using WebApiTesting.ViewModel;

namespace WebApiTesting.Repository
{
    public interface IInvoiceRepository
    {
        Task<List<Currency>> GetCurrencies();
        Task<List<Customer>> GetCustomers();
        Task<List<Item>> GetItems();
        Task<List<InvoiceViewModel>> GetInvoices();
        Task<InvoiceViewModel> GetInvoice(int? invoiceId);

        Task<int> AddCurrency(Currency currency);
        Task UpdateCurrency(Currency currency);
        Task<int> DeleteCurrency(int? currencyId);

        Task<int> AddCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task<int> DeleteCustomer(int? customerId);

        Task<int> AddItem(Item item);
        Task UpdateItem(Item item);
        Task<int> DeleteItem(int? itemId);

        Task<int> AddInvoice(Invoice invoice);
        Task UpdateInvoice(Invoice invoice);
        Task<int> DeleteInvoice(int? invoiceId);


    }
}
