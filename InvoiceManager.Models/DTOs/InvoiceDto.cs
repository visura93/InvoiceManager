using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager.Models.DTOs
{
    public class InvoiceDto
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double TotalAmount { get; set; }
        [Required]
        public List<InvoiceItemDto> InvoiceItems { get; set; }
    }
}
