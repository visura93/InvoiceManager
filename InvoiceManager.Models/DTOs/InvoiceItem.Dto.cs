using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager.Models.DTOs
{
    public class InvoiceItemDto
    {
        public double Amount { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalAmount { get; set; }
    }
}
