using InvoiceManager.Models.DomainObjects;
using InvoiceManager.Models.DTOs;
using InvoiceManager.Repository;
using InvoiceManager.Service;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;


        public InvoiceController(IInvoiceService invoiceService, IinvoiceRepository repo)
        {
            _invoiceService = invoiceService;
        }
        /// <summary>
        /// Create Invoice
        /// </summary>
        /// <param name="createDto"></param>
        /// <returns></returns>


        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> CreateInvoiceAsync(InvoiceDto createDto)
        {
            try
            {
                var responce = await _invoiceService.AddInvoiceAsync(createDto);


                return Ok(responce);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseResult() { IsError = true, Message = ex.Message });
            }
        }

        /// <summary>
        /// Update Invoice
        /// </summary>
        /// <param name="editDto"></param>
        /// <returns></returns>
        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> EditInvoiceAsync(InvoiceDto editDto)
        {
            try
            {
                var responce = await _invoiceService.UpdateInvoiceAsync(editDto);

                return Ok(responce);
            }
            catch (Exception ex)
            {
                return BadRequest(new { IsError = true, ErrorMessage = ex.Message });
            }
        }
    }

}