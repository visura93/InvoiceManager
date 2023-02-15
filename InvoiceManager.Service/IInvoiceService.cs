using InvoiceManager.Models.DomainObjects;
using InvoiceManager.Models.DTOs;

namespace InvoiceManager.Service
{
    public interface IInvoiceService
    {
        Task<ResponseResult> AddInvoiceAsync(InvoiceDto invoice);
        Task<ResponseResult> UpdateInvoiceAsync(InvoiceDto invoice);

    }
}