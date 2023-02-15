using InvoiceManager.Models.DomainObjects;
using InvoiceManager.Models.DTOs;
using InvoiceManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager.Service
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IinvoiceRepository _invoiceRepository;

        public InvoiceService(IinvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }


        public async Task<ResponseResult> AddInvoiceAsync(InvoiceDto invoiceDto)
        {
            try
            {
                Invoice invoice = new Invoice
                {
                    Id = invoiceDto.Id,
                    Date = invoiceDto.Date,
                    Description = invoiceDto.Description,
                    InvoiceItems = (List<InvoiceItem>)invoiceDto.InvoiceItems.Select(x => new InvoiceItem
                    {
                        Amount = x.Amount,
                        Quantity = x.Quantity,
                        UnitPrice = x.UnitPrice,
                        TotalAmount = x.TotalAmount
                    }).ToList(),
                };

                var responce = await _invoiceRepository.AddInvoiceAsync(invoice);
                return responce;
            }
            catch (Exception ex)
            {
               return new ResponseResult() { IsError = true, Message= ex.Message };
            }
        }

        public async Task<ResponseResult> UpdateInvoiceAsync(InvoiceDto invoiceDto)
        {
            try
            {
                Invoice invoice = new Invoice
                {
                    Id = invoiceDto.Id,
                    Date = invoiceDto.Date,
                    Description = invoiceDto.Description,
                    InvoiceItems = (List<InvoiceItem>)invoiceDto.InvoiceItems.Select(x => new InvoiceItem
                    {
                        Amount = x.Amount,
                        Quantity = x.Quantity,
                        UnitPrice = x.UnitPrice,
                        TotalAmount = x.TotalAmount
                    }).ToList(),
                };

                var responce = await _invoiceRepository.UpdateInvoiceAsync(invoice);
                return responce;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
