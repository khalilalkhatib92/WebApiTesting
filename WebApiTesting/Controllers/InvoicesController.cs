using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTesting.Models;
using WebApiTesting.Repository;

namespace WebApiTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        IInvoiceRepository invoiceRepository;
        public InvoicesController(IInvoiceRepository _invoiceRepository)
        {
            invoiceRepository = _invoiceRepository;
        }
        [HttpGet]
        [Route("GetInvoices")]
        public async Task<IActionResult> GetInvoices()
        {
            try
            {
                var invoice = await invoiceRepository.GetInvoices();
                if(invoice == null)
                {
                    return NotFound();
                }
                return Ok(invoice);
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpGet]
        [Route("GetInvoice")]
        public async Task<IActionResult> GetInvoice(int? invoceId)
        {
            if(invoceId == null)
            {
                return BadRequest();
            }
            try
            {
                var invoice = await invoiceRepository.GetInvoice(invoceId);
                if (invoice == null)
                {
                    return NotFound();
                }
                return Ok(invoice);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
