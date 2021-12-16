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
        Task<List<InvoiceViewModel>> GetInvoiceViewModels();
        Task<InvoiceViewModel> GetInvoice();

    }
}
