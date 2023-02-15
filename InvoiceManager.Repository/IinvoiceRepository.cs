using InvoiceManager.Models.DomainObjects;

namespace InvoiceManager.Repository
{
    public interface IinvoiceRepository
    {
        Task<ResponseResult> AddInvoiceAsync(Invoice invoice);
        Task<ResponseResult> UpdateInvoiceAsync(Invoice invoice);
    }
}